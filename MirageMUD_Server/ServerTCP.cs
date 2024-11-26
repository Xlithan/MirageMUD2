using System;
using System.Net.Sockets;
using System.Net;

namespace MirageMUD_Server
{
    internal class ServerTCP
    {
        public static Client[] Clients;
        public TcpListener ServerSocket;
    }
}
