using MirageMUD_WFClient.Source.General;
using MirageMUD_WFClient.Source.Utilities;

namespace MirageMUD_WFClient
{
    internal static class Program
    {
        private static General gnrl;

        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Load language code from the config file using the ConfigReader
            string languageCode = ConfigReader.GetLanguageCode("Data/config.json");

            // Access the singleton instance of TranslationManager
            TranslationManager translator = TranslationManager.Instance;

            // Set the language code in the TranslationManager
            TranslationManager.LanguageCode = languageCode;  // Set the language code to ensure it's used

            // Dynamically load the corresponding language file
            translator.LoadTranslations(languageCode); // Pass language code to load the file

            // Create an instance of the General class and call its Main method
            gnrl = new General();
            gnrl.Main();
        }
    }
}