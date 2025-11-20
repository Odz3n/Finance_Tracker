using Domain;
using Infrastructure;
using Shared.Requests;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        TcpListener _server;
        CancellationTokenSource _cts;
        DbManager _db;

        List<ConnectedUser> _connectedUsers;

        const int BUFFER_SIZE = 2048;

        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public FinanceTrackerDbContext? Context { get; set; }
        public Server(IPAddress address, int port)
        {
            IPAddress = address;
            Port = port;
        }
        public async Task StartAsync()
        {
            try
            {
                if (Context == null)
                    throw new ArgumentNullException($"The '{nameof(Context)}' property must be specified before the server starts working.");

                _cts = new CancellationTokenSource();

                _connectedUsers = new List<ConnectedUser>();

                _server = new TcpListener(IPAddress, Port);
                _server.Start();
                _ = HandleConnectionsAsync(_cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"StartAsync: {ex.Message}");
            }
        }
        private async Task HandleConnectionsAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var client = await _server.AcceptTcpClientAsync();

                    var clientStream = client.GetStream();

                    var streamBuffer = new byte[BUFFER_SIZE];
                    var bufferSize = await clientStream.ReadAsync(streamBuffer, 0, streamBuffer.Length);

                    if (bufferSize <= 0)
                        continue;

                    var json = Encoding.UTF8.GetString(streamBuffer);
                    var baseRequest = JsonSerializer.Deserialize<Request>(json);

                    if (baseRequest?.Type == RequestType.Reg)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<RegistrationRequest>(json);
                        if (concreteRequest != null)
                            _ = HandleRegistrationRequestAsync(concreteRequest, token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectionsAsync: {ex.Message}");
            }
        }
        private async Task HandleRegistrationRequestAsync(RegistrationRequest request, CancellationToken token)
        {
            try
            {
                var sender = request.Sender;
                var firstName = request.FirstName;
                var lastName = request.LastName;
                var login = request.Login;
                (var hash, var salt) = PasswordHelper.HashPassword(request.Password);
                await _db.AddUserAsync(login, firstName, lastName, hash, salt);

                var response = new RegistrationResponse { IsSuccess = true, Message = "Successfully registered." };

                await RespondToSenderAsync(sender, response, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleRegistrationRequestAsync: {ex.Message}");
            }
        }
        private async Task RespondToSenderAsync(TcpClient sender, Response response, CancellationToken token)
        {
            var json = JsonSerializer.Serialize(response);
            var data = Encoding.UTF8.GetBytes(json);
            await sender.GetStream().WriteAsync(data, 0, data.Length, token);
        }
    }
}
