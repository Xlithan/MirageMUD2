using System;
using System.Net.Sockets;
using System.Net;
using Bindings;
using System.Security.Claims;
using System.Reflection.Emit;
using MirageMUD_Server.Network;
using MirageMUD_Server.Globals;

namespace MirageMUD_Server
{
    internal class General
    {
        private ServerTCP stcp;

        // The object that will handle all data. Readonly because we dont want this to change, we want a single instance.
        private readonly SHandleData _sHandleData;

        // Constructor for the General class.
        // Creates a new SHandleData internally and calls InitialiseMessages on it.
        public General()
        {
            _sHandleData = new SHandleData();
            _sHandleData.InitialiseMessages();
        }

        // Initializes the server and sets up the client and player structures
        public void InitialiseServer()
        {
            Console.Title = "MirageMUD 2";

            stcp = new ServerTCP();

            // Initialize all clients and their corresponding player data
            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                // Create a new Client object, and pass in the data handler object for it to use
                var newClient = new Client(_sHandleData);

                // Put the newly created client into the Clients array
                ServerTCP.Clients[i] = newClient;

                // Initialize the Player account and its characters
                STypes.Player[i] = new STypes.AccountStruct();
                STypes.Player[i].Initialise(Constants.MAX_CHARS); // Initialize characters with the correct size
            }
            stcp.InitialiseNetwork();
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));
        }
    }
}