using Bindings;
using MirageMUD_Server.Globals;
using MirageMUD_Server.Network;
using MirageMUD_Server.Storage;

namespace MirageMUD_Server
{
    internal class General
    {
        private ServerWebSocket serverWebSocket;

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

            serverWebSocket = new ServerWebSocket();

            // Load language code from the config file using the ConfigReader
            string languageCode = ConfigReader.GetLanguageCode("Data/config.json");

            // Access the singleton instance of TranslationManager
            TranslationManager translator = TranslationManager.Instance;

            // Set the language code in the TranslationManager
            TranslationManager.LanguageCode = languageCode;  // Set the language code to ensure it's used

            // Dynamically load the corresponding language file
            translator.LoadTranslations(languageCode); // Pass language code to load the file

            // Initialize all clients and their corresponding player data
            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                // Create a new Client object, passing the index and WebSocket (null for now)
                var newClient = new Client(i, null); // The WebSocket will be assigned on connection

                // Put the newly created client into the Clients array
                ServerWebSocket.Clients[i] = newClient;

                // Initialize the Player account and its characters
                STypes.Player[i] = new STypes.AccountStruct();
                STypes.Player[i].Initialise(Constants.MAX_CHARS); // Initialize characters with the correct size
            }

            // Start the WebSocket server
            ServerWebSocket.InitialiseNetwork(); // Change the port if necessary
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));
        }
    }
}