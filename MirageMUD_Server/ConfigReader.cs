using System.IO;
using System.Text.Json;

namespace MirageMUD_Server
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
    }
}
