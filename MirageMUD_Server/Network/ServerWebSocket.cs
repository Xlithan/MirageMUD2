﻿using Bindings;
using MirageMUD_Server.Globals;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace MirageMUD_Server.Network
{
    internal class ServerWebSocket
    {
        public static int MaxClients = 100;
        private static HttpListener _listener;
        public static Dictionary<int, Client> Clients = new Dictionary<int, Client>();

        public static void InitialiseNetwork()
        {
            int port = 7777;

            try
            {
                _listener = new HttpListener();
                _listener.Prefixes.Add($"http://*:{port}/");
                _listener.Start();

                Console.WriteLine($"Server listening on http://*:7777/");

                while (true)
                {
                    var context = _listener.GetContext();
                    var response = context.Response;
                    var responseString = "<html><body>Server Running</body></html>";
                    var buffer = Encoding.UTF8.GetBytes(responseString);

                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();

                    Console.WriteLine($"Debug Check");
                }
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine($"HttpListener Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access Denied: {ex.Message}");
            }

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

                    Clients[connectionID] = client;
                    OnClientConnect(connectionID, client);

                    _ = Task.Run(() => client.ReceiveDataAsync());
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
            for (int i = 1; i <= MaxClients; i++)
            {
                if (!Clients.ContainsKey(i))
                    return i;
            }
            throw new Exception("No available client IDs.");
        }

        public static void OnClientConnect(int connectionID, Client client)
        {
            Console.WriteLine($"Client {connectionID} connected.");
        }

        public static async Task DisconnectClient(int connectionID)
        {
            if (Clients.ContainsKey(connectionID))
            {
                await Clients[connectionID].DisconnectClient();  // Call async method
                Clients.Remove(connectionID);
                Console.WriteLine($"Client {connectionID} disconnected.");
            }
        }

        public static async Task SendDataTo(int connectionID, byte[] data)
        {
            if (Clients.ContainsKey(connectionID))
            {
                var client = Clients[connectionID];
                await client.SendDataAsync(data);
            }
        }

        public async Task AlertMsg(int connectionID, string msg)
        {
            // Construct the message as a byte array
            byte[] packetType = GetBytes((int)ServerPackets.SAlertMsg);
            byte[] messageBytes = GetBytes(msg);

            // Combine everything into a single byte array
            byte[] data = Combine(packetType, messageBytes);

            await SendDataTo(connectionID, data);
        }

        public async Task SendChars(int connectionID)
        {
            var player = STypes.Player[connectionID];

            byte[] packetType = GetBytes((int)ServerPackets.SAllChars);
            byte[] loginBytes = GetBytes(player.Login);

            var charNamesBytes = new List<byte>();
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                charNamesBytes.AddRange(GetBytes(player.Character[i].Name));
            }

            // Combine everything into a single byte array
            byte[] data = Combine(packetType, loginBytes, charNamesBytes.ToArray());

            await SendDataTo(connectionID, data);
        }

        private byte[] GetBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        private byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        private byte[] Combine(params byte[][] arrays)
        {
            return arrays.SelectMany(arr => arr).ToArray();
        }
    }
}