using Bindings;
using MirageMUD_Server.Network;
using MirageMUD_Server.Types;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MirageMUD_Server.Storage
{
    // This class handles database-related operations, including file checks, account and character management
    internal class Database
    {
        private ServerTCP serverTCP;  // Instance of ClientTCP for network communication

        // Constructor initializes the serverTCP instance
        public Database()
        {
            serverTCP = ServerTCP.Instance;
        }

        // --- Helpers ---------------------------------------------------------

        private static string AccountPath(string username) =>
            Path.Combine("Accounts", $"{username}.json");

        private static bool TryReadJson(string path, out JsonDocument doc)
        {
            doc = null!;
            if (!File.Exists(path)) return false;
            doc = JsonDocument.Parse(File.ReadAllText(path));
            return true;
        }

        // Checks if a file exists at the given path
        public bool FileExist(string file_path) => File.Exists(file_path);

        // Checks if an account exists for the given username
        public bool AccountExist(string username) => File.Exists(AccountPath(username));

        // Checks if a character exists by searching for its name in a JSON file
        public bool CharacterExist(string characterName)
        {
            string filePath = Path.Combine("Accounts", "charnames.json");

            if (!File.Exists(filePath))
                return false;

            var existingNames = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath)) ?? new List<string>();
            return existingNames.Contains(characterName);
        }

        // Verifies if the provided password is correct for the specified account (SECURE)
        public bool PasswordOK(int index, string username, string password)
        {
            string filename = AccountPath(username);
            if (!File.Exists(filename))
                throw new FileNotFoundException("Account file not found.");

            // Load account into memory (keeps behavior consistent with rest of code)
            string json = File.ReadAllText(filename);
            STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json);

            // Get stored hash and salt
            string storedHashedPassword = GetHashedPassword(username);
            string storedSalt = GetSalt(username);
            if (string.IsNullOrEmpty(storedHashedPassword) || string.IsNullOrEmpty(storedSalt))
                return false;

            // Compute SHA256(password + salt)
            byte[] inputHashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                string passwordWithSalt = password + storedSalt;
                inputHashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));
            }

            // Constant-time comparison
            try
            {
                byte[] storedHashBytes = Convert.FromBase64String(storedHashedPassword);
                return CryptographicOperations.FixedTimeEquals(inputHashBytes, storedHashBytes);
            }
            catch
            {
                // Malformed stored hash
                return false;
            }
        }

        // Adds a new account with the provided username, hashed password, and salt
        public void AddAccount(int index, string name, string hashedPassword, string salt)
        {
            ClearPlayer(index);
            STypes.Player[index].Login = name;
            STypes.Player[index].Password = hashedPassword; // base64 SHA256 hash
            STypes.Player[index].Salt = salt;               // raw/random salt string

            for (int i = 0; i < Constants.MAX_CHARS; i++)
                ClearChar(index, i);

            SavePlayer(index);
        }

        // Adds a new character to the player's account
        public void AddChar(int index, int charNum, string charName, int charGender, int charRace, int charClass, int charAvatar)
        {
            var player = STypes.Player[index];

            player.Character[charNum].Name = charName;
            player.Character[charNum].Gender = charGender;
            player.Character[charNum].Race = charRace;
            player.Character[charNum].Class = charClass;
            player.Character[charNum].Avatar = charAvatar;

            // Apply temporary stats if present
            if (ServerTCP.TempStats.ContainsKey(index))
            {
                int[] stats = ServerTCP.TempStats[index];
                var character = player.Character[charNum];

                character.CharacterStats.Strength = stats[0];
                character.CharacterStats.Intelligence = stats[1];
                character.CharacterStats.Dexterity = stats[2];
                character.CharacterStats.Constitution = stats[3];
                character.CharacterStats.Wisdom = stats[4];
                character.CharacterStats.Charisma = stats[5];
            }

            SavePlayer(index);

            // Update charnames.json
            string jsonFilePath = Path.Combine("Accounts", "charnames.json");
            List<string> charNames = new();

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                charNames = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }

            charNames.Add(charName);

            string updatedJson = JsonSerializer.Serialize(charNames, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        // Clears the player login and password
        public void ClearPlayer(int index)
        {
            STypes.Player[index].Login = "";
            STypes.Player[index].Password = "";
        }

        // Clears the character data for a specified character slot
        public void ClearChar(int index, int charnum)
        {
            STypes.Player[index].Character[charnum].Name = string.Empty;
            STypes.Player[index].Character[charnum].Class = 1;
        }

        // Saves the player data to a JSON file
        public void SavePlayer(int index)
        {
            Directory.CreateDirectory("Accounts");

            string filename = AccountPath(STypes.Player[index].Login);
            string json = JsonSerializer.Serialize(STypes.Player[index], new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filename, json);
            Console.WriteLine(TranslationManager.Instance.GetTranslation("user.saved_player"), STypes.Player[index].Login);
        }

        // Loads the player data from a JSON file
        public void LoadPlayer(int index, string name)
        {
            string filename = AccountPath(name);
            if (!File.Exists(filename))
                throw new FileNotFoundException("Account file not found.");

            string json = File.ReadAllText(filename);
            STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json);

            Console.WriteLine(TranslationManager.Instance.GetTranslation("user.loaded_player"), STypes.Player[index].Login);
        }

        // Unloads the player data
        public void UnloadPlayer(int index)
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("user.logged_out"), STypes.Player[index].Login);
            STypes.Player[index] = new STypes.AccountStruct();
        }

        // Retrieves the hashed password (base64) for the specified user from the account file
        public string GetHashedPassword(string username)
        {
            string jsonFilePath = AccountPath(username);
            if (!TryReadJson(jsonFilePath, out var doc))
                return null;

            var root = doc.RootElement;
            if (root.TryGetProperty("Password", out JsonElement passwordElement))
                return passwordElement.GetString();

            return null;
        }

        // Retrieves the salt for the specified user from the account file
        public string GetSalt(string username)
        {
            string jsonFilePath = AccountPath(username);
            if (!TryReadJson(jsonFilePath, out var doc))
                return null;

            var root = doc.RootElement;
            if (root.TryGetProperty("Salt", out JsonElement saltElement))
                return saltElement.GetString();

            return null;
        }
    }
}