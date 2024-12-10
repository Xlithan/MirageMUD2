namespace MirageMUD_Server.PlayerData
{
    internal enum PlayerClass
    {
        Berserker = 0,
        Pacifist = 1,
        Paladin = 2,
        Fighter = 3,
        Mage = 4,
        Cleric = 5,
        Druid = 6,
        Ranger = 7,
        Thief = 8
    }

    internal static class Classes
    {
        // Converts a class ID to its name as a string
        public static string GetClassName(int classId)
        {
            if (Enum.IsDefined(typeof(PlayerClass), classId))
            {
                return ((PlayerClass)classId).ToString();
            }
            return "Unknown";
        }

        // Converts a class name to its ID
        public static int GetClassId(string className)
        {
            if (Enum.TryParse(className, true, out PlayerClass playerClass))
            {
                return (int)playerClass;
            }
            return -1; // Return -1 if the class name is invalid
        }

        // Example: Get the base stats for a class
        public static (int Strength, int Agility, int Intelligence) GetBaseStats(PlayerClass playerClass)
        {
            return playerClass switch
            {
                PlayerClass.Berserker => (18, 10, 5),
                PlayerClass.Pacifist => (5, 10, 18),
                PlayerClass.Paladin => (15, 12, 8),
                PlayerClass.Fighter => (16, 12, 6),
                PlayerClass.Mage => (5, 8, 20),
                PlayerClass.Cleric => (8, 10, 16),
                PlayerClass.Druid => (10, 10, 15),
                PlayerClass.Ranger => (12, 16, 8),
                PlayerClass.Thief => (10, 18, 5),
                _ => (0, 0, 0)
            };
        }

        // Examples usages:
        private static void Examples()
        {
            int classId = 3; // Fighter
            string className = GetClassName(classId); // "Fighter"

            int id = GetClassId("Mage"); // 4

            var stats = GetBaseStats(PlayerClass.Thief); // (10, 18, 5)
        }
    }
}