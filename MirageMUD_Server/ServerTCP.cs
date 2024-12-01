using System;
using System.Net.Sockets;
using System.Net;
using Bindings;

namespace MirageMUD_Server
{
    internal class ServerTCP
    {
        // Array to hold client connections
        public static Client[] Clients = new Client[Constants.MAX_PLAYERS];

        // TcpListener to listen for incoming TCP client connections
        public TcpListener ServerSocket;

        // Initializes the network listener and begins accepting client connections
        public void InitialiseNetwork()
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.initialising_server_network"));
            ServerSocket = new TcpListener(IPAddress.Any, 7777);
            ServerSocket.Start();
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }

        // Callback function to handle incoming client connections
        private void OnClientConnect(IAsyncResult ar)
        {
            // Get the connecting client
            var connectingTcpClient = ServerSocket.EndAcceptTcpClient(ar);

            // Determine the IP of the incoming connection
            var sourceIp = connectingTcpClient.Client.RemoteEndPoint?.ToString();

            Console.WriteLine(string.Format(TranslationManager.Instance.GetTranslation("server.connection_received"), sourceIp));

            // Disable Nagle's algorithm to improve performance for small messages
            connectingTcpClient.NoDelay = false;

            // For every client slot
            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                // If the client slot has a null socket
                if (Clients[i].Socket == null)
                {
                    // Assign the incoming connection to this slot
                    Clients[i].Socket = connectingTcpClient;
                    Clients[i].Index = i;
                    Clients[i].IP = sourceIp;

                    // Start receiving data from the client
                    Clients[i].Start();

                    // Break out of the for loop now that the client has been assigned successfully
                    break;
                }
            }

            // Start waiting for the next connection to come in
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }
    }
}