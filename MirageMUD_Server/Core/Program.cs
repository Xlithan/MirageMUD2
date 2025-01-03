namespace MirageMUD_Server.Core
{
    internal static class Program
    {
        private static Thread consoleThread;  // Thread to run the console, allowing asynchronous console interaction.
        private static General gnrl;  // Instance of the General class for initializing and running the server.

        // Main entry point of the server application
        // Initializes language settings, loads translations, and starts the server
        private static void Main(string[] args)
        {
            gnrl = new General();  // Create an instance of the General class to initialize and start the server.

            // Start the console thread to handle console input
            consoleThread = new Thread(new ThreadStart(ConsoleThread));  // Create a new thread to handle console operations.
            consoleThread.Start();  // Start the console thread.

            gnrl.InitialiseServer();  // Initialize the server by loading necessary data and setting up connections.
        }

        // Method for handling console interaction (keeping the application running)
        private static void ConsoleThread()
        {
            Console.ReadLine();  // Keep the server running by waiting for console input.
        }
    }
}