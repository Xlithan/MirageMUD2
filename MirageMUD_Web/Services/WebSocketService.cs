using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MirageMUD_Web.Services
{
    public class WebSocketService
    {
        public async Task PingServerAsync(Uri serverUri)
        {
            using (var client = new ClientWebSocket())
            {
                try
                {
                    // Connect to the server
                    await client.ConnectAsync(serverUri, CancellationToken.None);

                    // Send a ping message
                    var pingMessage = Encoding.UTF8.GetBytes("ping");
                    await client.SendAsync(new ArraySegment<byte>(pingMessage), WebSocketMessageType.Text, true, CancellationToken.None);

                    // Wait for a response
                    var buffer = new byte[1024];
                    var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    var responseMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    if (responseMessage == "pong")
                        Console.WriteLine("Server is online and responsive!");
                    else
                        Console.WriteLine("Unexpected response from server.");

                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Ping check complete", CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to ping the server: {ex.Message}");
                }
            }
        }
    }
}
