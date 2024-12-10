using System.Net;
using System.Net.WebSockets;
using System.Text;
using Bindings;
using MirageMUD_Server.Globals;

namespace MirageMUD_Server.Network
{
    internal class ServerWebSocket
    {
        private readonly int _port;

        public static Client[] Clients = new Client[Constants.MAX_PLAYERS];

        public ServerWebSocket()
        {
            _port = 7777;
        }

        public async Task StartAsync()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{_port}/");
            listener.Start();

            Console.WriteLine($"WebSocket server running on port {_port}...");

            while (true)
            {
                var httpContext = await listener.GetContextAsync();

                if (httpContext.Request.IsWebSocketRequest)
                {
                    var webSocketContext = await httpContext.AcceptWebSocketAsync(null);
                    var webSocket = webSocketContext.WebSocket;

                    for (int i = 0; i < Constants.MAX_PLAYERS; i++)
                    {
                        if (Clients[i]?.WebSocket == null)
                        {
                            Clients[i] = new Client(i, webSocket);
                            Console.WriteLine($"Client {Clients[i].Index} connected.");
                            _ = Clients[i].HandleCommunication();
                            break;
                        }
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    httpContext.Response.Close();
                }
            }
        }

        public async Task SendDataTo(int Index, byte[] data)
        {
            if (Clients[Index]?.WebSocket != null && Clients[Index].WebSocket.State == WebSocketState.Open)
            {
                try
                {
                    await Clients[Index].WebSocket.SendAsync(
                        new ArraySegment<byte>(data),
                        WebSocketMessageType.Binary,
                        true,
                        CancellationToken.None
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send data to client {Index}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Client {Index} WebSocket is not open.");
            }
        }

        public async Task AlertMsg(int Index, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await SendDataTo(Index, data);
        }

        public async Task SendChars(int Index)
        {
            // Prepare the data to send
            var data = new List<byte>();

            // Add the packet identifier
            data.Add((byte)ServerPackets.SAllChars);

            // Add the player's login name
            data.AddRange(Encoding.UTF8.GetBytes(STypes.Player[Index].Login));

            // Add character names
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                var charNameBytes = Encoding.UTF8.GetBytes(STypes.Player[Index].Character[i].Name);
                data.AddRange(charNameBytes);
            }

            // Send data asynchronously
            await SendDataTo(Index, data.ToArray());
        }
    }
}