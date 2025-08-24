using Bindings;
using System.Text.Json.Serialization;

namespace MirageMUD_Server.World
{
    public class Room
    {
        public int Id { get; set; }
        public string Alias { get; set; } = "";
        public string? ShortDescription { get; set; }
        public string LongDescription { get; set; } = "";

        public int? NorthId { get; set; }
        public int? EastId { get; set; }
        public int? SouthId { get; set; }
        public int? WestId { get; set; }
        public int? UpId { get; set; }
        public int? DownId { get; set; }

        public string? Type { get; set; }        // SafeZone | PK | Arena | Shop | Bank | Vault | Casino | Tavern | Guild | etc.
        public string? Terrain { get; set; }     // Town | Forest | Cave | Dungeon | Indoor | Swamp | Desert | etc.
        public string? ShopId { get; set; }

        public List<Interactable> Interactables { get; set; } = new();
        public string? Music { get; set; }
        public string? AmbientSound { get; set; }

        public Doors Doors { get; set; } = new();
        public Restrictions Restrictions { get; set; } = new();
        public List<NpcSpawn> NpcSpawns { get; set; } = new();

        [JsonIgnore]
        public IReadOnlyDictionary<Direction, int?> Exits => new Dictionary<Direction, int?>
        {
            { Direction.North, NorthId },
            { Direction.East,  EastId  },
            { Direction.South, SouthId },
            { Direction.West,  WestId  },
            { Direction.Up,    UpId    },
            { Direction.Down,  DownId  },
        };
    }

    public sealed class Interactable { public string Id { get; set; } = ""; }

    public sealed class Doors
    {
        public Door? North { get; set; }
        public Door? East { get; set; }
        public Door? South { get; set; }
        public Door? West { get; set; }
        public Door? Up { get; set; }
        public Door? Down { get; set; }
    }
    public sealed class Door { public string? Name { get; set; } public bool Locked { get; set; } public string? KeyItemId { get; set; } }

    public sealed class Restrictions
    {
        public int MinLevel { get; set; } = 0;
        public List<string> RacesAllowed { get; set; } = new();
        public List<string> RacesDenied { get; set; } = new();
        public List<string> ClassesAllowed { get; set; } = new();
        public List<string> ClassesDenied { get; set; } = new();
        public int MinAdminLevel { get; set; } = 0;
        public string? ClanOnlyId { get; set; }
    }

    public sealed class NpcSpawn
    {
        public string NpcId { get; set; } = "";
        public int MaxAlive { get; set; }
        public int RespawnSec { get; set; }
    }
}