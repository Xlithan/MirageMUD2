using System;
using System.Net.Sockets;
using System.Net;

namespace MirageMUD_Server
{
    internal class Client
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
                int readBytes = myStream.EndRead(ar);
                if(readBytes <= 0)
                {
                    CloseSocket(Index); // Disconnect client
                    return;
                }

                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readBytes);
                //HandleData

                myStream.BeginRead(readBuff,0,Socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch
            {
                CloseSocket(Index); // Disconnect client
            }
        }

        private void CloseSocket(int index)
        {
            Console.WriteLine("Connection from " + IP + " has been terminated.");
            Socket.Close();
            Socket = null;
        }
    }
}
