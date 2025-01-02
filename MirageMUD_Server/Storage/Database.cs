using Bindings;
using MirageMUD_Server.Network;
using MirageMUD_Server.Types;
using System.Text.Json;

namespace MirageMUD_Server.Storage
{
    internal class Database
    {
        ServerTCP serverTCP;  // Instance of ClientTCP for network communication

        public Database()
        {
            serverTCP = ServerTCP.Instance;
        }
        // Checks if a file exists at the given path
        public bool FileExist(string file_path)
        {
            return File.Exists(file_path);
        }

        // Checks if an account exists for the given username
        public bool AccountExist(string username)
        {
            string filename = $"Accounts/{username}.json";
            return File.Exists(filename);
        }
        public bool CharacterExist(string characterName)
        {
            string filePath = $"Accounts/charnames.json";

            if (!File.Exists(filePath))
            {
                return false; // No character names file exists yet, so the name isn't taken
            }

            // Read the existing character names from the file
            var existingNames = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath));

            // Check if the name already exists
            return existingNames.Contains(characterName);
        }

        // Verifies if the provided password is correct for the specified account
        public bool PasswordOK(int index, string username, string password)
        {
            string filename = $"Accounts/{username}.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json);
            }
            else
            {
                throw new FileNotFoundException("Account file not found.");
            }

            // Return true if passwords match, otherwise false
            if (STypes.Player[index].Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Adds a new account with the provided username, hashed password, and salt
        public void AddAccount(int index, string name, string hashedPassword, string salt)
        {
            ClearPlayer(index);
            STypes.Player[index].Login = name;
            STypes.Player[index].Password = hashedPassword; // Store the hashed password
            STypes.Player[index].Salt = salt; // Store the salt

            // Clear character data for all characters
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                ClearChar(index, i);
            }

            SavePlayer(index);
        }
        public void AddChar(int index, int charNum, string charName, int charGender, int charRace, int charClass, int charAvatar)
        {
            var player = STypes.Player[index];  // Get the player object

            // Save character slot
            STypes.Player[index].Character[charNum].Name = charName;
            STypes.Player[index].Character[charNum].Gender = charGender;
            STypes.Player[index].Character[charNum].Race = charRace;
            STypes.Player[index].Character[charNum].Class = charClass;
            STypes.Player[index].Character[charNum].Avatar = charAvatar;

            // Check if stats exist for this player in TempStats
            if (ServerTCP.TempStats.ContainsKey(index))
            {
                // Get the stats for this player from TempStats
                int[] stats = ServerTCP.TempStats[index];

                // Assign stats to the character's CharacterStats property
                var character = player.Character[charNum];

                // Assign stats from TempStats to the CharacterStats object
                character.CharacterStats.Strength = stats[0];
                character.CharacterStats.Intelligence = stats[1];
                character.CharacterStats.Dexterity = stats[2];
                character.CharacterStats.Constitution = stats[3];
                character.CharacterStats.Wisdom = stats[4];
                character.CharacterStats.Charisma = stats[5];
            }

            SavePlayer(index);

            // Add the new character name to the JSON list
            string jsonFilePath = $"Accounts/charnames.json";
            List<string> charNames = new List<string>();

            // Check if the file exists, if it does, read it and parse the list
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                charNames = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }

            // Add the new character name to the list
            charNames.Add(charName);

            // Serialize the list back to JSON
            string updatedJson = JsonSerializer.Serialize(charNames, new JsonSerializerOptions { WriteIndented = true });

            // Save the updated list to the file
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        // Clears the player login and password
        public void ClearPlayer(int index)
        {
            STypes.Player[index].Login = "";
            STypes.Player[index].Password = "";
        }

        // Clears the character data for a specified character
        public void ClearChar(int index, int charnum)
        {
            STypes.Player[index].Character[charnum].Name = string.Empty;
            STypes.Player[index].Character[charnum].Class = 1;
        }

        // Saves the player data to a JSON file
        public void SavePlayer(int index)
        {
            // Ensure the directory exists
            Directory.CreateDirectory("Accounts");

            string filename = $"Accounts/{STypes.Player[index].Login}.json";

            // Serialize the AccountStruct to JSON
            string json = JsonSerializer.Serialize(STypes.Player[index], new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filename, json);
            Console.WriteLine($"Saved player {STypes.Player[index].Login} data to JSON.");
        }

        // Loads the player data from a JSON file
        public void LoadPlayer(int index, string name)
        {
            string filename = $"Accounts/{name}.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json);

                Console.WriteLine($"Loaded player {STypes.Player[index].Login} data.");
            }
            else
            {
                throw new FileNotFoundException("Account file not found.");
            }
        }

        // Unloads the player data
        public void UnloadPlayer(int index)
        {
            Console.WriteLine($"{STypes.Player[index].Login} logged out.");
            STypes.Player[index] = new STypes.AccountStruct();
        }

        // Retrieves the hashed password for the specified user
        public string GetHashedPassword(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // Assumes Accounts folder contains the user JSON files

            if (!File.Exists(jsonFilePath))
            {
                // If the file does not exist, return null
                return null;
            }

            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the password field (which should be the hashed password)
                if (root.TryGetProperty("Password", out JsonElement passwordElement))
                {
                    return passwordElement.GetString();
                }
            }

            // If the password is not found, return null
            return null;
        }

        // Retrieves the salt for the specified user
        public string GetSalt(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // Assumes Accounts folder contains the user JSON files

            if (!File.Exists(jsonFilePath))
            {
                // If the file does not exist, return null
                return null;
            }

            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the salt field (if it exists)
                if (root.TryGetProperty("Salt", out JsonElement saltElement))
                {
                    return saltElement.GetString();
                }
            }

            // If the salt is not found, return null
            return null;
        }
    }
}