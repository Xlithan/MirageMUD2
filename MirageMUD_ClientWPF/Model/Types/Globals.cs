namespace MirageMUD_ClientWPF.Model.Types
{
    internal class Globals
    {
        // Static instance of AccountStruct to represent the player's account
        public static AccountStruct Player = new AccountStruct();

        public class AccountStruct
        {
            // Property to store the username for login
            public string Login { get; set; }

            // Property to store the Avatar ID associated with the account
            public int Avatar { get; set; }

            // Initializes the account with default values.
            public void Initialise(int maxChars)
            {
                // Set default values for account properties
                Login = string.Empty;  // Default login is an empty string
                Avatar = 1;            // Default avatar is set to ID 1
            }
        }
    }
}