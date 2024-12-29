using System.Text.Json;
using System.Diagnostics;
using System.IO;

public class TranslationManager
{
    // The singleton instance
    private static TranslationManager _instance;

    // Static field to store the current language code
    private static string _languageCode = "en-gb"; // Default language

    // Dictionary to hold translations by language code
    private readonly Dictionary<string, Dictionary<string, string>> _translations;

    // Private constructor to prevent instantiation from outside
    private TranslationManager()
    {
        _translations = new Dictionary<string, Dictionary<string, string>>();
    }

    // Public static property to access the singleton instance
    public static TranslationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TranslationManager();
            }
            return _instance;
        }
    }

    // Public static property to get/set the language code globally
    public static string LanguageCode
    {
        get => _languageCode;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _languageCode = value;
                string Lang = null;
                switch (value)
                {
                    // Language packs
                    case "cy": Lang = "Welsh (Cymraeg)"; break;
                    case "de": Lang = "German (Deutsch)"; break;
                    case "en-gb": Lang = "British English (English)"; break;
                    case "en-us": Lang = "American English (English)"; break;
                    case "es": Lang = "Spanish (Español)"; break;
                    case "fr": Lang = "French (Français)"; break;
                    case "it": Lang = "Italian (Italiano)"; break;
                    case "pt": Lang = "Portuguese (Português)"; break;
                    case "ja-ro": Lang = "Romanized Japanese (Romaji)"; break;
                    case "pl": Lang = "Polish (Polski)"; break;
                    case "sv": Lang = "Swedish (Svenska)"; break;
                }
                Debug.WriteLine($"Language code set to: {Lang}");
            }
        }
    }

    // Load translations from a JSON file
    public void LoadTranslations(string languageCode)
    {
        // Build the file path based on the language code
        string filePath = $"Data/lang/{languageCode}.json";

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Translation file not found: {filePath}");
        }

        // Read the file contents
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON content into a dictionary of key-value pairs
        var translations = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonContent);

        // Ensure that we have a dictionary to hold the translations for the specified language
        if (!_translations.ContainsKey(languageCode))
        {
            _translations[languageCode] = new Dictionary<string, string>();
        }

        // Flatten the nested dictionary structure and add it to the translations
        FlattenDictionary(translations, "", _translations[languageCode]);
    }

    // Get translation for a key in the current language
    public string GetTranslation(string key, string defaultLanguage = "en-gb")
    {
        // Debugging output to trace the translation lookup process
        //Debug.WriteLine($"Looking up key: {key} in language: {_languageCode}");

        // Check if translations exist for the current language code
        if (_translations.ContainsKey(_languageCode))
        {
            var langTranslations = _translations[_languageCode];
            if (langTranslations.ContainsKey(key))
            {
                var translation = langTranslations[key];
                //Debug.WriteLine($"Translation found: {translation}");
                return translation;
            }
        }

        // If no translation is found for the specified language, try the default language
        if (_translations.ContainsKey(defaultLanguage))
        {
            var defaultTranslations = _translations[defaultLanguage];
            if (defaultTranslations.ContainsKey(key))
            {
                var defaultTranslation = defaultTranslations[key];
                //Debug.WriteLine($"Translation found in default language: {defaultTranslation}");
                return defaultTranslation;
            }
        }

        // If no translation is found in either language, return the key itself
        Debug.WriteLine($"No translation found for key: {key}");
        return key;  // Fallback to the key itself if no translation is found
    }

    // Recursively flatten a nested dictionary to a single-level dictionary
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