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
        public event EventHandler<UserVerifiedEventArgs> UserVerified;

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
                var buffer = new byte[BUFFER_SIZE];
                while (!token.IsCancellationRequested)
                {
                    var size = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (size == 0)
                        break;

                    var json = Encoding.UTF8.GetString(buffer, 0, size);
                    var baseResponse = JsonSerializer.Deserialize<Response>(json);

                    if (baseResponse?.Type == ResponseType.Reg)
                    {
                        var concreteResponse = JsonSerializer.Deserialize<RegistrationResponse>(json);
                        _ = HandleRegistrationResponseAsync(concreteResponse, token);
                    }
                    if (baseResponse?.Type == ResponseType.Auth)
                    {
                        var concreteResponse = JsonSerializer.Deserialize<AuthorizationResponse>(json);
                        _ = HandleAuthorizationResponseAsync(concreteResponse, token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HandleConnection: {ex.Message}");
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
                        UserLogin = response.UserLogin
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
        public async Task SendRequestAsync(Request request, CancellationToken token)
        {
            try
            {
                if (_client == null)
                    return;

                var json = JsonSerializer.Serialize(request);
                var data = Encoding.UTF8.GetBytes(json);

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
