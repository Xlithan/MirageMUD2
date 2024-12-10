using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MirageMUD_Server.Network
{
    internal class Client
    {
        public int Index { get; private set; }
        public WebSocket WebSocket { get; set; }

        public Client(int index, WebSocket webSocket)
        {
            Index = index;
            WebSocket = webSocket;
        }

        public async Task HandleCommunication()
        {
            var buffer = new byte[4096];

            try
            {
                while (WebSocket.State == WebSocketState.Open)
                {
                    var result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);
                        return;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Received message: {message}");

                    var response = Encoding.UTF8.GetBytes($"Echo: {message}");
                    await WebSocket.SendAsync(new ArraySegment<byte>(response), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error communicating with client {Index}: {ex.Message}");
                return;
            }
        }
    }
}