using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Bindings;

namespace MirageMUD_Server
{
    internal class WSClient
    {
        /// <summary>
        /// A reference to the SHandleData that should be used to handle data for this client.
        /// </summary>
        private readonly SHandleData _sHandleData;

        public int Index;
        public string IP;
        public WebSocket Socket;  // Change TcpClient to WebSocket
        public bool Closing;
        public byte[] readBuff;

        /// <summary>
        /// Constructor for a WSClient object.
        /// Accepts an SHandleData object that will be used to handle data.
        /// </summary>
        /// <param name="sHandleData">The data handler to use.</param>
        public WSClient(SHandleData sHandleData)
        {
            _sHandleData = sHandleData;
        }

        public async Task Start(WebSocket webSocket)
        {
            Socket = webSocket;
            Array.Resize(ref readBuff, 4096); // Resize buffer
            await ReceiveDataAsync();
        }

        private async Task ReceiveDataAsync()
        {
            try
            {
                // Continuously receive data from the WebSocket
                while (Socket.State == WebSocketState.Open)
                {
                    var result = await Socket.ReceiveAsync(new ArraySegment<byte>(readBuff), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed", CancellationToken.None);
                        CloseSocket(Index); // Disconnect client
                        return;
                    }

                    // Handle the received data
                    byte[] receivedData = new byte[result.Count];
                    Array.Copy(readBuff, receivedData, result.Count);

                    _sHandleData.HandleMessages(Index, receivedData);
                }
            }
            catch (Exception)
            {
                CloseSocket(Index); // Disconnect client
            }
        }

        private void CloseSocket(int index)
        {
            Console.WriteLine(string.Format(
                TranslationManager.Instance.GetTranslation("connection.terminated"),
                IP));
            Socket.Abort();
            Socket = null;
        }
    }
}