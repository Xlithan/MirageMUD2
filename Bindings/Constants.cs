namespace Bindings
{
    // Bindings are shared between Client and Server projects
    internal class Constants
    {
        // Server-related constants
        public const int MAX_PLAYERS = 50; // Maximum number of players allowed on the server
        public const int MAX_ROOMS = 50; // Maximum number of rooms available
        public const int MAX_ITEMS = 50; // Maximum number of items that can exist
        public const int MAX_SHOPS = 50; // Maximum number of shops available
        public const int MAX_SPELLS = 50; // Maximum number of spells allowed
        public const int MAX_NPCS = 50; // Maximum number of NPCs supported

        // Account-related constants
        public const int MAX_CHARS = 5; // Maximum number of characters per account

        // Player-specific constants
        public const int MAX_PLAYERSPELLS = 10; // Maximum number of spells a player can know
        public const int MAX_PLAYERINV = 14; // Maximum number of items in a player's inventory
    }
}