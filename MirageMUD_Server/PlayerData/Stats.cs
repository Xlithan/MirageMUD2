namespace MirageMUD_Server.PlayerData
{
    // Represents the basic stats of a player character
    internal class Stats
    {
        // Strength stat (initial value set to 2)
        public int Strength { get; set; } = 2;

        // Intelligence stat (initial value set to 2)
        public int Intelligence { get; set; } = 2;

        // Dexterity stat (initial value set to 2)
        public int Dexterity { get; set; } = 2;

        // Constitution stat (initial value set to 2)
        public int Constitution { get; set; } = 2;

        // Wisdom stat (initial value set to 2)
        public int Wisdom { get; set; } = 2;

        // Charisma stat (initial value set to 2)
        public int Charisma { get; set; } = 2;

        // Resets all stats to their default values (2)
        public void ResetToDefaults()
        {
            Strength = 2;
            Intelligence = 2;
            Dexterity = 2;
            Constitution = 2;
            Wisdom = 2;
            Charisma = 2;
        }
    }
}