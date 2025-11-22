using Client.Events;
using Shared.Requests;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class Client: IDisposable
    {
        TcpClient _client;
        NetworkStream _stream;
        CancellationTokenSource _cts;
        private bool _isDisposed;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public event EventHandler<DisconnectMessageReceivedEventArgs> DisconnectMessageReceived;
        public event EventHandler<UserVerifiedEventArgs> UserVerified;
        public event EventHandler<WalletsReceivedEventArgs> WalletsReceived;
        public event EventHandler<CurrenciesReceivedEventArgs> CurrenciesReceived;
        public event EventHandler<CategoriesReceivedEventArgs> CategoriesReceived;
        public event EventHandler<TransactionTypesReceivedEventArgs> TransactionTypesReceived;
        public event EventHandler<TransactionsReceivedEventArgs> TransactionsReceived;

        const int BUFFER_SIZE = 2048;

        public IPEndPoint? EndPoint { get; set; }
        public TcpClient Self => _client;
        public Client(string address, int port)
        {
            EndPoint = new IPEndPoint(IPAddress.Parse(address), port);
        }
        public async Task ConnectAsync()
        {
            try
            {
                _client = new TcpClient();
                _cts = new CancellationTokenSource();

                await _client.ConnectAsync(EndPoint);

                if (_client.Connected)
                {
                    _stream = _client.GetStream();
                    _ = HandleConnection(_cts.Token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ConnectAsync: {ex.Message}");
            }
        }
        private async Task HandleConnection(CancellationToken token)
        {
            try
            {
                var stream = _stream;
                var lenBytes = new byte[4];

                while (!token.IsCancellationRequested)
                {
                    int read = 0;
                    while (read < 4)
                    {
                        int n = await stream.ReadAsync(lenBytes, read, 4 - read, token);
                        if (n == 0)
                        {
                            throw new IOException("Server closed connection while reading message length");
                        }
                        read += n;
                    }

                    int messageLength = BitConverter.ToInt32(lenBytes, 0);
                    if (messageLength <= 0)
                    {
                        Console.WriteLine($"Invalid message length from server: {messageLength}");
                        break;
                    }

                    byte[] messageBytes = new byte[messageLength];
                    int totalRead = 0;
                    while (totalRead < messageLength)
                    {
                        int n = await stream.ReadAsync(messageBytes, totalRead, messageLength - totalRead, token);
                        if (n == 0)
                        {
                            throw new IOException("Server disconnected while reading message body");
                        }
                        totalRead += n;
                    }

                    var json = Encoding.UTF8.GetString(messageBytes);
                    Console.WriteLine("Received from server JSON: " + json);

                    var baseResponse = JsonSerializer.Deserialize<Response>(json);
                    if (baseResponse == null)
                    {
                        Console.WriteLine("Received invalid response (null baseResponse)");
                        continue;
                    }

                    switch (baseResponse.Type)
                    {
                        case ResponseType.Reg:
                            var reg = JsonSerializer.Deserialize<RegistrationResponse>(json);
                            if (reg != null)
                                await HandleRegistrationResponseAsync(reg, token);
                            break;
                        case ResponseType.Auth:
                            var auth = JsonSerializer.Deserialize<AuthorizationResponse>(json);
                            if (auth != null)
                                await HandleAuthorizationResponseAsync(auth, token);
                            break;
                        case ResponseType.AddWallet:
                            var aw = JsonSerializer.Deserialize<AddWalletResponse>(json);
                            if (aw != null) 
                                await HandleAddWalletsResponseAsync(aw, token);
                            break;
                        case ResponseType.GetWallets:
                            var gw = JsonSerializer.Deserialize<GetWalletsResponse>(json);
                            if (gw != null) 
                                await HandleGetWalletsResponseAsync(gw, token);
                            break;
                        case ResponseType.DeleteWallet:
                            var dw = JsonSerializer.Deserialize<DeleteWalletResponse>(json);
                            if (dw != null)
                                await HandleDeleteWalletResponseAsync(dw, token);
                            break;
                        case ResponseType.GetCurrencies:
                            var gc = JsonSerializer.Deserialize<GetCurrenciesResponse>(json);
                            if (gc != null)
                                await HandleGetCurrenciesResponseAsync(gc, token);
                            break;
                        case ResponseType.GetCategories:
                            var gcat = JsonSerializer.Deserialize<GetCategoriesResponse>(json);
                            if (gcat != null)
                                await HandleGetCategoriesResponseAsync(gcat, token);
                            break;
                        case ResponseType.AddCategory:
                            var ac = JsonSerializer.Deserialize<AddCategoryResponse>(json);
                            if (ac != null)
                                await HandleAddCategoryResponseAsync(ac, token);
                            break;
                        case ResponseType.DeleteCategory:
                            var dcat = JsonSerializer.Deserialize<DeleteCategoryResponse>(json);
                            if (dcat != null) 
                                await HandleDeleteCategoryResponseAsync(dcat, token);
                            break;
                        case ResponseType.GetTransactionTypes:
                            var tt = JsonSerializer.Deserialize<GetTransactionTypesResponse>(json);
                            if (tt != null)
                                await HandleGetTransactionTypesResponseAsync(tt, token);
                            break;
                        case ResponseType.GetTransactions:
                            var gtr = JsonSerializer.Deserialize<GetTransactionsResponse>(json);
                            if (gtr != null) 
                                await HandleGetTransactionsResponseAsync(gtr, token);
                            break;
                        case ResponseType.AddTransaction:
                            var atr = JsonSerializer.Deserialize<AddTransactionResponse>(json);
                            if (atr != null) 
                                await HandleAddTransactionResponseAsync(atr, token);
                            break;
                        case ResponseType.Disconnect:
                            var dis = JsonSerializer.Deserialize<DisconnectUserResponse>(json);
                            if (dis != null) 
                                await HandleDisconnectResponseAcync(dis, token);
                            break;
                        case ResponseType.DeleteTransaction:
                            var dtr = JsonSerializer.Deserialize<DeleteTransactionResponse>(json);
                            if (dtr != null)
                                await HandleDeleteTransactionResponseAsync(dtr, token);
                            break;
                        default:
                            Console.WriteLine($"Unknown response type: {baseResponse.Type}");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnection: {ex}");
            }
        }
        private async Task HandleAuthorizationResponseAsync(AuthorizationResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
                UserVerified.Invoke(this,
                    new UserVerifiedEventArgs
                    {
                        IsVerified = response.IsSuccess,
                        UserId = response.UserId,
                        UserLogin = response.UserLogin,
                        UserConnectionTime = response.UserConnectionTime
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAuthorizationResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleRegistrationResponseAsync(RegistrationResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleRegistrationResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleGetWalletsResponseAsync(GetWalletsResponse response, CancellationToken token)
        {
            try
            {
                Console.WriteLine(response.Wallets.Count);
                WalletsReceived.Invoke(this,
                    new WalletsReceivedEventArgs { Wallets = response.Wallets });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGetWalletsResponse: {ex.Message}");
            }
        }
        private async Task HandleDeleteWalletResponseAsync(DeleteWalletResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleDeleteWalletResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleGetCurrenciesResponseAsync(GetCurrenciesResponse response, CancellationToken token)
        {
            try
            {
                CurrenciesReceived.Invoke(this,
                    new CurrenciesReceivedEventArgs { Currencies = response.Currencies });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGetCurrenciesResponse: {ex.Message}");
            }
        }
        private async Task HandleGetCategoriesResponseAsync(GetCategoriesResponse response, CancellationToken token)
        {
            try
            {
                CategoriesReceived.Invoke(this,
                    new CategoriesReceivedEventArgs { Categories = response.Categories });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGetCategoriesResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleGetTransactionTypesResponseAsync(GetTransactionTypesResponse response, CancellationToken token)
        {
            try
            {
                TransactionTypesReceived.Invoke(this,
                    new TransactionTypesReceivedEventArgs { TransactionTypes = response.TransactionTypes });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGetTransactionTypesResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleGetTransactionsResponseAsync(GetTransactionsResponse response, CancellationToken token)
        {
            try
            {
                TransactionsReceived.Invoke(this,
                    new TransactionsReceivedEventArgs { Transactions = response.Transactions });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleGetTransactionsResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleAddWalletsResponseAsync(AddWalletResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAddWalletsResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleAddTransactionResponseAsync(AddTransactionResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAddTransactionResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleAddCategoryResponseAsync(AddCategoryResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleAddCategoryResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleDeleteCategoryResponseAsync(DeleteCategoryResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleDeleteCategoryResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleDeleteTransactionResponseAsync(DeleteTransactionResponse response, CancellationToken token)
        {
            try
            {
                MessageReceived.Invoke(this,
                    new MessageReceivedEventArgs { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleDeleteTransactionResponseAsync: {ex.Message}");
            }
        }
        private async Task HandleDisconnectResponseAcync(DisconnectUserResponse response, CancellationToken token)
        {
            try
            {
                DisconnectMessageReceived.Invoke(this,
                    new DisconnectMessageReceivedEventArgs { Message = response.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleDisconnectResponseAcync: {ex.Message}");
            }
        }
        public async Task SendRequestAsync(Request request, CancellationToken token)
        {
            try
            {
                if (_client == null)
                    return;

                var json = JsonSerializer.Serialize(request);
                var data = Encoding.UTF8.GetBytes(json);

                var prefixLength = BitConverter.GetBytes(data.Length);

                await _stream.WriteAsync(prefixLength, 0, prefixLength.Length, token);
                await _stream.WriteAsync(data, 0, data.Length, token);
                await _stream.FlushAsync(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendRequestAsync: {ex.Message}");
            }
        }
        public async Task DisconnectAsync()
        {
            try
            {
                var request = new DisconnectRequest();
                await SendRequestAsync(request, _cts.Token);
                Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DisconnectAsync: {ex.Message}");
            }
        }
        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            try
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _stream?.Close();
                _stream?.Dispose();
                _client?.Close();
                _client?.Dispose();
            }
            catch { }
        }
    }
}
