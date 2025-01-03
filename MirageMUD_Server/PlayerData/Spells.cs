namespace MirageMUD_Server.PlayerData
{
    // Represents a spell in the game
    internal class Spells
    {
        // Unique identifier for the spell
        public int SpellID { get; set; }

        // Constructor to initialize the spell with its ID
        public Spells(int spellId)
        {
            SpellID = spellId; // Assign the spell ID when the object is created
        }
    }
}