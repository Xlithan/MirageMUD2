using System;
using System.Net.Sockets;
using System.Net;
using Bindings;

namespace MirageMUD_Server
{
    internal class General
    {
        private ServerWebSocket serverWS;

        /// <summary>
        /// The object that will handle all data.
        /// Readonly because we dont want this to change, we want a single instance.
        /// </summary>
        private readonly SHandleData _sHandleData;

        /// <summary>
        /// Constructor for the General class.
        /// Creates a new SHandleData internally and calls InitialiseMessages on it.
        /// </summary>
        public General()
        {
            _sHandleData = new SHandleData();
            _sHandleData.InitialiseMessages();
        }

        public void InitialiseServer()
        {
            serverWS = new ServerWebSocket(); // Assuming ServerWebSocket is now handling WebSocket connections

            // Initialize the WSClient array and other necessary data structures
            for (int i = 1; i < Constants.MAX_PLAYERS; i++)
            {
                // Create a new WSClient object and pass in the data handler object for it to use
                var newClient = new WSClient(_sHandleData);

                // Add the newly created WebSocket client to the Clients array
                ServerWebSocket.Clients[i] = newClient;
                Types.Player[i] = new Types.AccountStruct();
            }

            // Initialize WebSocket server (the server will now accept WebSocket connections)
            serverWS.InitialiseNetwork();  // Assuming this method starts the WebSocket listener and awaits connections

            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));
        }
    }
}
