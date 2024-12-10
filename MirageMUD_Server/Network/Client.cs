using System;
using System.Net.Sockets;
using System.Net;
using System.Reflection;

namespace MirageMUD_Server.Network
{
    internal class Client
    {
        private readonly SHandleData _sHandleData;

        public int Index;
        public string IP;
        public int Port;
        public TcpClient Socket;
        public NetworkStream myStream;
        public bool Closing;
        public byte[] readBuff;

        public Client(SHandleData sHandleData)
        {
            // Assign the provided sHandleData to the internal _sHandleData field
            _sHandleData = sHandleData;
        }

        public void Start()
        {
            // Set the send and receive buffer sizes
            Socket.SendBufferSize = 4096;
            Socket.ReceiveBufferSize = 4096;

            // Get the network stream associated with the socket
            myStream = Socket.GetStream();

            // Resize the buffer for reading incoming data
            Array.Resize(ref readBuff, Socket.ReceiveBufferSize);

            // Begin asynchronous read operation
            myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
        }
        private void OnReceiveData(IAsyncResult ar)
        {
            try
            {
                // End the read operation and get the number of bytes read
                int readBytes = myStream.EndRead(ar);

                // If no bytes were read, close the socket (client disconnected)
                if (readBytes <= 0)
                {
                    CloseSocket(Index); // Disconnect client
                    return;
                }

                // Create a new byte array to hold the received data
                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readBytes);

                // Handle the received data using the provided data handler (SHandleData)
                _sHandleData.HandleMessages(Index, newBytes);

                // Continue reading data asynchronously
                myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch
            {
                // If an error occurs, close the socket (client disconnected)
                CloseSocket(Index); // Disconnect client
            }
        }

        private void CloseSocket(int index)
        {
            // Print a message indicating that the connection was terminated
            Console.WriteLine(string.Format(
                TranslationManager.Instance.GetTranslation("connection.terminated"),
                IP));

            // Close the socket and set it to null
            Socket.Close();
            Socket = null;
        }
    }
}