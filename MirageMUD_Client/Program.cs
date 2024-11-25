using MirageMUD_Client.Source.General;
using MirageMUD_Client.Source.Network;

namespace MirageMUD_Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create an instance of the General class and call its Main method
            var general = new Source.General.General();
            general.Main();
        }
    }
}