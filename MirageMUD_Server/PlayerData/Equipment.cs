namespace MirageMUD_Server.PlayerData
{
    internal class Equipment
    {
        public int Helmet { get; set; } = 10;
        public int Armor { get; set; } = 10;
        public int Weapon { get; set; } = 10;
        public int Shield { get; set; } = 10;
        public int Gloves { get; set; } = 10;
        public int Shoes { get; set; } = 10;

        public int Ring1 { get; set; } = 10;
        public int Ring2 { get; set; } = 10;
        public int Ring3 { get; set; } = 10;
        public int Ring4 { get; set; } = 10;
        public int Bracelet1 { get; set; } = 10;
        public int Bracelet2 { get; set; } = 10;
        public int Amulet { get; set; } = 10;

        // Optional: Add a method to reset stats to default values.
        public void ResetToDefaults()
        {
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
