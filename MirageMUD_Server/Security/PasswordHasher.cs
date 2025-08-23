using System.Security.Cryptography;
using System.Text;

namespace MirageMUD_Server.Security
{
    internal static class PasswordHasher
    {
        // Format: PBKDF2$HMACSHA256$<iterations>$<saltB64>$<hashB64>
        private const string Prefix = "PBKDF2$HMACSHA256";
        private const int DefaultIterations = 200_000;
        private const int SaltSize = 16;   // bytes
        private const int KeySize = 32;   // bytes

        public static string Hash(string password, int iterations = DefaultIterations)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] key = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, KeySize);

            return $"{Prefix}${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(key)}";
        }

        public static bool Verify(string password, string stored, out string? upgraded)
        {
            upgraded = null;

            if (!stored.StartsWith(Prefix + "$"))
            {
                // Back-compat: if you have legacy SHA256+salt accounts,
                // verify here and set 'upgraded' to a new PBKDF2 hash on success.
                return false;
            }

            var parts = stored.Split('$');
            int iterations = int.Parse(parts[2]);
            byte[] salt = Convert.FromBase64String(parts[3]);
            byte[] expected = Convert.FromBase64String(parts[4]);

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);

            bool ok = CryptographicOperations.FixedTimeEquals(actual, expected);

            // Opportunistic upgrade if your default iterations increase later.
            if (ok && iterations < DefaultIterations)
                upgraded = Hash(password, DefaultIterations);

            return ok;
        }
    }
}