namespace MirageMUD_Server.PlayerData
{
    // Represents the equipment worn by a player
    internal class Equipment
    {
        // Default equipment values (10 represents the default equipment ID or stats)
        public int Helmet { get; set; } = 0; // The player's helmet equipment ID

        public int Armor { get; set; } = 0; // The player's armor equipment ID
        public int Weapon { get; set; } = 0; // The player's weapon equipment ID
        public int Shield { get; set; } = 0; // The player's shield equipment ID
        public int Gloves { get; set; } = 0; // The player's gloves equipment ID
        public int Shoes { get; set; } = 0; // The player's shoes equipment ID

        public int Ring1 { get; set; } = 0; // The player's first ring equipment ID
        public int Ring2 { get; set; } = 0; // The player's second ring equipment ID
        public int Ring3 { get; set; } = 0; // The player's third ring equipment ID
        public int Ring4 { get; set; } = 0; // The player's fourth ring equipment ID
        public int Bracelet1 { get; set; } = 0; // The player's first bracelet equipment ID
        public int Bracelet2 { get; set; } = 0; // The player's second bracelet equipment ID
        public int Amulet { get; set; } = 0; // The player's amulet equipment ID

        // Optional: Resets all equipment stats to default values
        public void ResetToDefaults()
        {
            // Reset all equipment properties to 0 (default is 10, but can reset to 0 as required)
            Helmet = 0;
            Armor = 0;
            Weapon = 0;
            Shield = 0;
            Gloves = 0;
            Shoes = 0;
            Ring1 = 0;
            Ring2 = 0;
            Ring3 = 0;
            Ring4 = 0;
            Bracelet1 = 0;
            Bracelet2 = 0;
            Amulet = 0;
        }
    }
}