using System;
using System.Net.Sockets;
using System.Net;
using Bindings;
using System.Xml.Linq;
using System.IO;
using MirageMUD_Server.Globals;

namespace MirageMUD_Server.Network
{
    internal class ServerTCP
    {
        public static int MaxClients = 100;
        private static HttpListener _listener;

        public static void InitialiseNetwork(int port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://*:{port}/");
            _listener.Start();

            Console.WriteLine($"WebSocket Server started on port {port}");
            Task.Run(() => AcceptClientsAsync());
        }

        private static async Task AcceptClientsAsync()
        {
            while (true)
            {
                var context = await _listener.GetContextAsync();

                if (context.Request.IsWebSocketRequest)
                {
                    var webSocketContext = await context.AcceptWebSocketAsync(null);
                    int connectionID = GetAvailableClientID();
                    var client = new Client(connectionID, webSocketContext.WebSocket);

                    ServerTCP.OnClientConnect(connectionID, client);
                    client.ReceiveDataAsync();
                }
                else
                {
                    context.Response.StatusCode = 400; // Bad Request
                    context.Response.Close();
                }
            }
        }

        private static int GetAvailableClientID()
        {
            // Placeholder logic for assigning connection IDs
            return new Random().Next(1, MaxClients);
        }

        public static void OnClientConnect(int connectionID, Client client)
        {
            Console.WriteLine($"Client {connectionID} connected.");
            // Add to client management logic here if necessary
        }

        public static void DisconnectClient(int connectionID)
        {
            Console.WriteLine($"Client {connectionID} disconnected.");
            // Handle client removal here if necessary
        }

        public void SendDataTo(int Index, byte[] data)
        {
            // Create a new packet buffer and add the data
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);

            // Write the data to the network stream
            //Clients[Index].myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);

            buffer.Dispose();
        }

        public void AlertMsg(int Index, string msg)
        {
            // Create a new packet buffer for the account creation data
            PacketBuffer buffer = new PacketBuffer();

            // Add the new account request packet identifier and the account details
            buffer.AddInteger((int)ServerPackets.SAlertMsg);
            buffer.AddString(msg);

            // Send the new account data to the server
            SendDataTo(Index, buffer.ToArray());

            // Dispose of the buffer after sending
            buffer.Dispose();
        }

        public void SendChars(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SAllChars);
            buffer.AddString(STypes.Player[Index].Login);
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                buffer.AddString(STypes.Player[Index].Character[i].Name);
            }

            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();
        }
    }
}