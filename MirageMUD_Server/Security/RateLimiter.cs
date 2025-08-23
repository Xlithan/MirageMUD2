using System.Collections.Concurrent;

namespace MirageMUD_Server.Security
{
    internal class RateLimiter
    {
        private readonly TimeSpan window = TimeSpan.FromMinutes(5);
        private readonly int maxAttempts = 5;

        private class Bucket { public int Count; public DateTime First; }

        private readonly ConcurrentDictionary<string, Bucket> _buckets = new();

        public bool IsBlocked(string key)
        {
            if (!_buckets.TryGetValue(key, out var b)) return false;
            if (DateTime.UtcNow - b.First > window) { _buckets.TryRemove(key, out _); return false; }
            return b.Count >= maxAttempts;
        }

        public void Fail(string key)
        {
            var now = DateTime.UtcNow;
            var b = _buckets.GetOrAdd(key, _ => new Bucket { Count = 0, First = now });
            if (now - b.First > window) { b.Count = 0; b.First = now; }
            b.Count++;
        }

        public void Success(string key) => _buckets.TryRemove(key, out _);
    }
}