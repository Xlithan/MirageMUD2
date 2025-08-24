using Bindings;
using System.Text.Json.Serialization;

namespace MirageMUD_Server.World
{
    public class Room
    {
        public int Id { get; set; }
        public string Alias { get; set; } = "";
        public string LongDescription { get; set; } = "";

        public int? NorthId { get; set; }
        public int? EastId { get; set; }
        public int? SouthId { get; set; }
        public int? WestId { get; set; }
        public int? UpId { get; set; }
        public int? DownId { get; set; }

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
}