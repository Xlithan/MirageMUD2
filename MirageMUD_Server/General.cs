using System;
using System.Net.Sockets;
using System.Net;
using Bindings;

namespace MirageMUD_Server
{
    internal class General
    {
        private ServerTCP stcp;
        private SHandleData sHandleData;
        public void InitialiseServer()
        {
            stcp = new ServerTCP();
            sHandleData = new SHandleData();

            sHandleData.InitialiseMessages();

            for(int i = 1; i < Constants.MAX_PLAYERS; i++)
            {
                ServerTCP.Clients[i] = new Client();
            }
            stcp.InitialiseNetwork();
            Console.WriteLine("Server has started.");
        }
    }
}
