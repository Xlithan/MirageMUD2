using System;
using System.Net.Sockets;
using System.Net;
using Bindings;
using System.Xml.Linq;
using System.IO;
using MirageMUD_Server.Types;
using MirageMUD_Server.Utilities;
using MirageMUD_Server.PlayerData;

namespace MirageMUD_Server.Network
{
    internal class ServerTCP
    {
        public static ServerTCP instance = new ServerTCP();

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

        public void SendDataTo(int Index, byte[] data)
        {
            // Create a new packet buffer and add the data
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);

            // Write the data to the network stream
            Clients[Index].myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);

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
        public void SendReRoll(int Index)
        {
            StatRoller statRoller = new StatRoller();

            // Generate a random distribution of stats.
            int[] stats = statRoller.GenerateRandomStats();

            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SReRoll);

            // Add each stat value to the buffer.
            buffer.AddInteger(stats[0]); // Strength
            buffer.AddInteger(stats[1]); // Intelligence
            buffer.AddInteger(stats[2]); // Dexterity
            buffer.AddInteger(stats[3]); // Constitution
            buffer.AddInteger(stats[4]); // Wisdom
            buffer.AddInteger(stats[5]); // Charisma

            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();
        }

        public void SendRaces(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            // Indicate the type of packet being sent
            buffer.AddInteger((int)ServerPackets.SRaces);

            // Get the list of races from the race dictionary or collection
            foreach (var race in Races.GetAllRaces())
            {
                buffer.AddString(race.Name); // Add each race's name to the buffer
            }

            // Send the buffer data to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();
        }
        public void SendClasses(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            // Indicate the type of packet being sent
            buffer.AddInteger((int)ServerPackets.SClasses);

            // Get the list of classes from the class dictionary or collection
            foreach (var playerClass in Classes.GetAllClasses())
            {
                buffer.AddString(playerClass.Name); // Add each class's name to the buffer
            }

            // Send the buffer data to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();
        }

    }
}