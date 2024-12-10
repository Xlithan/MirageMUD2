namespace MirageMUD_Server.PlayerData
{
    internal class Stats
    {
        public byte Strength { get; set; } = 2;
        public byte Intelligence { get; set; } = 2;
        public byte Dexterity { get; set; } = 2;
        public byte Constitution { get; set; } = 2;
        public byte Wisdom { get; set; } = 2;
        public byte Charisma { get; set; } = 2;

        // Optional: Add a method to reset stats to default values.
        public void ResetToDefaults()
        {
            Strength = 10;
            Intelligence = 10;
            Dexterity = 10;
            Constitution = 10;
            Wisdom = 10;
            Charisma = 10;
        }
    }
}
