namespace MirageMUD_ClientWPF.Model.Core
{
    internal class Config
    {
        // IP address of the server
        public string IpAddress { get; set; }

        // Port number for the connection
        public string Port { get; set; }

        // Flag to enable or disable music
        public bool Music { get; set; }

        // Flag to enable or disable sound
        public bool Sound { get; set; }

        // Language code for the application
        public string LanguageCode { get; set; }
    }
}