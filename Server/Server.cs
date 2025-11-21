using Domain;
using Infrastructure;
using Microsoft.VisualBasic.ApplicationServices;
using Server.Events;
using Shared;
using Shared.Requests;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
        public event EventHandler<UserDisconnectedEventArgs> UserDisconnected;
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

                _db = new DbManager(Context);

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
                    _ = HandleClientAsync(client, token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectionsAsync: {ex.Message}");
            }
        }
        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            try
            {
                var clientStream = client.GetStream();
                var streamBuffer = new byte[BUFFER_SIZE];
                while (!token.IsCancellationRequested)
                {
                    var bufferSize = await clientStream.ReadAsync(streamBuffer, 0, streamBuffer.Length);

                    if (bufferSize <= 0)
                    {
                        break;
                    }

                    var json = Encoding.UTF8.GetString(streamBuffer, 0, bufferSize);
                    Console.WriteLine(json);
                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest?.Type == RequestType.Reg)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<RegistrationRequest>(json);
                        Console.WriteLine(concreteRequest.LastName);
                        if (concreteRequest != null)
                            await HandleRegistrationRequestAsync(client, concreteRequest, token);
                    }

                    if (baseRequest?.Type == RequestType.Auth)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<AuthorizationRequest>(json);
                        Console.WriteLine($"{concreteRequest.Login} - {concreteRequest.Password} - {client.Client.RemoteEndPoint}");
                        if (concreteRequest != null)
                        {
                            var res = await HandleAuthorizationRequestAsync(client, concreteRequest, token);
                            if (res == true)
                                break;
                            else
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleClientAsync: {ex.Message}");
            }
        }
        private async Task HandleRegistrationRequestAsync(TcpClient sender, RegistrationRequest request, CancellationToken token)
        {
            try
            {
                var requestSender = sender;
                var firstName = request.FirstName;
                var lastName = request.LastName;
                var login = request.Login;
                (var hash, var salt) = PasswordHelper.HashPassword(request.Password);
                var result = await _db.AddUserAsync(login, firstName, lastName, hash, salt);

                var response = new RegistrationResponse { IsSuccess = result.IsSuccess, Message = result.Message };

                var responseMessage = $"[{DateTime.Now:HH:mm:ss}] [{request.Type.ToString()}] {login} - {(response.IsSuccess ? "Registered" : "Fail")}";

                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { Message = responseMessage });

                await RespondToSenderAsync(sender, response, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleRegistrationRequestAsync: {ex.Message}");
            }
        }
        private async Task<bool> HandleAuthorizationRequestAsync(TcpClient sender, AuthorizationRequest request, CancellationToken token)
        {
            try
            {
                var login = request?.Login;
                var password = request?.Password;

                var result = await _db.VerifyUser(login, password);

                var response = new AuthorizationResponse();
                if (result != null)
                {
                    ConnectedUser user = new ConnectedUser
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Client = sender,
                        ConnectionTime = DateTime.Now
                    };

                    lock(connectedUsersLockObject)
                    {
                        _connectedUsers.Add(user);
                    }
                    UserConnected.Invoke(this,
                            new UserConnectedEventArgs { User = user });

                    response.IsSuccess = true;
                    response.Message = "Successfully logined.";
                    response.UserId = result.Id;
                    response.UserLogin = result.Login;

                    await RespondToSenderAsync(sender, response, token);
                    _ = HandleConnectedUserAsync(user, token);

                    MessageReceived.Invoke(this,
                        new MessageReceivedEventArgs { Message = $"[{DateTime.Now:HH:mm:ss}] [{request.Type.ToString()}] {login} - {(response.IsSuccess ? "Authorized" : "Fail")}" });

                    return true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Login failed. Incorrect password or username.";
                    await RespondToSenderAsync(sender, response, token);

                    MessageReceived.Invoke(this,
                        new MessageReceivedEventArgs { Message = $"[{DateTime.Now:HH:mm:ss}] [{request.Type.ToString()}] {login} - {(response.IsSuccess ? "Authorized" : "Fail")}" });

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAuthorizationRequestAsync: {ex.Message}");
                return false;
            }
        }
        private async Task HandleConnectedUserAsync(ConnectedUser user, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { Message = $"[{DateTime.Now:HH:mm:ss}] {user.Login} - Connected" });

                var stream = user.Client.GetStream();
                var buffer = new byte[BUFFER_SIZE];
                while (!token.IsCancellationRequested)
                {
                    var size = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (size == 0)
                        break;

                    var json = Encoding.UTF8.GetString(buffer, 0, size);
                    Console.WriteLine(json);
                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest?.Type == RequestType.Disconnect)
                    {
                        MessageReceived.Invoke(this,
                            new MessageReceivedEventArgs { Message = $"[{DateTime.Now:HH:mm:ss}] [{baseRequest?.Type.ToString()}] {user.Login}" });
                        lock(connectedUsersLockObject)
                        {
                            _connectedUsers.Remove(user);
                        }
                        UserDisconnected.Invoke(this,
                            new UserDisconnectedEventArgs { User = user });
                        break;
                    }
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
            Console.WriteLine("In RespondToSenderAsync");
            var json = JsonSerializer.Serialize(response);
            var data = Encoding.UTF8.GetBytes(json);
            await sender.GetStream().WriteAsync(data, 0, data.Length, token);
        }
        public async Task StopAsync()
        {
            _cts.Cancel();
            _server.Stop();
            foreach (var user in _connectedUsers)
            {
                user.Client.Close();
            }
        }
    }
}
