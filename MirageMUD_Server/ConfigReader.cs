using System.IO;
using System.Text.Json;

namespace MirageMUD_Server
{
    internal class ConfigReader
    {
        // Retrieves the language code from the configuration file
        public static string GetLanguageCode(string configFilePath)
        {
            // Check if the file exists
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            // Read all content from the file
            string jsonContent = File.ReadAllText(configFilePath);

            // Deserialize the JSON content into a dictionary
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Check if the languageCode key exists and return the corresponding value
            if (config != null && config.TryGetValue("languageCode", out string languageCode))
            {
                return languageCode;
            }

            // Throw an exception if the languageCode key is not found
            throw new KeyNotFoundException("The 'languageCode' key was not found in the configuration file.");
        }
    }
}