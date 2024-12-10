using MirageMUD_WFClient;
using MirageMUD_WFClient.Source.Utilities;

namespace MirageMUD_Client.Core
{
    internal static class Program
    {
        private static General gnrl;

        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create an instance of the General class and call its Main method
            gnrl = new General();
            gnrl.Main();
        }
    }
}