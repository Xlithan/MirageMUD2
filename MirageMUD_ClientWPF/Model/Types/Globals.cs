namespace MirageMUD_ClientWPF.Model.Types
{
    internal class Globals
    {
        public static AccountStruct Player = new AccountStruct();
        public class AccountStruct
        {
            public string Login { get; set; }           // Username for login.
            public int Avatar { get; set; }           // Avatar ID.

            // Initializes the account and its characters with default values.
            public void Initialise(int maxChars)
            {
                // Set default values for account properties.
                Login = string.Empty;
                Avatar = 1;
            }
        }
    }
}
