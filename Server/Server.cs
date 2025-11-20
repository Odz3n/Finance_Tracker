using Domain;
using Infrastructure;
using Shared;
using Server.Events;
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
        object? connectedUsersLockObject = new object();

        public event EventHandler<UserConnectedEventArgs> UserConnected;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

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

                    if (baseRequest?.Type == RequestType.Auth)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<AuthorizationRequest>(json);
                        if (concreteRequest != null)
                            _ = HandleAuthorizationRequestAsync(concreteRequest, token);
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
        private async Task HandleAuthorizationRequestAsync(AuthorizationRequest request, CancellationToken token)
        {
            try
            {
                var login = request?.Login;
                var password = request?.Password;
                var sender = request?.Sender;

                var result = await _db.VerifyUser(login, password);

                var response = new AuthorizationResponse();
                if (result != null)
                {
                    ConnectedUser user = new ConnectedUser
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Client = sender
                    };

                    lock(connectedUsersLockObject)
                    {
                        _connectedUsers.Add(user);
                    }
                    UserConnected.Invoke(this,
                            new UserConnectedEventArgs { User = user });

                    response.IsSuccess = true;
                    response.Message = "Successfully logined.";
                    await RespondToSenderAsync(sender, response, token);
                    _ = HandleConnectedUserAsync(user, token);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Login failed. Incorrect password or username.";
                    await RespondToSenderAsync(sender, response, token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAuthorizationRequestAsync: {ex.Message}");
            }
        }
        private async Task HandleConnectedUserAsync(ConnectedUser user, CancellationToken token)
        {
            try
            {
                var stream = user.Client.GetStream();
                var buffer = new byte[BUFFER_SIZE];
                while (!token.IsCancellationRequested)
                {
                    var size = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (size == 0)
                        break;

                    var json = Encoding.UTF8.GetString(buffer, 0, size);
                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest?.Type == RequestType.Add)
                    {
                        //var concreteRequest = JsonSerializer.Deserialize<>(json);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectedUserAsync: {ex.Message}");
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
