using System;
using System.Threading;

namespace MirageMud_Server
{
    internal static class Program
    {
        private static Thread consoleThread;
        static void Main(string[] args)
        {
            consoleThread = new Thread(new ThreadStart(ConsoleThread));
            consoleThread.Start();
        }

        static void ConsoleThread()
        {
            Console.ReadLine();
        }
    }
}