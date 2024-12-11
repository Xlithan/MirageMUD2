using System;
using System.Collections.Generic;
using System.Linq;

namespace MirageMUD_Server.PlayerData
{
    internal class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Bonuses { get; set; }
    }

    internal static class Races
    {
        // Store the race data dynamically
        private static List<Race> _races = new List<Race>();

        // Load races from JSON
        public static void LoadRacesFromJson(string json)
        {
            // Parse JSON into the race list
            _races = System.Text.Json.JsonSerializer.Deserialize<List<Race>>(json)
                     ?? new List<Race>();
        }

        // Converts a race ID to its name as a string
        public static string GetRaceName(int raceId)
        {
            var race = _races.FirstOrDefault(r => r.Id == raceId);
            return race?.Name ?? "Unknown";
        }

        // Converts a race name to its ID
        public static int GetRaceId(string raceName)
        {
            var race = _races.FirstOrDefault(r => string.Equals(r.Name, raceName, StringComparison.OrdinalIgnoreCase));
            return race?.Id ?? -1; // Return -1 if the race name is invalid
        }
        public static List<Race> GetAllRaces()
        {
            return _races; // Returns the loaded list of races
        }

        // Example method to demonstrate dynamic functionality
        public static void Examples()
        {
            int raceId = 2; // Assume this is Human
            string raceName = GetRaceName(raceId); // Dynamically gets "Human" from JSON

            int id = GetRaceId("Half-Orc"); // Dynamically gets ID for "Half-Orc" from JSON
        }
    }
}
