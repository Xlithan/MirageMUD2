using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            string filename = "Accounts/" + username + ".bin";
            if(File.Exists(filename))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddAccount(int index, string name, string password)
        {
            ClearPlayer(index);
            Types.Player[index].Login = name;
            Types.Player[index].Password = password;

            for(int i = 1; i < Constants.MAX_CHARS; i++)
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
            string filename = "Accounts/" + Types.Player[index].Login + ".bin";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            bf.Serialize(fs, Types.Player[index]);
            fs.Close();
        }

        public void LoadPlayer(int index, string name)
        {
            string filename = "Accounts/" + name + ".bin";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.Open);
            Types.Player[index] = (Types.AccountStruct)bf.Deserialize(fs);
            fs.Close();
        }
    }
}
