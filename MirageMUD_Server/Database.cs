using System;
using System.IO;
using System.Text.Json;
using Bindings;

namespace MirageMUD_Server
{
    internal class Database
    {
        public bool FileExist(string file_path)
        {
            return File.Exists(file_path);
        }

        public bool AccountExist(string username)
        {
            string filename = $"Accounts/{username}.json";
            return File.Exists(filename);
        }

        public void AddAccount(int index, string name, string password)
        {
            ClearPlayer(index);
            Types.Player[index].Login = name;
            Types.Player[index].Password = password;

            for (int i = 1; i <= Constants.MAX_CHARS; i++)
            {
                ClearChar(index, i);
            }

            SavePlayer(index);
        }

        public void ClearPlayer(int index)
        {
            Types.Player[index].Login = "";
            Types.Player[index].Password = "";
        }

        public void ClearChar(int index, int charnum)
        {
            Types.Player[index].Character[charnum].Name = "";
            Types.Player[index].Character[charnum].Class = 1;
        }

        public void SavePlayer(int index)
        {
            string filename = $"Accounts/{Types.Player[index].Login}.json";
            string json = JsonSerializer.Serialize(Types.Player[index], new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }

        public void LoadPlayer(int index, string name)
        {
            string filename = $"Accounts/{name}.json";
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                Types.Player[index] = JsonSerializer.Deserialize<Types.AccountStruct>(json);
            }
            else
            {
                throw new FileNotFoundException("Account file not found.");
            }
        }
    }
}
