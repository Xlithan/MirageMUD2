using MirageMUD_Server;

namespace MirageMud_Server
{
    internal static class Program
    {
        private static Thread consoleThread;
        private static General gnrl;

        // Main entry point of the server application
        // Initializes language settings, loads translations, and starts the server

        static void Main(string[] args)
        {
            gnrl = new General();

            consoleThread = new Thread(new ThreadStart(ConsoleThread));
            consoleThread.Start();

            gnrl.InitialiseServer();
        }

        static void ConsoleThread()
        {
            Console.ReadLine();
        }
    }
}