using Bindings;
using MirageMUD_Server.Network;
using MirageMUD_Server.Types;
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

        // Checks if a file exists at the given path
        public bool FileExist(string file_path)
        {
            return File.Exists(file_path); // Return true if the file exists, otherwise false
        }

        // Checks if an account exists for the given username
        public bool AccountExist(string username)
        {
            string filename = $"Accounts/{username}.json"; // Construct the file path
            return File.Exists(filename); // Return true if the account file exists
        }

        // Checks if a character exists by searching for its name in a JSON file
        public bool CharacterExist(string characterName)
        {
            string filePath = $"Accounts/charnames.json"; // Path to the character names file

            if (!File.Exists(filePath))
            {
                return false; // If the file doesn't exist, return false as no characters are present
            }

            // Read and deserialize the character names from the JSON file
            var existingNames = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath));

            // Check if the character name is already in the list
            return existingNames.Contains(characterName);
        }

        // Verifies if the provided password is correct for the specified account
        public bool PasswordOK(int index, string username, string password)
        {
            string filename = $"Accounts/{username}.json"; // Path to the account file
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename); // Read the account JSON data
                STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json); // Deserialize to AccountStruct
            }
            else
            {
                throw new FileNotFoundException("Account file not found."); // Exception if account file doesn't exist
            }

            // Return true if the password matches, otherwise return false
            return STypes.Player[index].Password == password;
        }

        // Adds a new account with the provided username, hashed password, and salt
        public void AddAccount(int index, string name, string hashedPassword, string salt)
        {
            ClearPlayer(index); // Clear any existing player data
            STypes.Player[index].Login = name; // Set the login name
            STypes.Player[index].Password = hashedPassword; // Store the hashed password
            STypes.Player[index].Salt = salt; // Store the salt

            // Clear character data for all character slots
            for (int i = 0; i < Constants.MAX_CHARS; i++)
            {
                ClearChar(index, i);
            }

            SavePlayer(index); // Save the player data to a file
        }

        // Adds a new character to the player's account
        public void AddChar(int index, int charNum, string charName, int charGender, int charRace, int charClass, int charAvatar)
        {
            var player = STypes.Player[index];  // Get the player object

            // Assign values to the character's properties
            player.Character[charNum].Name = charName;
            player.Character[charNum].Gender = charGender;
            player.Character[charNum].Race = charRace;
            player.Character[charNum].Class = charClass;
            player.Character[charNum].Avatar = charAvatar;

            // If temporary stats exist for the player, assign them to the character
            if (ServerTCP.TempStats.ContainsKey(index))
            {
                int[] stats = ServerTCP.TempStats[index]; // Get stats from TempStats

                var character = player.Character[charNum]; // Reference to the character

                // Assign stats to the character's stats properties
                character.CharacterStats.Strength = stats[0];
                character.CharacterStats.Intelligence = stats[1];
                character.CharacterStats.Dexterity = stats[2];
                character.CharacterStats.Constitution = stats[3];
                character.CharacterStats.Wisdom = stats[4];
                character.CharacterStats.Charisma = stats[5];
            }

            SavePlayer(index); // Save the updated player data

            // Update the list of character names in the charnames.json file
            string jsonFilePath = $"Accounts/charnames.json";
            List<string> charNames = new List<string>();

            // If the file exists, read and parse the list of character names
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                charNames = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }

            // Add the new character name to the list
            charNames.Add(charName);

            // Serialize the updated list and save it back to the file
            string updatedJson = JsonSerializer.Serialize(charNames, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        // Clears the player login and password
        public void ClearPlayer(int index)
        {
            STypes.Player[index].Login = ""; // Clear the login
            STypes.Player[index].Password = ""; // Clear the password
        }

        // Clears the character data for a specified character slot
        public void ClearChar(int index, int charnum)
        {
            STypes.Player[index].Character[charnum].Name = string.Empty; // Clear character name
            STypes.Player[index].Character[charnum].Class = 1; // Set the class to default
        }

        // Saves the player data to a JSON file
        public void SavePlayer(int index)
        {
            // Ensure the "Accounts" directory exists
            Directory.CreateDirectory("Accounts");

            string filename = $"Accounts/{STypes.Player[index].Login}.json"; // File path for player data

            // Serialize the AccountStruct to JSON
            string json = JsonSerializer.Serialize(STypes.Player[index], new JsonSerializerOptions { WriteIndented = true });

            // Save the serialized data to the file
            File.WriteAllText(filename, json);
            Console.WriteLine(TranslationManager.Instance.GetTranslation("user.saved_player"), STypes.Player[index].Login);
        }

        // Loads the player data from a JSON file
        public void LoadPlayer(int index, string name)
        {
            string filename = $"Accounts/{name}.json"; // File path for player data
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename); // Read the player data from the file
                STypes.Player[index] = JsonSerializer.Deserialize<STypes.AccountStruct>(json); // Deserialize to AccountStruct

                Console.WriteLine(TranslationManager.Instance.GetTranslation("user.loaded_player"), STypes.Player[index].Login);
            }
            else
            {
                throw new FileNotFoundException("Account file not found."); // Exception if file is not found
            }
        }

        // Unloads the player data
        public void UnloadPlayer(int index)
        {
            Console.WriteLine(TranslationManager.Instance.GetTranslation("user.logged_out"), STypes.Player[index].Login);
            STypes.Player[index] = new STypes.AccountStruct(); // Reset the player's data
        }

        // Retrieves the hashed password for the specified user from the account file
        public string GetHashedPassword(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // File path for the user account

            if (!File.Exists(jsonFilePath))
            {
                return null; // Return null if the account file doesn't exist
            }

            // Read the JSON content from the file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the hashed password if it exists in the file
                if (root.TryGetProperty("Password", out JsonElement passwordElement))
                {
                    return passwordElement.GetString();
                }
            }

            // Return null if the password was not found in the file
            return null;
        }

        // Retrieves the salt for the specified user from the account file
        public string GetSalt(string username)
        {
            string jsonFilePath = Path.Combine("Accounts", $"{username}.json"); // File path for the user account

            if (!File.Exists(jsonFilePath))
            {
                return null; // Return null if the account file doesn't exist
            }

            // Read the JSON content from the file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Parse the JSON content
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = doc.RootElement;

                // Return the salt if it exists in the file
                if (root.TryGetProperty("Salt", out JsonElement saltElement))
                {
                    return saltElement.GetString();
                }
            }

            // Return null if the salt was not found in the file
            return null;
        }
    }
}