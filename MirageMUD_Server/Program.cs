using Bindings;
using MirageMUD_Server;
using System;
using System.Threading;

namespace MirageMud_Server
{
    internal static class Program
    {
        private static Thread consoleThread;
        private static General gnrl;

        // Main entry point of the server application
        // Initializes language settings, loads translations, and starts the server
        static void Main(string[] args)
        {
            // Load language code from the config file using the ConfigReader
            string languageCode = ConfigReader.GetLanguageCode("Data/config.json");

            // Access the singleton instance of TranslationManager
            TranslationManager translator = TranslationManager.Instance;

            // Set the language code in the TranslationManager
            TranslationManager.LanguageCode = languageCode;  // Set the language code to ensure it's used

            // Dynamically load the corresponding language file
            translator.LoadTranslations(languageCode); // Pass language code to load the file

            gnrl = new General();
            consoleThread = new Thread(new ThreadStart(ConsoleThread));
            consoleThread.Start();
            gnrl.InitialiseServer();
        }

        // Reads input to keep the console thread active
        static void ConsoleThread()
        {
            Console.ReadLine();
        }
    }
}