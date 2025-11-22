using Domain;
using Infrastructure;
using Server.Events;
using Shared;
using Shared.Requests;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private TcpListener _server;
        private CancellationTokenSource _cts;
        private DbManager _db;

        private readonly object connectedUsersLockObject = new object();
        private List<ConnectedUser> _connectedUsers;

        public event EventHandler<UserConnectedEventArgs> UserConnected;
        public event EventHandler<UserDisconnectedEventArgs> UserDisconnected;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        private const int BUFFER_SIZE = 2048;

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
                    throw new ArgumentNullException(nameof(Context),
                        "The 'Context' property must be specified before the server starts working.");

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
                await WriteLogAsync($"[ERROR] StartAsync: {ex.Message}");
            }
        }

        private async Task HandleConnectionsAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var client = await _server.AcceptTcpClientAsync(token);
                    _ = HandleClientAsync(client, token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectionsAsync: {ex.Message}");
                await WriteLogAsync($"[ERROR] HandleConnectionsAsync: {ex.Message}");
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
                    var bufferSize = await clientStream.ReadAsync(streamBuffer, 0, streamBuffer.Length, token);

                    if (bufferSize <= 0)
                        break;

                    var json = Encoding.UTF8.GetString(streamBuffer, 0, bufferSize);
                    Console.WriteLine(json);

                    await WriteLogAsync($"[RECV] {json}");

                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest == null)
                        continue;

                    if (baseRequest.Type == RequestType.Reg)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<RegistrationRequest>(json);
                        if (concreteRequest != null)
                            await HandleRegistrationRequestAsync(client, concreteRequest, token);
                    }

                    if (baseRequest.Type == RequestType.Auth)
                    {
                        var concreteRequest = JsonSerializer.Deserialize<AuthorizationRequest>(json);
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
                await WriteLogAsync($"[ERROR] HandleClientAsync: {ex.Message}");
            }
        }

        private async Task HandleRegistrationRequestAsync(TcpClient sender, RegistrationRequest request, CancellationToken token)
        {
            try
            {
                var firstName = request.FirstName;
                var lastName = request.LastName;
                var login = request.Login;
                (var hash, var salt) = PasswordHelper.HashPassword(request.Password);

                var result = await _db.AddUserAsync(login, firstName, lastName, hash, salt);

                var response = new RegistrationResponse
                {
                    IsSuccess = result.IsSuccess,
                    Message = result.Message
                };

                var responseMessage =
                    $"[{DateTime.Now:HH:mm:ss}] [REGISTER] {login} - {(response.IsSuccess ? "Registered" : "Fail")}";

                await WriteLogAsync(responseMessage);

                await RespondToSenderAsync(sender, response, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleRegistrationRequestAsync: {ex.Message}");
                await WriteLogAsync($"[ERROR] HandleRegistrationRequestAsync: {ex.Message}");
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

                    lock (connectedUsersLockObject)
                    {
                        _connectedUsers.Add(user);
                    }

                    UserConnected?.Invoke(this,
                        new UserConnectedEventArgs { User = user });

                    response.IsSuccess = true;
                    response.Message = "Successfully logined.";

                    await WriteLogAsync(
                        $"[{DateTime.Now:HH:mm:ss}] [AUTH] {login} - Authorized");

                    await RespondToSenderAsync(sender, response, token);

                    _ = HandleConnectedUserAsync(user, token);
                    return true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Login failed. Incorrect password or username.";

                    await WriteLogAsync(
                        $"[{DateTime.Now:HH:mm:ss}] [AUTH] {login} - Fail");

                    await RespondToSenderAsync(sender, response, token);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAuthorizationRequestAsync: {ex.Message}");
                await WriteLogAsync($"[ERROR] HandleAuthorizationRequestAsync: {ex.Message}");
                return false;
            }
        }

        private async Task HandleConnectedUserAsync(ConnectedUser user, CancellationToken token)
        {
            try
            {
                await WriteLogAsync($"[{DateTime.Now:HH:mm:ss}] {user.Login} - Connected");

                var stream = user.Client.GetStream();
                var buffer = new byte[BUFFER_SIZE];

                while (!token.IsCancellationRequested)
                {
                    var size = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (size == 0)
                        break;

                    var json = Encoding.UTF8.GetString(buffer, 0, size);
                    Console.WriteLine(json);

                    await WriteLogAsync($"[RECV-CONNECTED] {user.Login}: {json}");

                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest == null)
                        continue;

                    if (baseRequest.Type == RequestType.Disconnect)
                    {
                        await WriteLogAsync(
                            $"[{DateTime.Now:HH:mm:ss}] [Disconnect] {user.Login}"
                        );

                        lock (connectedUsersLockObject)
                        {
                            _connectedUsers.Remove(user);
                        }

                        UserDisconnected?.Invoke(this,
                            new UserDisconnectedEventArgs { User = user });

                        break;
                    }

                    if (baseRequest.Type == RequestType.Add)
                    {
                        await WriteLogAsync($"[{DateTime.Now:HH:mm:ss}] [ADD] Request from {user.Login}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectedUserAsync: {ex.Message}");
                await WriteLogAsync($"[ERROR] HandleConnectedUserAsync: {ex.Message}");
            }
            finally
            {
                try
                {
                    user.Client?.Close();
                }
                catch { }
            }
        }

        private async Task RespondToSenderAsync(TcpClient sender, Response response, CancellationToken token)
        {
            try
            {
                var json = JsonSerializer.Serialize(response);
                var data = Encoding.UTF8.GetBytes(json);

                await WriteLogAsync($"[SEND] {json}");

                await sender.GetStream().WriteAsync(data, 0, data.Length, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RespondToSenderAsync: {ex.Message}");
                await WriteLogAsync($"[ERROR] RespondToSenderAsync: {ex.Message}");
            }
        }

        private async Task WriteLogAsync(string message)
        {
            try
            {
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs { Message = message });
                await _db.AddLogAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WriteLogAsync error: {ex.Message}");
            }
        }

        public async Task StopAsync()
        {
            _cts?.Cancel();
            _server?.Stop();

            if (_connectedUsers != null)
            {
                foreach (var user in _connectedUsers)
                {
                    try
                    {
                        user.Client?.Close();
                    }
                    catch { }
                }
            }

            await WriteLogAsync($"[{DateTime.Now:HH:mm:ss}] SERVER STOPPED");
        }
    }
}
