namespace MirageMUD_Server.PlayerData
{
    // Represents a single class in the game
    internal class Class
    {
        public int Id { get; set; } // The unique identifier for the class
        public string Name { get; set; } // The name of the class (e.g., "Warrior", "Mage")
        public string Description { get; set; } // A description of the class
    }

    // Static class to handle the operations related to classes
    internal static class Classes
    {
        // Store the class data dynamically in a list
        private static List<Class> _classes = new List<Class>();

        // Loads class data from a JSON string into the _classes list
        public static void LoadClassesFromJson(string json)
        {
            // Deserialize the JSON into a list of classes
            _classes = System.Text.Json.JsonSerializer.Deserialize<List<Class>>(json)
                      ?? new List<Class>(); // If the deserialization fails, initialize an empty list
        }

        // Converts a class ID to its name as a string
        public static string GetClassName(int classId)
        {
            // Search for the class with the given ID and return its name
            var playerClass = _classes.FirstOrDefault(c => c.Id == classId);
            return playerClass?.Name ?? "Unknown"; // Return "Unknown" if no class with that ID is found
        }

        // Converts a class name to its ID
        public static int GetClassId(string className)
        {
            // Search for the class with the given name (case-insensitive) and return its ID
            var playerClass = _classes.FirstOrDefault(c => string.Equals(c.Name, className, StringComparison.OrdinalIgnoreCase));
            return playerClass?.Id ?? -1; // Return -1 if no class with that name is found
        }

        // Returns the list of all available classes
        public static List<Class> GetAllClasses()
        {
            return _classes; // Returns the list of loaded classes
        }

        // Example method to demonstrate dynamic functionality
        public static void Examples()
        {
            int classId = 3; // Assume this is the ID for the "Fighter" class
            string className = GetClassName(classId); // Dynamically gets "Fighter" from the JSON data

            int id = GetClassId("Mage"); // Dynamically gets the ID for the "Mage" class from the JSON data
        }
    }
}