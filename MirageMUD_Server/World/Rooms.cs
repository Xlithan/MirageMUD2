using System.Text.Json;
using Bindings;

namespace MirageMUD_Server.World
{
    internal static class Rooms
    {
        private static readonly object _lock = new();
        private static readonly Dictionary<int, Room> _byId = new();
        private static string _path = "Data/rooms.json";

        public static void Load(string? path = null)
        {
            lock (_lock)
            {
                _path = path ?? _path;
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

                if (!File.Exists(_path))
                {
                    // If no map exists, seed a tiny starter map
                    var starter = RoomSeeder.GetStarterRooms();
                    SaveAll(starter);
                }

                var json = File.ReadAllText(_path);
                var list = JsonSerializer.Deserialize<List<Room>>(json) ?? new();

                _byId.Clear();
                foreach (var r in list)
                    _byId[r.Id] = r;
            }
        }

        public static void SaveAll(IEnumerable<Room> rooms)
        {
            lock (_lock)
            {
                var list = rooms.ToList();
                var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, json);

                _byId.Clear();
                foreach (var r in list)
                    _byId[r.Id] = r;
            }
        }

        public static IReadOnlyCollection<Room> All()
        {
            lock (_lock) return _byId.Values.ToList().AsReadOnly();
        }

        public static bool TryGet(int id, out Room room)
        {
            lock (_lock) return _byId.TryGetValue(id, out room!);
        }

        public static Room Get(int id)
        {
            lock (_lock)
            {
                if (!_byId.TryGetValue(id, out var r))
                    throw new KeyNotFoundException($"Room id {id} not found.");
                return r;
            }
        }
        public static int? Exit(int roomId, Direction dir)
        {
            var r = Get(roomId);
            return dir switch
            {
                Direction.North => r.NorthId,
                Direction.East => r.EastId,
                Direction.South => r.SouthId,
                Direction.West => r.WestId,
                Direction.Up => r.UpId,
                Direction.Down => r.DownId,
                _ => null
            };
        }

        // Optional: sanity check exits (report one-way links)
        public static IEnumerable<string> ValidateBidirectional()
        {
            var issues = new List<string>();

            void Check(int fromId, int? toId, Direction expectedBack)
            {
                if (toId is null) return;
                if (!TryGet(toId.Value, out var dst))
                {
                    issues.Add($"Room {fromId} → {toId} missing destination");
                    return;
                }
                var back = Exit(toId.Value, expectedBack);
                if (back != fromId)
                    issues.Add($"One-way exit: {fromId} -> {toId} (no {expectedBack} back)");
            }

            foreach (var r in All())
            {
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