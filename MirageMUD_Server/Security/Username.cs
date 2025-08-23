using System.Text.RegularExpressions;

namespace MirageMUD_Server.Security
{
    internal static class Username
    {
        static readonly Regex Rx = new(@"^[A-Za-z0-9_]{3,20}$", RegexOptions.Compiled);

        public static bool IsValid(string s) => Rx.IsMatch(s);
        public static string Normalize(string s) => s.Trim().ToLowerInvariant();
    }
}