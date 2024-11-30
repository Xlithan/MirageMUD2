using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bindings;

namespace MirageMUD_Client.Source.Network
{
    internal class ClientWebSock
    {
        private System.Net.WebSockets.ClientWebSocket _webSocket;
        private CHandleData _handleData;
        private byte[] _asyncBuff;

        private bool _connecting;
        private bool _connected;

        public async Task ConnectToServerAsync()
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open || _connected)
                return;

            if (_webSocket != null)
                _webSocket.Dispose();

            _webSocket = new System.Net.WebSockets.ClientWebSocket();
            _handleData = new CHandleData();
            _asyncBuff = new byte[8192];
            _connecting = true;

            try
            {
                // Connect to WebSocket server
                Uri serverUri = new Uri("ws://127.0.0.1:7777");
                await _webSocket.ConnectAsync(serverUri, CancellationToken.None);
                _connected = true;
                _connecting = false;

                Console.WriteLine("Connected to WebSocket server.");

                // Start receiving messages
                await StartReceivingAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                _connected = false;
                _connecting = false;
            }
        }

        private async Task StartReceivingAsync()
        {
            while (_webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var buffer = new ArraySegment<byte>(_asyncBuff);
                    WebSocketReceiveResult result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("WebSocket connection closed by the server.");
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
                        _connected = false;
                        break;
                    }

                    if (result.MessageType == WebSocketMessageType.Binary && result.Count > 0)
                    {
                        byte[] messageBytes = buffer.Array.Take(result.Count).ToArray();
                        _handleData.HandleMessages(messageBytes);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving data: {ex.Message}");
                    _connected = false;
                    break;
                }
            }
        }

        public async Task SendDataAsync(byte[] data)
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                try
                {
                    await _webSocket.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }
        }

        public async Task SendLoginAsync(string name, string pass)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddInteger((int)ClientPackets.CLogin);
                buffer.AddString(name);
                buffer.AddString(pass);
                buffer.AddByte(1);
                buffer.AddByte(0);
                buffer.AddByte(0);

                await SendDataAsync(buffer.ToArray());
            }
        }

        public async Task SendNewAccountAsync(string name, string pass)
        {
            using (PacketBuffer buffer = new PacketBuffer())
            {
                buffer.AddInteger((int)ClientPackets.CNewAccount);
                buffer.AddString(name);
                buffer.AddString(pass);

                await SendDataAsync(buffer.ToArray());
            }
        }
    }
}