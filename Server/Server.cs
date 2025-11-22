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
                var lenBytes = new byte[4];
                while (!token.IsCancellationRequested)
                {
                    int read = 0;
                    while (read < 4)
                    {
                        int n = await clientStream.ReadAsync(lenBytes, read, 4 - read, token);
                        if (n == 0)
                            throw new IOException("Client disconnected while reading message length");
                        read += n;
                    }

                    int messageLength = BitConverter.ToInt32(lenBytes, 0);
                    if (messageLength <= 0)
                    {
                        Console.WriteLine($"Invalid message length: {messageLength}");
                        break;
                    }

                    byte[] messageBytes = new byte[messageLength];
                    int totalRead = 0;
                    while (totalRead < messageLength)
                    {
                        int n = await clientStream.ReadAsync(messageBytes, totalRead, messageLength - totalRead, token);
                        if (n == 0)
                            throw new IOException("Client disconnected while reading message body");
                        totalRead += n;
                    }

                    var json = Encoding.UTF8.GetString(messageBytes);
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
                var lenBytes = new byte[4];

                while (!token.IsCancellationRequested)
                {
                    int read = 0;
                    while (read < 4)
                    {
                        int n = await stream.ReadAsync(lenBytes, read, 4 - read, token);
                        if (n == 0)
                        {
                            throw new IOException("Client disconnected while reading message length");
                        }
                        read += n;
                    }

                    int messageLength = BitConverter.ToInt32(lenBytes, 0);
                    if (messageLength <= 0)
                    {
                        Console.WriteLine($"Invalid message length: {messageLength}");
                        break;
                    }

                    byte[] messageBytes = new byte[messageLength];
                    int totalRead = 0;
                    while (totalRead < messageLength)
                    {
                        int n = await stream.ReadAsync(messageBytes, totalRead, messageLength - totalRead, token);
                        if (n == 0)
                        {
                            throw new IOException("Client disconnected while reading message body");
                        }
                        totalRead += n;
                    }

                    var json = Encoding.UTF8.GetString(messageBytes);
                    Console.WriteLine("Received JSON: " + json);

                    var baseRequest = JsonSerializer.Deserialize<Request>(json);
                    if (baseRequest == null)
                    {
                        Console.WriteLine("Received invalid request (null baseRequest)");
                        continue;
                    }

                    switch (baseRequest.Type)
                    {
                        case RequestType.Disconnect:
                            MessageReceived.Invoke(this,
                                new MessageReceivedEventArgs { Message = $"[{DateTime.Now:HH:mm:ss}] [{baseRequest.Type}] {user.Login}" });
                            lock (connectedUsersLockObject)
                            {
                                _connectedUsers.Remove(user);
                            }
                            UserDisconnected?.Invoke(this, new UserDisconnectedEventArgs { User = user });
                            return;
                        case RequestType.GetWallets:
                            {
                                var req = JsonSerializer.Deserialize<GetWalletsRequest>(json);
                                var wallets = await _db.GetWalletsAsync(req.UserId);
                                var response = new GetWalletsResponse { Wallets = wallets };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.GetCurrencies:
                            {
                                var req = JsonSerializer.Deserialize<GetCurrenciesRequest>(json);
                                var currencies = await _db.GetCurrenciesAsync();
                                var response = new GetCurrenciesResponse { Currencies = currencies };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.AddWallet:
                            {
                                var req = JsonSerializer.Deserialize<AddWalletRequest>(json);
                                var res = await _db.AddWalletAsync(req.Name, req.Balance, req.UserId, req.CurrencyId);
                                var response = new AddWalletResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.DeleteWallet:
                            {
                                var req = JsonSerializer.Deserialize<DeleteWalletRequest>(json);
                                var res = await _db.DeleteWalletAsync(req.UserId, req.WalletName);
                                var response = new DeleteWalletResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.GetTransactionTypes:
                            {
                                var req = JsonSerializer.Deserialize<GetTransactionTypesRequest>(json);
                                var types = await _db.GetTransactionTypesAsync();
                                var response = new GetTransactionTypesResponse { TransactionTypes = types };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.GetCategories:
                            {
                                var req = JsonSerializer.Deserialize<GetCategoriesRequest>(json);
                                var cats = await _db.GetCategoriesAsync();
                                var response = new GetCategoriesResponse { Categories = cats };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.AddCategory:
                            {
                                var req = JsonSerializer.Deserialize<AddCategoryRequest>(json);
                                var res = await _db.AddCategoryAsync(req.Name, req.TransactionTypeId);
                                var response = new AddCategoryResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.DeleteCategory:
                            {
                                var req = JsonSerializer.Deserialize<DeleteCategoryRequest>(json);
                                var res = await _db.DeleteCategoryAsync(req.Name, req.TransactionTypeId);
                                var response = new DeleteCategoryResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.GetTransactions:
                            {
                                var req = JsonSerializer.Deserialize<GetTransactionsRequest>(json);
                                var tr = await _db.GetTransactionsAsync(req.UserId);
                                var response = new GetTransactionsResponse { Transactions = tr };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.AddTransaction:
                            {
                                var req = JsonSerializer.Deserialize<AddTransactionRequest>(json);
                                var res = await _db.AddTransactionAsync(
                                    req.WalletId,
                                    req.CurrencyId,
                                    req.CategoryId,
                                    req.Amount,
                                    req.DateTime,
                                    req.Note);
                                var response = new AddTransactionResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        case RequestType.DeleteTransaction:
                            {
                                var req = JsonSerializer.Deserialize<DeleteTransactionRequest>(json);
                                var transactionId = req.TransactionId;
                                var res = await _db.DeleteTransactionAsync(transactionId);
                                var response = new DeleteTransactionResponse { IsSuccess = res.IsSuccess, Message = res.Message };
                                await RespondToSenderAsync(user.Client, response, token);
                            }
                            break;
                        default:
                            Console.WriteLine($"Unknown request type: {baseRequest.Type}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnectedUserAsync: {ex}");
            }
        }

        private async Task RespondToSenderAsync(TcpClient sender, Response response, CancellationToken token)
        {
            Console.WriteLine("In RespondToSenderAsync");
            var json = JsonSerializer.Serialize(response);
            Console.WriteLine($"Json to send: {json}");
            var data = Encoding.UTF8.GetBytes(json);

            var lengthPrefix = BitConverter.GetBytes(data.Length);

            var stream = sender.GetStream();

            await stream.WriteAsync(lengthPrefix, 0, lengthPrefix.Length, token);
            await stream.WriteAsync(data, 0, data.Length, token);
            await stream.FlushAsync(token);
        }
        public async Task DisconnectUserAsync(ConnectedUser user)
        {
            try
            {
                lock (connectedUsersLockObject)
                {
                    _connectedUsers.Remove(user);
                }
                UserDisconnected.Invoke(this,
                    new UserDisconnectedEventArgs { User = user });
                var response = new DisconnectUserResponse { Message = "Server closed connection." };
                await RespondToSenderAsync(user.Client, response, _cts.Token);
                user.Client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DisconnectUserAsync: {ex.Message}");
            }
        }
        public async Task StopAsync()
        {
            var tasks = new List<Task>();
            foreach (var user in _connectedUsers.ToList())
            {
                tasks.Add(DisconnectUserAsync(user));
            }
            await Task.WhenAll(tasks);
            _cts.Cancel();
            _server.Stop();
        }
    }
}
