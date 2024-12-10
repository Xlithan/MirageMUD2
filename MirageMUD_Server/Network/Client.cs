using System.Net.Sockets;
using System.Net.WebSockets;

namespace MirageMUD_Server.Network
{
    internal class Client
    {
        private readonly SHandleData _sHandleData;
        private readonly WebSocket _webSocket;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly CancellationToken _cancellationToken;

        public int Index { get; }
        public string IP { get; }
        public bool Closing { get; private set; }

        public Client(int index, WebSocket webSocket)
        {
            Index = index;
            _webSocket = webSocket;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        public async Task ReceiveDataAsync()
        {
            try
            {
                byte[] buffer = new byte[4096];
                while (_webSocket.State == WebSocketState.Open && !Closing)
                {
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await DisconnectClient();
                        return;
                    }

                    if (result.MessageType == WebSocketMessageType.Binary)
                    {
                        byte[] data = new byte[result.Count];
                        Array.Copy(buffer, data, result.Count);
                        _sHandleData.HandleMessages(Index, data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data from client {Index}: {ex.Message}");
                await DisconnectClient();
            }
        }

        public async Task SendDataAsync(byte[] data)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                try
                {
                    await _webSocket.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Binary, true, _cancellationToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data to client {Index}: {ex.Message}");
                }
            }
        }

        public async Task DisconnectClient()
        {
            if (Closing) return;

            Closing = true;
            Console.WriteLine($"Client {Index} disconnected.");

            try
            {
                if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.CloseReceived)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing connection", _cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing WebSocket for client {Index}: {ex.Message}");
            }
            finally
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}