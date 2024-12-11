using System;
using System.Collections.Generic;
using System.Linq;

namespace MirageMUD_Server.PlayerData
{
    internal class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Bonuses { get; set; } // Optional stat bonuses
    }

    internal static class Classes
    {
        // Store the class data dynamically
        private static List<Class> _classes = new List<Class>();

        // Load classes from JSON
        public static void LoadClassesFromJson(string json)
        {
            _classes = System.Text.Json.JsonSerializer.Deserialize<List<Class>>(json)
                      ?? new List<Class>();
        }

        // Converts a class ID to its name as a string
        public static string GetClassName(int classId)
        {
            var playerClass = _classes.FirstOrDefault(c => c.Id == classId);
            return playerClass?.Name ?? "Unknown";
        }

        // Converts a class name to its ID
        public static int GetClassId(string className)
        {
            var playerClass = _classes.FirstOrDefault(c => string.Equals(c.Name, className, StringComparison.OrdinalIgnoreCase));
            return playerClass?.Id ?? -1; // Return -1 if the class name is invalid
        }
        public static List<Class> GetAllClasses()
        {
            return _classes; // Returns the loaded list of classes
        }

        // Example method to demonstrate dynamic functionality
        public static void Examples()
        {
            int classId = 3; // Assume this is Fighter
            string className = GetClassName(classId); // Dynamically gets "Fighter" from JSON

            int id = GetClassId("Mage"); // Dynamically gets ID for "Mage" from JSON
        }
    }
}