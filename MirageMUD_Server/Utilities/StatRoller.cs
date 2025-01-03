namespace MirageMUD_Server.Utilities
{
    internal class StatRoller
    {
        private const int TotalPoints = 12; // Total points to be distributed across stats.
        private const int NumberOfStats = 6; // The number of stats to distribute the points among.

        /// <summary>
        /// Distributes a total of 12 points randomly across 6 stats.
        /// </summary>
        /// <returns>An array of 6 integers representing the stat distribution.</returns>
        public int[] GenerateRandomStats()
        {
            int[] stats = new int[NumberOfStats]; // Array to store stat values.
            Random random = new Random();         // Random number generator.

            // Distribute points randomly among stats.
            for (int i = 0; i < TotalPoints; i++)
            {
                stats[random.Next(0, NumberOfStats)]++; // Increment a random stat.
            }

            return stats; // Return the final distribution of stats.
        }
    }
}