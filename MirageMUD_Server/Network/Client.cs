using System.Net.Sockets;

namespace MirageMUD_Server.Network
{
    internal class Client
    {
        private readonly SHandleData _sHandleData;  // Instance of the SHandleData class used for processing incoming data.

        public int Index;  // Index of the client in the client list.
        public string IP;  // IP address of the client.
        public int Port;  // Port number of the client.
        public TcpClient Socket;  // TCP connection object.
        public NetworkStream myStream;  // Network stream used for sending/receiving data.
        public bool Closing;  // Flag to indicate if the client connection is closing.
        public byte[] readBuff;  // Buffer for reading incoming data from the client.

        // Constructor that initializes the client with the provided SHandleData instance.
        public Client(SHandleData sHandleData)
        {
            _sHandleData = sHandleData;  // Assign the provided sHandleData to the internal _sHandleData field.
        }

        // Starts the client's socket connection and prepares for data reception.
        public void Start()
        {
            // Set the send and receive buffer sizes
            Socket.SendBufferSize = 4096;  // Set buffer size for sending data.
            Socket.ReceiveBufferSize = 4096;  // Set buffer size for receiving data.

            // Get the network stream associated with the socket
            myStream = Socket.GetStream();

            // Resize the buffer for reading incoming data
            Array.Resize(ref readBuff, Socket.ReceiveBufferSize);

            // Begin asynchronous read operation to receive data from the client
            myStream.BeginRead(readBuff, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
        }

        // Callback method for handling the received data.
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
                Array.Resize(ref newBytes, readBytes);  // Resize the byte array to fit the number of read bytes.
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readBytes);  // Copy the data from the buffer.

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

        // Closes the socket and handles the termination of the client connection.
        private void CloseSocket(int index)
        {
            // Print a message indicating that the connection was terminated
            Console.WriteLine(string.Format(
                TranslationManager.Instance.GetTranslation("connection.terminated"),
                IP));  // Log the termination message with the client's IP.

            // Close the socket and set it to null
            Socket.Close();
            Socket = null;  // Nullify the socket to ensure it's no longer in use.
        }
    }
}