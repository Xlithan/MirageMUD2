using System;
using System.Net.Sockets;
using System.Net;
using Bindings;
using System.Security.Claims;
using System.Reflection.Emit;

namespace MirageMUD_Server
{
    internal class General
    {
        private ServerTCP stcp;

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
            Console.Title = "MirageMUD 2";

            stcp = new ServerTCP();

            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                // Create a new Client object, and pass in the data handler object for it to use
                var newClient = new Client(_sHandleData);

                // Put the newly created client into the Clients array
                ServerTCP.Clients[i] = newClient;

                // Initialize the Player account and its characters
                Types.Player[i] = new Types.AccountStruct();
                Types.Player[i].Initialise(Constants.MAX_CHARS); // Initialize characters with the correct size
            }
            stcp.InitialiseNetwork();
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));
        }
    }
}
