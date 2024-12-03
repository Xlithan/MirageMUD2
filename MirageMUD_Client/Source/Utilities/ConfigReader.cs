using System;
using System.Collections.Generic;
using System.IO;  // Needed for file handling
using System.Text.Json;  // Needed for JSON serialization/deserialization

namespace MirageMUD_WFClient.Source.Utilities
{
    internal class ConfigReader
    {
        // Retrieves the language code from the configuration file
        public static string GetLanguageCode(string configFilePath)
        {
            // Check if the configuration file exists
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            // Read all text from the file (assuming it's JSON)
            string jsonContent = File.ReadAllText(configFilePath);

            // Deserialize the JSON content into a dictionary
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Check if the 'languageCode' key exists and return its value
            if (config != null && config.TryGetValue("languageCode", out string languageCode))
            {
                return languageCode;
            }

            // Throw an exception if the 'languageCode' key is missing
            throw new KeyNotFoundException("The 'languageCode' key was not found in the configuration file.");
        }

        // Updates the language code in the config file
        public static void UpdateLanguageCode(string configFilePath, string newLanguageCode)
        {
            Dictionary<string, string> config;

            // If the configuration file exists, read its content
            if (File.Exists(configFilePath))
            {
                // Read the existing content of the configuration file
                string jsonContent = File.ReadAllText(configFilePath);

                // Deserialize it into a dictionary, or create an empty dictionary if null
                config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent) ?? new Dictionary<string, string>();
            }
            else
            {
                // If the file does not exist, initialize an empty dictionary
                config = new Dictionary<string, string>();
            }

            // Update the language code (or add it if not present)
            config["languageCode"] = newLanguageCode;

            // Serialize the dictionary back into a JSON string with indentation for readability
            string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

            // Write the updated JSON content back to the configuration file
            File.WriteAllText(configFilePath, updatedJson);
        }
    }
}