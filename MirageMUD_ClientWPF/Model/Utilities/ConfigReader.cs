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
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            string jsonContent = File.ReadAllText(configFilePath);
            try
            {
                return JsonSerializer.Deserialize<Config>(jsonContent)
                       ?? throw new InvalidOperationException("Failed to deserialize configuration.");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to deserialize configuration due to invalid JSON.", ex);
            }
        }

        // Retrieves the language code from the configuration file
        public static string GetLanguageCode(string configFilePath)
        {
            var config = ReadConfig(configFilePath);
            return config.LanguageCode ?? throw new InvalidOperationException("Language code is null.");
        }

        // Retrieves the IP Address from the configuration file
        public static string GetIpAddress(string configFilePath)
        {
            var config = ReadConfig(configFilePath);
            return config.IpAddress ?? throw new InvalidOperationException("IP Address is null.");
        }

        // Retrieves the Port from the configuration file
        public static string GetPort(string configFilePath)
        {
            var config = ReadConfig(configFilePath);
            return config.Port ?? throw new InvalidOperationException("Port is null.");
        }

        // Retrieves the Music setting from the configuration file
        public static bool GetMusicEnabled(string configFilePath)
        {
            var config = ReadConfig(configFilePath);
            return config.Music;  // Directly return the bool value
        }

        // Retrieves the Sound setting from the configuration file
        public static bool GetSoundEnabled(string configFilePath)
        {
            var config = ReadConfig(configFilePath);
            return config.Sound;  // Directly return the bool value
        }

        // Update a specific setting in the configuration file
        public static void UpdateSetting(string configFilePath, string key, object value)
        {
            // Load the existing config or create a new one
            var config = File.Exists(configFilePath) ? ReadConfig(configFilePath) : new Config();

            // Update the relevant property based on the key
            switch (key.ToLower())
            {
                case "ipaddress":
                    config.IpAddress = value.ToString();
                    break;
                case "port":
                    config.Port = value.ToString();
                    break;
                case "music":
                    config.Music = Convert.ToBoolean(value);  // Convert value to bool
                    break;
                case "sound":
                    config.Sound = Convert.ToBoolean(value);  // Convert value to bool
                    break;
                case "languagecode":
                    config.LanguageCode = value.ToString();
                    break;
                default:
                    throw new ArgumentException($"Invalid setting key: {key}");
            }

            // Serialize the updated config back to JSON
            string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, updatedJson);
        }
    }
}