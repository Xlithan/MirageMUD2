using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Windows;
using System.Xml.Linq;
using Bindings;

namespace MirageMUD_ClientWPF.Model.Network
{
    internal class ClientTCP
    {
        private static ClientTCP instance;
        public static ClientTCP Instance => instance ??= new ClientTCP();

        // The player's TCP connection to the server
        public TcpClient PlayerSocket;

        // Network stream for reading and writing data to the server
        public static NetworkStream myStream;

        // Instance of CHandleData for processing incoming messages
        private CHandleData handleData;

        // Buffer for receiving data asynchronously
        private byte[] asyncBuff;

        // Flags to manage the connection state
        private bool connecting;
        private bool connected;

        // Connects to the server at the specified IP address and port
        public void ConnectToServer()
        {
            // If the player socket exists and is already connected, do nothing
            if (PlayerSocket != null)
            {
                if (PlayerSocket.Connected || connected)
                    return;

                // Close the existing connection if any
                PlayerSocket.Close();
                PlayerSocket = null;
            }

            // Create a new TcpClient and initialize the connection settings
            PlayerSocket = new TcpClient();
            handleData = new CHandleData();
            PlayerSocket.ReceiveBufferSize = 4096;  // Set the receive buffer size
            PlayerSocket.SendBufferSize = 4096;     // Set the send buffer size
            PlayerSocket.NoDelay = false;           // Set Nagle's algorithm to false (for low-latency)

            // Resize the buffer for receiving data asynchronously
            Array.Resize(ref asyncBuff, 8192);

            // Begin the connection process to the server at IP "127.0.0.1" on port 7777
            PlayerSocket.BeginConnect("127.0.0.1", 7777, new AsyncCallback(ConnectCallback), PlayerSocket);
            connecting = true;  // Set the connecting flag
        }

        // Callback method for the connection attempt to the server
        private void ConnectCallback(IAsyncResult ar)
        {
            // End the connection attempt
            try
            {
                PlayerSocket.EndConnect(ar);
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show(
                    "No connection to server. Do you want to retry?",
                    "Connection Error",
                    MessageBoxButton.OKCancel,   // Correct enum for WPF
                    MessageBoxImage.Error           // Correct enum for WPF
                );

                if (result == MessageBoxResult.OK)
                {
                    // Handle Retry
                    ConnectToServer();
                }
                else
                {
                    // Do nothing
                }

                // Update connection status label
            }

            // Check if the connection was unsuccessful
            if (PlayerSocket.Connected == false)
            {
                connecting = false;
                connected = false;
                return;
            }
            else
            {
                // Set the NoDelay option to true for low-latency communication
                PlayerSocket.NoDelay = true;

                // Get the network stream for sending/receiving data
                myStream = PlayerSocket.GetStream();

                // Initialize messages for the CHandleData instance
                handleData.InitialiseMessages();

                // Start reading data asynchronously from the server
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
                connected = true;  // Set the connected flag
                connecting = false;  // Set the connecting flag to false

                //frmMenu.Default.RunOnUIThread(() =>
                    //frmMenu.Default.lblStatus.Text = "Connected");
            }
        }

        // Callback method for receiving data asynchronously from the server
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                // Get the number of bytes read from the stream
                int byteAMT = myStream.EndRead(ar);

                // Create a new byte array to hold the received data
                byte[] myBytes = null;
                Array.Resize(ref myBytes, byteAMT);

                // Copy the received data into the byte array
                Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteAMT);

                // If no bytes were received, it indicates the connection was lost
                if (byteAMT == 0)
                {
                    // Handle game disconnection or termination
                    Disconnect();
                    return;
                }

                // Pass the received data to the CHandleData class to process the messages
                handleData.HandleMessages(myBytes);

                // Continue reading data asynchronously
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
            }
            catch (IOException ex)
            {
                // Log the exception
                Debug.WriteLine("IOException: " + ex.Message);

                // Handle disconnection (e.g., close the client socket and notify the user)
                Disconnect();
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }

        private void Disconnect()
        {
            // Close the network stream and the socket
            if (myStream != null)
            {
                myStream.Close();
                myStream = null;
            }

            if (PlayerSocket != null && PlayerSocket.Connected)
            {
                PlayerSocket.Close();
                PlayerSocket = null;
            }

            // Set the connection flags
            connected = false;
            connecting = false;

            // Optionally, notify the user about the disconnection (e.g., message box or logging)
            MessageBox.Show("Connection lost to the server.", "Disconnected", MessageBoxButton.OK, MessageBoxImage.Error);
            //frmMenu.Default.RunOnUIThread(() =>
                    //frmMenu.Default.lblStatus.Text = "Disconnected");
        }

        // Sends the specified byte array of data to the server
        public void SendData(byte[] data)
        {
            // Create a new packet buffer and add the data
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);

            // Write the data to the network stream
            myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);

            // Dispose of the buffer after sending
            buffer.Dispose();
        }

        // Sends a login request to the server with the provided username and password
        public void SendLogin(string name, string pass)
        {
            // Create a new packet buffer for the login data
            PacketBuffer buffer = new PacketBuffer();

            // Add the login request packet identifier and the login details
            buffer.AddInteger((int)ClientPackets.CLogin);
            buffer.AddString(name);
            buffer.AddString(pass);
            buffer.AddByte(1);  // Version Major
            buffer.AddByte(0);  // Version Minor
            buffer.AddByte(0);  // Version Revision

            // Send the login data to the server
            SendData(buffer.ToArray());

            // Dispose of the buffer after sending
            buffer.Dispose();
        }

        // Sends a logout request to the server
        public void SendLogout()
        {
            // Create a new packet buffer for the login data
            PacketBuffer buffer = new PacketBuffer();

            // Add the login request packet identifier and the login details
            buffer.AddInteger((int)ClientPackets.CLogout);

            // Send the login data to the server
            SendData(buffer.ToArray());

            // Dispose of the buffer after sending
            buffer.Dispose();
        }

        // Sends a new account creation request to the server with the provided username and password
        public void SendNewAccount(string name, string pass)
        {
            // Create a new packet buffer for the account creation data
            PacketBuffer buffer = new PacketBuffer();

            // Add the new account request packet identifier and the account details
            buffer.AddInteger((int)ClientPackets.CNewAccount);
            buffer.AddString(name);
            buffer.AddString(pass);

            // Send the new account data to the server
            SendData(buffer.ToArray());

            // Dispose of the buffer after sending
            buffer.Dispose();
        }

        // Sends a request to the server to reroll the stats for a new character
        public void SendRerollRequest()
        {
            // Create a new packet buffer for the account creation data
            PacketBuffer buffer = new PacketBuffer();

            // Add the new account request packet identifier and the account details
            buffer.AddInteger((int)ClientPackets.CReRoll);

            // Send the new account data to the server
            SendData(buffer.ToArray());

            // Dispose of the buffer after sending
            buffer.Dispose();
        }
    }
}