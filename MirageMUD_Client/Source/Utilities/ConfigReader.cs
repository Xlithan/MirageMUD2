using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MirageMUD_Client.Source.Utilities
{
    internal class ConfigReader
    {
        public static string GetLanguageCode(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            string jsonContent = File.ReadAllText(configFilePath);

            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            if (config != null && config.TryGetValue("languageCode", out string languageCode))
            {
                return languageCode;
            }

            throw new KeyNotFoundException("The 'languageCode' key was not found in the configuration file.");
        }

        // Updates the language code in the config file
        public static void UpdateLanguageCode(string configFilePath, string newLanguageCode)
        {
            Dictionary<string, string> config;

            if (File.Exists(configFilePath))
            {
                string jsonContent = File.ReadAllText(configFilePath);
                config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent) ?? new Dictionary<string, string>();
            }
            else
            {
                config = new Dictionary<string, string>();
            }

            config["languageCode"] = newLanguageCode;

            string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFilePath, updatedJson);
        }
    }
}
