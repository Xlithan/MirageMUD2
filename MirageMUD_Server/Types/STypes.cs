using Bindings;
using MirageMUD_Server.PlayerData;

namespace MirageMUD_Server.Types
{
    internal class STypes
    {
        // Array to store all player accounts, with a fixed maximum size defined by MAX_PLAYERS.
        public static AccountStruct[] Player = new AccountStruct[Constants.MAX_PLAYERS];

        // Represents a player's account, including login details and associated characters.
        public class AccountStruct
        {
            public string Login { get; set; }           // Username for login.
            public string Password { get; set; }       // Hashed password for security.
            public string Salt { get; set; }           // Salt value for hashing the password.
            public int Access { get; set; }           // Access level (e.g., admin, player).
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
                    Character[i].Initialise(i);            // Set default values for the character.
                }
            }
        }

        // Represents a player's character with attributes, guild info, position, and status.
        public class CharacterStruct
        {
            // Basic character details.
            public int ID { get; set; }                 // Unique character ID.

            public string Name { get; set; }            // Character's name.
            public int Race { get; set; }               // Race ID.
            public int Class { get; set; }              // Class ID.
            public int Gender { get; set; }             // Gender ID.
            public int Avatar { get; set; }             // Avatar ID.
            public int Level { get; set; }              // Character's level.
            public int Exp { get; set; }                // Experience points.
            public int PK { get; set; }                 // Tracks PvP status (Player-Killer).

            // Guild-related properties.
            public string Guild { get; set; }           // Guild name.

            public int GuildAccess { get; set; }        // Guild access level.

            // Position and direction in the game world.
            public int Room { get; set; }               // Current room in the game world.

            public int Dir { get; set; }                // Current direction.

            // Client-side properties for health, stamina, and combat.
            public int MaxHP { get; set; }              // Maximum health points.

            public int MaxMP { get; set; }              // Maximum mana points.
            public int MaxStamina { get; set; }         // Maximum stamina.
            public int Attacking { get; set; }          // Indicates if the character is attacking.
            public int AttackTimer { get; set; }        // Timer for attack actions.
            public int RoomGetTimer { get; set; }       // Timer for room-specific actions.
            public int CastedSpell { get; set; }        // ID of the spell that was cast.

            // Inventory and spells.
            public List<Inventory> PlayerInv { get; set; } = new List<Inventory>();  // Player's inventory items.

            public List<Spells> PlayerSpells { get; set; } = new List<Spells>();    // List of spells the player can cast.

            // Encapsulated data for character stats and equipment.
            public Stats CharacterStats { get; set; } = new Stats(); // Character's base stats (Strength, etc.).

            public Equipment CharacterEquip { get; set; } = new Equipment(); // Character's equipment (weapons, armor, etc.).

            // Initializes the character's properties with default values.
            public void Initialise(int id)
            {
                // Set basic character details to defaults.
                ID = id;
                Name = string.Empty;   // No name assigned initially.
                Race = 1;              // Default to race ID 1.
                Class = 1;             // Default to class ID 1.
                Avatar = 1;            // Default avatar ID.
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

                // Initialize Inventory/Spells with max empty slots.
                PlayerInv.Clear();
                while (PlayerInv.Count < Constants.MAX_PLAYERINV)
                {
                    PlayerInv.Add(new Inventory(0, 0));  // Empty inventory slots with 0 quantity.
                }

                PlayerSpells.Clear();
                while (PlayerSpells.Count < Constants.MAX_PLAYERSPELLS)
                {
                    PlayerSpells.Add(new Spells(0));  // Empty spell slots with 0 quantity.
                }

                // Reset data to defaults for stats and equipment.
                CharacterStats.ResetToDefaults();
                CharacterEquip.ResetToDefaults();
            }
        }
    }
}