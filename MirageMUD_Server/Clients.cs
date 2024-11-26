using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace MirageMUD_Server
{
    internal class Clients
    {
        public int Index;
        public string IP;
        public int Port;
        public TcpClient Socket;
        public NetworkStream myStream;
        public bool Closing;
        public byte[] readBuff;

        public void Start()
        {
            Socket.SendBufferSize = 4096;
            Socket.ReceiveBufferSize = 4096;
            myStream = Socket.GetStream();
            Array.Resize(ref readBuff, Socket.ReceiveBufferSize);
            myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
        }

        private void OnReceiveData(IAsyncResult ar)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
