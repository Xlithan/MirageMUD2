namespace MirageMUD_Server.Utilities
{
    internal class StatRoller
    {
        private const int TotalPoints = 12;
        private const int NumberOfStats = 6;

        /// <summary>
        /// Distributes a total of 12 points randomly across 6 stats.
        /// </summary>
        /// <returns>An array of 6 integers representing the stat distribution.</returns>
        public int[] GenerateRandomStats()
        {
            int[] stats = new int[NumberOfStats];
            Random random = new Random();

            // Distribute points randomly among stats.
            for (int i = 0; i < TotalPoints; i++)
            {
                stats[random.Next(0, NumberOfStats)]++;
            }

            return stats;
        }
    }
}
