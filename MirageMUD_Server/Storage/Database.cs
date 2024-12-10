using Bindings;
using MirageMUD_Server.Types;
using System.Text.Json;

namespace MirageMUD_Server.Storage
{
    internal class Database
    {
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