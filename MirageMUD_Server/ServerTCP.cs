using System;
using System.Net.Sockets;
using System.Net;
using Bindings;

namespace MirageMUD_Server
{
    internal class ServerTCP
    {
        public static Client[] Clients = new Client[Constants.MAX_PLAYERS];
        public TcpListener ServerSocket;

        public void InitialiseNetwork()
        {
            Console.WriteLine("Initialising server network...");
            ServerSocket = new TcpListener(IPAddress.Any, 7777);
            ServerSocket.Start();
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }

        private void OnClientConnect(IAsyncResult ar)
        {
            TcpClient client = ServerSocket.EndAcceptTcpClient(ar);
            client.NoDelay = false;
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);

            for(int i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                if (Clients[i].Socket == null)
                {
                    Clients[i].Socket = client;
                    Clients[i].Index = i;
                    Clients[i].IP = client.Client.RemoteEndPoint.ToString();
                    Clients[i].Start();
                    Console.WriteLine("Connection received from " + Clients[i].IP + ".");
                    return;
                }
            }
        }
    }
}
