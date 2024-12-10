using System;
using Bindings;
using MirageMUD_Server.PlayerData;

namespace MirageMUD_Server.Globals
{
    internal class STypes
    {
        // Array to store all player accounts, with a fixed maximum size defined by MAX_PLAYERS.
        public static AccountStruct[] Player = new AccountStruct[Constants.MAX_PLAYERS];

        // Represents a player's account, including login details and associated characters.
        [Serializable]
        public class AccountStruct
        {
            public string Login { get; set; }           // Username for login.
            public string Password { get; set; }       // Hashed password for security.
            public string Salt { get; set; }           // Salt value for hashing the password.
            public byte Access { get; set; }           // Access level (e.g., admin, player).
            public CharacterStruct[] Character { get; set; } // Array of characters belonging to the account.

            // Initializes the account and its characters with default values.
            public void Initialise(int maxChars)
            {
                // Set default values for account properties.
                Login = string.Empty;
                Password = string.Empty;
                Salt = string.Empty;
                Access = 0;

                // Create the character array with the specified number of slots.
                Character = new CharacterStruct[maxChars];

                // Initialize each character slot with default character properties.
                for (int i = 0; i < maxChars; i++)
                {
                    Character[i] = new CharacterStruct(); // Create a new character.
                    Character[i].Initialise();            // Set default values for the character.
                }
            }
        }

        // Represents a player's character with attributes, guild info, position, and status.
        [Serializable]
        public class CharacterStruct
        {
            // Basic character details.
            public string Name { get; set; }

            public byte Race { get; set; }
            public byte Class { get; set; }
            public int Avatar { get; set; }
            public byte Level { get; set; }
            public int Exp { get; set; }
            public byte PK { get; set; }               // Tracks PvP status.

            // Guild-related properties.
            public string Guild { get; set; }
            public byte GuildAccess { get; set; }

            // Position and direction in the game world.
            public int Room { get; set; }
            public byte Dir { get; set; }

            // Client-side properties for health, stamina, and combat.
            public int MaxHP { get; set; }
            public int MaxMP { get; set; }
            public int MaxStamina { get; set; }
            public byte Attacking { get; set; }
            public int AttackTimer { get; set; }
            public int RoomGetTimer { get; set; }
            public byte CastedSpell { get; set; }
            public List<Inventory> PlayerInv { get; set; } = new List<Inventory>(Constants.MAX_PLAYERINV);
            public List<Spells> PlayerSpells { get; set; } = new List<Spells>(Constants.MAX_PLAYERSPELLS);

            // Encapsulated data.
            public Stats CharacterStats { get; set; } = new Stats();
            public Equipment CharacterEquip { get; set; } = new Equipment();

            // Initializes the character's properties with default values.
            public void Initialise()
            {
                // Set basic character details to defaults.
                Name = string.Empty;   // No name assigned initially.
                Race = 1;              // Default to class ID 1 (e.g., human).
                Class = 1;             // Default to class ID 1 (e.g., warrior).
                Avatar = 0;            // Default avatar ID.
                Level = 1;             // Start at level 1.
                Exp = 0;               // No experience points at the start.
                PK = 0;                // Not flagged as a player-killer.

                // Initialize guild-related properties to defaults.
                Guild = string.Empty;  // No guild assigned.
                GuildAccess = 0;       // Default guild access level.

                // Set initial position in the game world.
                Room = 0;              // Start in the default room.
                Dir = 0;               // Default direction (For player movement).

                // Initialize client-side properties with default values.
                MaxHP = 10;            // Default maximum health points.
                MaxMP = 0;             // No mana points by default.
                MaxStamina = 1;        // Minimum stamina.
                Attacking = 0;         // Not attacking.
                AttackTimer = 0;       // Attack timer not set.
                RoomGetTimer = 0;      // No room-specific action timer.
                CastedSpell = 0;       // No spell cast initially.

                // Initialize Inventory/Spells with max empty slots
                PlayerInv.Clear();
                while (PlayerInv.Count < Constants.MAX_PLAYERINV)
                {
                    PlayerInv.Add(new Inventory(0, 0));  // Empty inventory slots with 0 quantity
                }

                PlayerSpells.Clear();
                while (PlayerSpells.Count < Constants.MAX_PLAYERSPELLS)
                {
                    PlayerSpells.Add(new Spells(0, 0));  // Empty spell slots with 0 quantity
                }

                // Reset data to defaults.
                CharacterStats.ResetToDefaults();
                CharacterEquip.ResetToDefaults();
            }
        }
    }
}
