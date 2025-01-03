namespace MirageMUD_Server.PlayerData
{
    // Represents a race in the game
    internal class Race
    {
        // Unique identifier for the race
        public int Id { get; set; }

        // The name of the race (e.g., Human, Elf, Dwarf)
        public string Name { get; set; }

        // A brief description of the race
        public string Description { get; set; }

        // A dictionary holding bonuses specific to the race, such as strength or agility
        public Dictionary<string, int> Bonuses { get; set; }
    }

    internal static class Races
    {
        // List to store all race data dynamically
        private static List<Race> _races = new List<Race>();

        // Method to load race data from JSON
        public static void LoadRacesFromJson(string json)
        {
            // Parse the incoming JSON into the race list, or return an empty list if parsing fails
            _races = System.Text.Json.JsonSerializer.Deserialize<List<Race>>(json)
                     ?? new List<Race>();
        }

        // Converts a race ID to its corresponding name
        public static string GetRaceName(int raceId)
        {
            var race = _races.FirstOrDefault(r => r.Id == raceId); // Find race by ID
            return race?.Name ?? "Unknown"; // Return race name or "Unknown" if not found
        }

        // Converts a race name to its corresponding ID
        public static int GetRaceId(string raceName)
        {
            var race = _races.FirstOrDefault(r => string.Equals(r.Name, raceName, StringComparison.OrdinalIgnoreCase));
            return race?.Id ?? -1; // Return the race ID or -1 if the race name is not found
        }

        // Returns the list of all races
        public static List<Race> GetAllRaces()
        {
            return _races; // Return the list of loaded races
        }

        // Example method to demonstrate dynamic functionality with races
        public static void Examples()
        {
            int raceId = 2; // Example: Assume this ID corresponds to the "Human" race
            string raceName = GetRaceName(raceId); // Dynamically retrieves the name "Human" from the race ID

            int id = GetRaceId("Half-Orc"); // Dynamically retrieves the ID for the "Half-Orc" race from its name
        }
    }
}