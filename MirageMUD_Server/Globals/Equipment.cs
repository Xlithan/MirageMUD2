namespace MirageMUD_Server.Globals
{
    internal class Equipment
    {
        public byte Helmet { get; set; } = 10;
        public byte Armor { get; set; } = 10;
        public byte Weapon { get; set; } = 10;
        public byte Shield { get; set; } = 10;
        public byte Gloves { get; set; } = 10;
        public byte Shoes { get; set; } = 10;

        public byte Ring1 { get; set; } = 10;
        public byte Ring2 { get; set; } = 10;
        public byte Ring3 { get; set; } = 10;
        public byte Ring4 { get; set; } = 10;
        public byte Bracelet1 { get; set; } = 10;
        public byte Bracelet2 { get; set; } = 10;
        public byte Amulet { get; set; } = 10;

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
