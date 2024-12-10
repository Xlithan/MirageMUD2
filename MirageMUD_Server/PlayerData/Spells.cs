namespace MirageMUD_Server.PlayerData
{
    internal class Spells
    {
        public int SpellID { get; set; }

        // Constructor
        public Spells(int spellId, int quantity)
        {
            SpellID = spellId;
        }
    }
}
