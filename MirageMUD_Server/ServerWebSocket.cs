using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Bindings;

namespace MirageMUD_Server
{
    internal class ServerWebSocket
    {
        public static WSClient[] Clients = new WSClient[Constants.MAX_PLAYERS];
        private HttpListener serverListener;

        public void InitialiseNetwork()
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.initialising_server_network"));

            // Create and start the HTTP listener to accept WebSocket connections
            serverListener = new HttpListener();
            serverListener.Prefixes.Add("http://127.0.0.1:7777/"); // Set the URI prefix for the server
            serverListener.Start();

            Console.WriteLine("WebSocket server started... Waiting for connections.");

            // Start accepting WebSocket connections asynchronously
            AcceptWebSocketConnections();
        }

        private async void AcceptWebSocketConnections()
        {
            while (true)
            {
                // Wait for an incoming WebSocket connection
                HttpListenerContext context = await serverListener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    // Accept the WebSocket connection
                    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);

                    // Handle the WebSocket connection
                    await HandleWebSocketConnection(webSocketContext, context);
                }
                else
                {
                    // If it's not a WebSocket request, close the connection
                    context.Response.StatusCode = 400; // Bad Request
                    context.Response.Close();
                }
            }
        }

        private async Task HandleWebSocketConnection(HttpListenerWebSocketContext webSocketContext, HttpListenerContext context)
        {
            WebSocket webSocket = webSocketContext.WebSocket;

            // Get the client IP from the HttpListenerContext (not WebSocketContext)
            string clientIp = context.Request.RemoteEndPoint?.Address.ToString();

            // Create a new SHandleData object (replace with actual handling data logic)
            SHandleData sHandleData = new SHandleData();

            // Find the first available slot for the new client
            for (int i = 1; i < Constants.MAX_PLAYERS; i++)
            {
                if (Clients[i] == null)
                {
                    // Create and assign a new WSClient object
                    Clients[i] = new WSClient(sHandleData)
                    {
                        Index = i,
                        IP = clientIp,
                        Socket = webSocket // Assign the WebSocket
                    };

                    // Start handling communication with this client
                    await Clients[i].Start(webSocket);  // Assuming 'Start' handles the communication
                    break;
                }
            }
        }
    }
}