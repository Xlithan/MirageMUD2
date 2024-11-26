using MirageMUD_Server;
using System;
using System.Threading;

namespace MirageMud_Server
{
    internal static class Program
    {
        private static Thread consoleThread;
        private static General gnrl;
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