namespace MirageMUD_Server.World
{
    internal static class RoomSeeder
    {
        public static List<Room> GetStarterRooms()
        {
            return new List<Room>
            {
                new Room
                {
                    Id = 1,
                    Alias = "Starter Inn",
                    ShortDescription = "A modest common room warmed by a hearth.",
                    LongDescription = "Rough-hewn beams frame the low ceiling, and the smell of stew lingers near the fire. A notice board hangs beside the door.",
                    Terrain = "Indoor",
                    Type = "SafeZone",
                    NorthId = 2
                },
                new Room
                {
                    Id = 2,
                    Alias = "Town Square",
                    ShortDescription = "A lively square circling a stone fountain.",
                    LongDescription = "Merchants barter beneath colorful awnings while a fountain gurgles at the center. Cobblestone streets branch in all directions.",
                    Terrain = "Town",
                    Type = "Town",
                    SouthId = 1,
                    EastId = 3
                },
                new Room
                {
                    Id = 3,
                    Alias = "East Road",
                    ShortDescription = "A dusty road lined with hedgerows.",
                    LongDescription = "Wagons rattle toward farms beyond the town palisade. The square lies back to the west.",
                    Terrain = "Town",
                    Type = "Road",
                    WestId = 2
                }
            };
        }
    }
}