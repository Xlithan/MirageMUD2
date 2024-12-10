namespace MirageMUD_Server.Globals
{
    internal class Stats
    {
        public byte Strength { get; set; } = 10;
        public byte Dexterity { get; set; } = 10;
        public byte Constitution { get; set; } = 10;
        public byte Wisdom { get; set; } = 10;
        public byte Intelligence { get; set; } = 10;
        public byte Charisma { get; set; } = 10;

        // Optional: Add a method to reset stats to default values.
        public void ResetToDefaults()
        {
            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Wisdom = 10;
            Intelligence = 10;
            Charisma = 10;
        }
    }
}
