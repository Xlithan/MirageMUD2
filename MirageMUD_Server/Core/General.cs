using Bindings;
using MirageMUD_Server.Network;
using MirageMUD_Server.PlayerData;
using MirageMUD_Server.Storage;
using MirageMUD_Server.Types;

namespace MirageMUD_Server.Core
{
    internal class General
    {
        private ServerTCP stcp;  // Instance for handling server TCP connections.

        // The object that will handle all data. Readonly because we dont want this to change, we want a single instance.
        private readonly SHandleData _sHandleData;

        // Constructor for the General class.
        // Creates a new SHandleData internally and calls InitialiseMessages on it.
        public General()
        {
            _sHandleData = new SHandleData();  // Create new instance of SHandleData for handling data.
            _sHandleData.InitialiseMessages();  // Initialize messages (likely for language/localization).
        }

        // Initializes the server and sets up the client and player structures
        public void InitialiseServer()
        {
            Console.Title = "MirageMUD 2";  // Set the title of the server window.

            stcp = new ServerTCP();  // Instantiate the TCP server object to handle network communication.

            // Load language code from the config file using the ConfigReader
            string languageCode = ConfigReader.GetLanguageCode("Data/config.json");  // Get the language code for the server from the config file.

            // Access the singleton instance of TranslationManager
            TranslationManager translator = TranslationManager.Instance;

            // Set the language code in the TranslationManager
            TranslationManager.LanguageCode = languageCode;  // Set the language code to ensure it's used throughout the server.

            // Dynamically load the corresponding language file
            translator.LoadTranslations(languageCode);  // Load the language translations based on the code.

            // Initialize all clients and their corresponding player data
            for (int i = 0; i < Constants.MAX_PLAYERS; i++)  // Loop through and initialize data for all possible clients.
            {
                // Create a new Client object, and pass in the data handler object for it to use
                var newClient = new Client(_sHandleData);

                // Put the newly created client into the Clients array
                ServerTCP.Clients[i] = newClient;  // Assign the new client to the server's Clients array.

                // Initialize the Player account and its characters
                STypes.Player[i] = new STypes.AccountStruct();  // Create a new AccountStruct for the player.
                STypes.Player[i].Initialise(Constants.MAX_CHARS);  // Initialize player characters, providing the max character slots.

                // Load races and classes
                string raceJson = System.IO.File.ReadAllText("Data/races.json");  // Read race data from JSON file.
                Races.LoadRacesFromJson(raceJson);  // Load the race data into the server.

                string classJson = System.IO.File.ReadAllText("Data/classes.json");  // Read class data from JSON file.
                Classes.LoadClassesFromJson(classJson);  // Load the class data into the server.
            }

            // Initialize the network and start listening for connections
            stcp.InitialiseNetwork();  // Initialize the network connection, setting up necessary listeners.

            // Output a message indicating that the server has started
            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));  // Display the "server started" message in the appropriate language.
        }
    }
}