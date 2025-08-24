using Bindings;
using MirageMUD_Server.Types;

namespace MirageMUD_Server.World
{
    internal static class WorldService
    {
        public static void HandleCommand(int index, string raw)
        {
            var cmd = (raw ?? "").Trim();
            if (cmd.Length == 0) return;

            var lc = cmd.ToLowerInvariant();

            switch (lc)
            {
                case "look":
                case "l": SendRoomView(index); return;

                case "n": case "north": TryMove(index, Direction.North); return;
                case "e": case "east": TryMove(index, Direction.East); return;
                case "s": case "south": TryMove(index, Direction.South); return;
                case "w": case "west": TryMove(index, Direction.West); return;
                case "u": case "up": TryMove(index, Direction.Up); return;
                case "d": case "down": TryMove(index, Direction.Down); return;

                default:
                    Network.ServerTCP.Instance.AlertMsg(index, $"Unknown command: {raw}");
                    return;
            }
        }

        public static void SendRoomView(int index)
        {
            var server = Network.ServerTCP.Instance;
            var player = STypes.Player[index];

            if (player.Room <= 0) player.Room = 1; // starter room

            if (!Rooms.TryGet(player.Room, out var r))
            {
                server.AlertMsg(index, $"You are nowhere (room {player.Room} missing).");
                return;
            }

            server.SendRoomView(index, r);
        }

        private static void TryMove(int index, Direction dir)
        {
            var server = Network.ServerTCP.Instance;
            var p = STypes.Player[index];
            if (p.Room <= 0) p.Room = 1;

            if (!Rooms.TryGet(p.Room, out var r))
            {
                server.AlertMsg(index, $"Can't move: current room {p.Room} invalid.");
                return;
            }

            int? to = dir switch
            {
                Direction.North => r.NorthId,
                Direction.East => r.EastId,
                Direction.South => r.SouthId,
                Direction.West => r.WestId,
                Direction.Up => r.UpId,
                Direction.Down => r.DownId,
                _ => null
            };

            if (!to.HasValue || to.Value <= 0 || !Rooms.TryGet(to.Value, out _))
            {
                server.AlertMsg(index, "You can't go that way.");
                return;
            }

            // TODO: door locks & restrictions

            p.Room = to.Value;
            SendRoomView(index);
        }
    }
}