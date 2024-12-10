namespace MirageMUD_Server.PlayerData
{
    internal enum PlayerRace
    {
        Dwarf = 0,
        Elf = 1,
        Human = 2,
        Gnome = 3,
        Halfling = 4,
        HalfElf = 5,
        HalfOrc = 6
    }

    internal static class Races
    {
        // Converts a race ID to its name as a string
        public static string GetRaceName(int raceId)
        {
            if (Enum.IsDefined(typeof(PlayerRace), raceId))
            {
                return ((PlayerRace)raceId).ToString();
            }
            return "Unknown";
        }

        // Converts a race name to its ID
        public static int GetRaceId(string raceName)
        {
            if (Enum.TryParse(raceName.Replace("-", ""), true, out PlayerRace playerRace))
            {
                return (int)playerRace;
            }
            return -1; // Return -1 if the race name is invalid
        }

        // Example: Get the base stats for a race
        public static (int Strength, int Agility, int Intelligence) GetBaseStats(PlayerRace playerRace)
        {
            return playerRace switch
            {
                PlayerRace.Dwarf => (14, 8, 8),
                PlayerRace.Elf => (8, 14, 12),
                PlayerRace.Human => (10, 10, 10),
                PlayerRace.Gnome => (6, 8, 16),
                PlayerRace.Halfling => (6, 14, 10),
                PlayerRace.HalfElf => (9, 12, 11),
                PlayerRace.HalfOrc => (16, 7, 6),
                _ => (0, 0, 0)
            };
        }

        public static void Examples()
        {
            int raceId = 2; // Human
            string raceName = GetRaceName(raceId); // "Human"

            int id = GetRaceId("Half-Orc"); // 6

            var stats = GetBaseStats(PlayerRace.Elf); // (8, 14, 12)
        }
    }
}
