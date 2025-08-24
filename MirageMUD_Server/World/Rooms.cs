using System.Text.Json;
using System.Text.Json.Serialization;
using Bindings;

namespace MirageMUD_Server.World
{
    internal static class Rooms
    {
        private static readonly object _lock = new();
        private static readonly Dictionary<int, Room> _byId = new();
        private static string _path = "Data/rooms.json";

        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        public static void Load(string? path = null)
        {
            lock (_lock)
            {
                _path = path ?? _path;
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

                if (!File.Exists(_path))
                {
                    var starter = RoomSeeder.GetStarterRooms();
                    SaveAll(starter);
                }

                var json = File.ReadAllText(_path);
                var list = JsonSerializer.Deserialize<List<Room>>(json, JsonOpts) ?? new();
                _byId.Clear();
                foreach (var r in list) _byId[r.Id] = r;
            }
        }

        public static IEnumerable<Room> All()
        {
            lock (_lock) return _byId.Values.ToList();
        }

        public static Room Get(int id)
        {
            lock (_lock)
            {
                if (_byId.TryGetValue(id, out var r)) return r;
                throw new KeyNotFoundException($"Room {id} not found.");
            }
        }

        public static bool TryGet(int id, out Room room)
        {
            lock (_lock)
            {
                var ok = _byId.TryGetValue(id, out var r);
                room = r!;
                return ok;
            }
        }

        public static void Save(Room room)
        {
            lock (_lock)
            {
                _byId[room.Id] = room;
                Persist();
            }
        }

        public static void SaveAll(IEnumerable<Room> rooms)
        {
            lock (_lock)
            {
                _byId.Clear();
                foreach (var r in rooms) _byId[r.Id] = r;
                Persist();
            }
        }

        private static void Persist()
        {
            var list = _byId.Values.OrderBy(r => r.Id).ToList();
            var json = JsonSerializer.Serialize(list, JsonOpts);
            File.WriteAllText(_path, json);
        }

        public static IEnumerable<string> ValidateBidirectional()
        {
            var issues = new List<string>();
            bool Exists(int? id) => id.HasValue && _byId.ContainsKey(id.Value);

            foreach (var r in All())
            {
                void Check(int fromId, int? toId, Direction reverse)
                {
                    if (!toId.HasValue) return;
                    if (!Exists(toId)) { issues.Add($"Room {fromId} exit to missing room {toId}."); return; }
                    var to = _byId[toId.Value];
                    int? back = reverse switch
                    {
                        Direction.North => to.NorthId,
                        Direction.East => to.EastId,
                        Direction.South => to.SouthId,
                        Direction.West => to.WestId,
                        Direction.Up => to.UpId,
                        Direction.Down => to.DownId,
                        _ => null
                    };
                    if (back != fromId)
                        issues.Add($"Room {fromId} -> {toId} is missing reverse {reverse} back.");
                }

                Check(r.Id, r.NorthId, Direction.South);
                Check(r.Id, r.EastId, Direction.West);
                Check(r.Id, r.SouthId, Direction.North);
                Check(r.Id, r.WestId, Direction.East);
                Check(r.Id, r.UpId, Direction.Down);
                Check(r.Id, r.DownId, Direction.Up);
            }
            return issues;
        }
    }
}