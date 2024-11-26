using System;
using System.Net.Sockets;
using System.Net;

namespace MirageMUD_Server
{
    internal class Client
    {
        /// <summary>
        /// A reference to the SHandleData that should be used to handle data for this client.
        /// </summary>
        private readonly SHandleData _sHandleData;

        public int Index;
        public string IP;
        public int Port;
        public TcpClient Socket;
        public NetworkStream myStream;
        public bool Closing;
        public byte[] readBuff;

        /// <summary>
        /// Constructore for a Client object.
        /// Accepts a SHandleData object that will be used to handle data.
        /// </summary>
        /// <param name="sHandleData">The data handler to use.</param>
        public Client(SHandleData sHandleData)
        {
            // Assign the provided sHandleData to the internal _sHandleData field
            _sHandleData = sHandleData;
        }

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
                if (readBytes <= 0)
                {
                    CloseSocket(Index); // Disconnect client
                    return;
                }

                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readBytes);

                // Handle Data
                _sHandleData.HandleMessages(Index, newBytes);

                myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
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
