using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using MirageMUD_Server;
using MirageMUD_Server.Network;
using System;

namespace MirageMud_Server
{
    internal static class Program
    {
        private static Thread consoleThread;
        private static General gnrl;

        private static ServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            // Register dependencies with DI
            serviceCollection.AddSingleton<SHandleData>();
            serviceCollection.AddSingleton<IServerTCP, ServerTCP>();
            serviceCollection.AddTransient<IClient, Client>();
            serviceCollection.AddTransient<General>();

            serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolve General from DI
            gnrl = serviceProvider.GetService<General>();

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