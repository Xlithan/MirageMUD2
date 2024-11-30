using System;

namespace Bindings
{
    internal class Types
    {
        // Player array for all accounts
        public static AccountStruct[] Player = new AccountStruct[Constants.MAX_PLAYERS];

        [Serializable]
        public class AccountStruct
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public byte Access { get; set; }
            public CharacterStruct[] Character { get; set; }

            // Initialisation method
            public void Initialise(int maxChars)
            {
                Login = string.Empty;
                Password = string.Empty;
                Salt = string.Empty;
                Access = 0;
                Character = new CharacterStruct[maxChars];
                for (int i = 0; i < maxChars; i++)
                {
                    Character[i] = new CharacterStruct();
                    Character[i].Initialise();
                }
            }
        }

        [Serializable]
        public class CharacterStruct
        {
            // General
            public string Name { get; set; }
            public byte Class { get; set; }
            public int Avatar { get; set; }
            public byte Level { get; set; }
            public int Exp { get; set; }
            public byte PK { get; set; }

            // Guilds
            public string Guild { get; set; }
            public byte GuildAccess { get; set; }

            // Position
            public int Room { get; set; }
            public byte Dir { get; set; }

            // Client use only
            public int MaxHP { get; set; }
            public int MaxMP { get; set; }
            public int MaxSP { get; set; }
            public int MaxStamina { get; set; }
            public byte Attacking { get; set; }
            public int AttackTimer { get; set; }
            public int RoomGetTimer { get; set; }
            public byte CastedSpell { get; set; }

            // Initialisation method
            public void Initialise()
            {
                Name = string.Empty;
                Class = 1; // Default class
                Avatar = 0;
                Level = 1; // Starting level
                Exp = 0;
                PK = 0;
                Guild = string.Empty;
                GuildAccess = 0;
                Room = 0;
                Dir = 0;
                MaxHP = 10; // Default values
                MaxMP = 0;
                MaxSP = 0;
                MaxStamina = 1;
                Attacking = 0;
                AttackTimer = 0;
                RoomGetTimer = 0;
                CastedSpell = 0;
            }
        }
    }
}