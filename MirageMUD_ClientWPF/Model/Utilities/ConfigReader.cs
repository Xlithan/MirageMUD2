using MirageMUD_ClientWPF.Model.Core;
using System.IO;
using System.Text.Json;

namespace MirageMUD_ClientWPF.Model.Utilities
{
    internal class ConfigReader
    {
        // Reads the configuration file and returns a Config object
        private static Config ReadConfig(string configFilePath)
        {
            // Check if the configuration file exists, otherwise throw an error
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            // Read the content of the configuration file
            string jsonContent = File.ReadAllText(configFilePath);
            try
            {
                // Deserialize the JSON content into a Config object
                return JsonSerializer.Deserialize<Config>(jsonContent)
                       ?? throw new InvalidOperationException("Failed to deserialize configuration.");
            }
            catch (JsonException ex)
            {
                // Handle invalid JSON format
                throw new InvalidOperationException("Failed to deserialize configuration due to invalid JSON.", ex);
            }
        }

        // Retrieves the language code from the configuration file
        public static string GetLanguageCode(string configFilePath)
        {
            var config = ReadConfig(configFilePath);  // Load the configuration
            return config.LanguageCode ?? throw new InvalidOperationException("Language code is null.");
        }

        // Retrieves the IP Address from the configuration file
        public static string GetIpAddress(string configFilePath)
        {
            var config = ReadConfig(configFilePath);  // Load the configuration
            return config.IpAddress ?? throw new InvalidOperationException("IP Address is null.");
        }

        // Retrieves the Port from the configuration file
        public static string GetPort(string configFilePath)
        {
            var config = ReadConfig(configFilePath);  // Load the configuration
            return config.Port ?? throw new InvalidOperationException("Port is null.");
        }

        // Retrieves the Music setting from the configuration file
        public static bool GetMusicEnabled(string configFilePath)
        {
            var config = ReadConfig(configFilePath);  // Load the configuration
            return config.Music;  // Directly return the bool value
        }

        // Retrieves the Sound setting from the configuration file
        public static bool GetSoundEnabled(string configFilePath)
        {
            var config = ReadConfig(configFilePath);  // Load the configuration
            return config.Sound;  // Directly return the bool value
        }

        // Update a specific setting in the configuration file
        public static void UpdateSetting(string configFilePath, string key, object value)
        {
            // Load the existing config or create a new one if it doesn't exist
            var config = File.Exists(configFilePath) ? ReadConfig(configFilePath) : new Config();

            // Update the relevant property based on the key
            switch (key.ToLower())
            {
                case "ipaddress":
                    config.IpAddress = value.ToString();  // Set IP address
                    break;

                case "port":
                    config.Port = value.ToString();  // Set Port
                    break;

                case "music":
                    config.Music = Convert.ToBoolean(value);  // Convert value to bool and set Music
                    break;

                case "sound":
                    config.Sound = Convert.ToBoolean(value);  // Convert value to bool and set Sound
                    break;

                case "languagecode":
                    config.LanguageCode = value.ToString();  // Set Language code
                    break;

                default:
                    // If the key is invalid, throw an exception
                    throw new ArgumentException($"Invalid setting key: {key}");
            }

            // Serialize the updated config object back to JSON
            string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            // Write the updated JSON content to the file
            File.WriteAllText(configFilePath, updatedJson);
        }
    }
}