using Bindings;
using MirageMUD_Server.PlayerData;
using MirageMUD_Server.Types;
using MirageMUD_Server.Utilities;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace MirageMUD_Server.Network
{
    internal class ServerTCP
    {
        private static ServerTCP instance;
        public static ServerTCP Instance => instance ??= new ServerTCP();  // Singleton pattern for ServerTCP instance

        // Array to hold client connections
        public static Client[] Clients = new Client[Constants.MAX_PLAYERS];

        // TcpListener to listen for incoming TCP client connections
        public TcpListener ServerSocket;

        // Thread-safe dictionary for storing temporary stats
        public static ConcurrentDictionary<int, int[]> TempStats = new ConcurrentDictionary<int, int[]>();

        // Initializes the network listener and begins accepting client connections
        public void InitialiseNetwork()
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.initialising_server_network"));
            ServerSocket = new TcpListener(IPAddress.Any, 7777);  // Listen on all IP addresses, port 7777
            ServerSocket.Start();  // Start the TCP listener
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);  // Begin accepting incoming client connections asynchronously
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
                    Clients[i].Index = i;  // Assign the index of the client
                    Clients[i].IP = sourceIp;  // Store the IP address of the client

                    // Start receiving data from the client
                    Clients[i].Start();

                    // Break out of the for loop now that the client has been assigned successfully
                    break;
                }
            }

            // Start waiting for the next connection to come in
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }

        // Sends data to the specified client index
        public void SendDataTo(int Index, byte[] data)
        {
            // Create a new packet buffer and add the data
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);

            // Write the data to the network stream
            Clients[Index].myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends an alert message to the specified client
        public void AlertMsg(int Index, string msg)
        {
            // Create a new packet buffer for the alert message
            PacketBuffer buffer = new PacketBuffer();

            // Add the alert message packet identifier and the message content
            buffer.AddInteger((int)ServerPackets.SAlertMsg);
            buffer.AddString(msg);

            // Send the alert message to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends character data to the specified client
        public void SendChars(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SAllChars);  // Add packet identifier
            buffer.AddString(STypes.Player[Index].Login);  // Add login name

            // Add character details for each character
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                buffer.AddString(STypes.Player[Index].Character[i].Name);  // Character name
                buffer.AddInteger(STypes.Player[Index].Character[i].Level);  // Character level
                buffer.AddString(Classes.GetClassName(STypes.Player[Index].Character[i].Class));  // Character class
                buffer.AddString(Races.GetRaceName(STypes.Player[Index].Character[i].Race));  // Character race
                buffer.AddInteger(STypes.Player[Index].Character[i].Avatar);  // Character avatar
                buffer.AddInteger(STypes.Player[Index].Character[i].Gender);  // Character gender
            }

            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends account creation success to the specified client
        public void SendAccountCreated(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SAccountCreated);  // Add packet identifier for account creation success

            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends character creation success to the specified client
        public void SendCharCreated(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SNewCharOk);  // Add packet identifier for character creation success

            // Add character details for each character
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                buffer.AddString(STypes.Player[Index].Character[i].Name);  // Character name
                buffer.AddInteger(STypes.Player[Index].Character[i].Level);  // Character level
                buffer.AddString(Classes.GetClassName(STypes.Player[Index].Character[i].Class));  // Character class
                buffer.AddString(Races.GetRaceName(STypes.Player[Index].Character[i].Race));  // Character race
                buffer.AddInteger(STypes.Player[Index].Character[i].Avatar);  // Character avatar
                buffer.AddInteger(STypes.Player[Index].Character[i].Gender);  // Character gender
            }

            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends a stat reroll to the specified client
        public void SendReRoll(int Index)
        {
            StatRoller statRoller = new StatRoller();

            // Generate a random distribution of stats
            int[] stats = statRoller.GenerateRandomStats();

            // Store the stats temporarily for the player
            TempStats[Index] = stats;

            // Prepare the packet to send the stats to the client
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddInteger((int)ServerPackets.SReRoll);  // Add packet identifier for stat reroll

            // Add each stat value to the buffer
            buffer.AddInteger(stats[0]);  // Strength
            buffer.AddInteger(stats[1]);  // Intelligence
            buffer.AddInteger(stats[2]);  // Dexterity
            buffer.AddInteger(stats[3]);  // Constitution
            buffer.AddInteger(stats[4]);  // Wisdom
            buffer.AddInteger(stats[5]);  // Charisma

            // Send the data to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends race options to the specified client
        public void SendRaces(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SRaces);  // Add packet identifier for races

            // Get the list of races and add them to the buffer
            foreach (var race in Races.GetAllRaces())
            {
                buffer.AddString(race.Name);  // Add each race's name to the buffer
            }

            // Send the buffer data to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Sends class options to the specified client
        public void SendClasses(int Index)
        {
            PacketBuffer buffer = new PacketBuffer();

            buffer.AddInteger((int)ServerPackets.SClasses);  // Add packet identifier for classes

            // Get the list of classes and add them to the buffer
            foreach (var playerClass in Classes.GetAllClasses())
            {
                buffer.AddString(playerClass.Name);  // Add each class's name to the buffer
            }

            // Send the buffer data to the client
            SendDataTo(Index, buffer.ToArray());

            buffer.Dispose();  // Dispose of the buffer after sending
        }

        // Checks if the username is already logged in
        public bool IsLoggedIn(string username)
        {
            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                // If the username matches any existing login, return true
                if (string.Equals(STypes.Player[i].Login, username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;  // Duplicate found, return true
                }
            }
            return false;  // No duplicate found, return false
        }
    }
}