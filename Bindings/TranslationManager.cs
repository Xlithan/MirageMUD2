using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Bindings
{
    internal class TranslationManager
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;

        public TranslationManager()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
        }

        // Load translations from a JSON file
        public void LoadTranslations(string filePath, string languageCode)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Translation file not found: {filePath}");
            }

            string jsonContent = File.ReadAllText(filePath);
            var translations = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);

            if (!_translations.ContainsKey(languageCode))
            {
                _translations[languageCode] = new Dictionary<string, string>();
            }

            FlattenDictionary(translations, "", _translations[languageCode]);
        }

        // Get translation for a key
        public string GetTranslation(string key, string languageCode, string defaultLanguage = "en")
        {
            if (_translations.TryGetValue(languageCode, out var langTranslations) &&
                langTranslations.TryGetValue(key, out var translation))
            {
                return translation;
            }

            if (_translations.TryGetValue(defaultLanguage, out var defaultTranslations) &&
                defaultTranslations.TryGetValue(key, out var defaultTranslation))
            {
                return defaultTranslation;
            }

            return key; // Return key if no translation found
        }

        // Recursively flatten nested dictionaries
        private void FlattenDictionary(Dictionary<string, object> source, string prefix, Dictionary<string, string> result)
        {
            foreach (var kvp in source)
            {
                string fullKey = string.IsNullOrEmpty(prefix) ? kvp.Key : $"{prefix}.{kvp.Key}";

                if (kvp.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Object)
                {
                    var nestedDict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonElement.GetRawText());
                    FlattenDictionary(nestedDict, fullKey, result);
                }
                else
                {
                    result[fullKey] = kvp.Value?.ToString() ?? string.Empty;
                }
            }
        }
    }
}
