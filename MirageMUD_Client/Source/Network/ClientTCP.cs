using System;
using System.Net.Sockets;
using Bindings;

namespace MirageMUD_Client.Source.Network
{
    internal class ClientTCP
    {
        public TcpClient PlayerSocket;
        public static NetworkStream myStream;
        private CHandleData handleData;
        private byte[] asyncBuff;

        private bool connecting;
        private bool connected;

        public void ConnectToServer()
        {
            if(PlayerSocket != null)
            {
                if (PlayerSocket.Connected || connected)
                    return;
                PlayerSocket.Close();
                PlayerSocket = null;
            }
            PlayerSocket = new TcpClient();
            handleData = new CHandleData();
            PlayerSocket.ReceiveBufferSize = 4096;
            PlayerSocket.SendBufferSize = 4096;
            PlayerSocket.NoDelay = false;
            Array.Resize(ref asyncBuff, 8192);

            PlayerSocket.BeginConnect("127.0.0.1", 7777, new AsyncCallback(ConnectCallback), PlayerSocket);
            connecting = true;
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            PlayerSocket.EndConnect(ar);
            if(PlayerSocket.Connected == false)
            {
                connecting = false;
                connected = false;
                return;
            }
            else
            {
                PlayerSocket.NoDelay = true;
                myStream = PlayerSocket.GetStream();
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
                connected = true;
                connecting = false;
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            int byteAMT = myStream.EndRead(ar);
            byte[] myBytes = null;
            Array.Resize(ref myBytes, byteAMT);
            Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteAMT);

            if(byteAMT == 0)
            {
                //DestroyGame
                return;
            }

            handleData.HandleMessages(myBytes);
            myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
        }

        public void SendData(byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);
            myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
            buffer.Dispose();
        }

        public void SendLogin()
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddInteger((int)ClientPackets.CLogin);
            buffer.AddString("Xlithan");
            buffer.AddString("testing123");
            buffer.AddByte(1);
            buffer.AddByte(0);
            buffer.AddByte(0);
            SendData(buffer.ToArray());
            buffer.Dispose();
        }
    }
}
