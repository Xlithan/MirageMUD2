using System.Text.Json;

namespace MirageMUD_Server.Storage
{
    // This class handles reading and retrieving configuration data
    internal class ConfigReader
    {
        // Retrieves the language code from the configuration file
        public static string GetLanguageCode(string configFilePath)
        {
            // Check if the configuration file exists at the specified path
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            // Read all content from the configuration file
            string jsonContent = File.ReadAllText(configFilePath);

            // Deserialize the JSON content into a dictionary of key-value pairs
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Check if the 'languageCode' key exists in the dictionary and return its value
            if (config != null && config.TryGetValue("languageCode", out string languageCode))
            {
                return languageCode;
            }

            // Throw an exception if the 'languageCode' key is not found in the configuration file
            throw new KeyNotFoundException("The 'languageCode' key was not found in the configuration file.");
        }
    }
}