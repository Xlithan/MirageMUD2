namespace MirageMUD_Server.World
{
    internal static class RoomSeeder
    {
        public static List<Room> GetStarterRooms()
        {
            // A tiny 3-room map: Inn -> Square -> East Road
            return new List<Room>
            {
                new Room
                {
                    Id = 1,
                    Alias = "Starter Inn",
                    LongDescription = "A cozy room with a sturdy bed and a lantern on the wall.",
                    NorthId = 2
                },
                new Room
                {
                    Id = 2,
                    Alias = "Town Square",
                    LongDescription = "Bustling with life; merchants chat while a fountain gurgles at the center.",
                    SouthId = 1,
                    EastId = 3
                },
                new Room
                {
                    Id = 3,
                    Alias = "East Road",
                    LongDescription = "A dusty road stretching toward the horizon. Town lies to the west.",
                    WestId = 2
                }
            };
        }
    }
}