using System;
using Bindings;

namespace Bindings
{
    internal class Types
    {
        public static AccountStruct[] Player = new AccountStruct[Constants.MAX_PLAYERS];

        [Serializable]

        public struct AccountStruct()
        {
            public string Login;
            public string Password;
            public byte Access;
            public CharacterStruct[] Character;
        }
        public struct CharacterStruct()
        {
            // General
            public string Name;
            public byte Class;
            public int Avatar;
            public byte Level;
            public int Exp;
            public byte PK;

            // Guilds
            public string Guild;
            public byte GuildAccess;

            // Position
            public int Room;
            public byte Dir;

            // Client use only
            public int MaxHP;
            public int MaxMP;
            public int MaxSP;
            public int MaxStamina;
            public byte Attacking;
            public int AttackTimer;
            public int RoomGetTimer;
            public byte CastedSpell;
        }
    }
}
