using MirageMUD_Server.Network;

namespace MirageMUD_Server.PlayerData
{
    internal class Stats
    {
        public int Strength { get; set; } = 2;
        public int Intelligence { get; set; } = 2;
        public int Dexterity { get; set; } = 2;
        public int Constitution { get; set; } = 2;
        public int Wisdom { get; set; } = 2;
        public int Charisma { get; set; } = 2;

        // Optional: Add a method to reset stats to default values.
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
