using System.Text;

namespace Bindings
{
    internal class PacketBuffer : IDisposable
    {
        // Buffer for storing data
        private List<byte> Buff;

        // Temporary buffer for reading
        private byte[] readBuff;

        // Current read position in the buffer
        private int readpos;

        // Tracks if the buffer has been updated
        private bool buffUpdate = false;

        // Constructor to initialise the buffer and read position
        public PacketBuffer()
        {
            Buff = new List<byte>();
            readpos = 0;
        }

        // Returns the current read position
        public int GetReadPos()
        {
            return readpos;
        }

        // Converts the buffer to a byte array
        public byte[] ToArray()
        {
            return Buff.ToArray();
        }

        // Returns the total number of bytes in the buffer
        public int Count()
        {
            return Buff.Count;
        }

        // Returns the number of unread bytes in the buffer
        public int Length()
        {
            return Count() - readpos;
        }

        // Clears the buffer and resets the read position
        public void Clear()
        {
            Buff.Clear();
            readpos = 0;
        }

        // Adds an integer (4 bytes) to the buffer
        public void AddInteger(int Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        // Adds a float (4 bytes) to the buffer
        public void AddFloat(float Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        // Adds a string (length-prefixed) to the buffer
        public void AddString(string Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input.Length)); // Add length prefix
            Buff.AddRange(Encoding.ASCII.GetBytes(Input));      // Add string data
            buffUpdate = true;
        }

        // Adds a single byte to the buffer
        public void AddByte(byte Input)
        {
            Buff.Add(Input);
            buffUpdate = true;
        }

        // Adds a byte array to the buffer
        public void AddBytes(byte[] Input)
        {
            Buff.AddRange(Input);
            buffUpdate = true;
        }

        // Adds a short (2 bytes) to the buffer
        public void AddShort(short Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        // Retrieves an integer (4 bytes) from the buffer
        public int GetInteger(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                UpdateReadBufferIfNecessary();
                int ret = BitConverter.ToInt32(readBuff, readpos);
                if (peek) readpos += 4; // Advance position if peeking
                return ret;
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieves a float (4 bytes) from the buffer
        public float GetFloat(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                UpdateReadBufferIfNecessary();
                float ret = BitConverter.ToSingle(readBuff, readpos);
                if (peek) readpos += 4;
                return ret;
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieves a string (length-prefixed) from the buffer
        public string GetString(bool peek = true)
        {
            int length = GetInteger(true); // Get string length
            UpdateReadBufferIfNecessary();
            string ret = Encoding.ASCII.GetString(readBuff, readpos, length);
            if (peek) readpos += length; // Advance position if peeking
            return ret;
        }

        // Retrieves a single byte from the buffer
        public byte GetByte(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                UpdateReadBufferIfNecessary();
                byte ret = readBuff[readpos];
                if (peek) readpos += 1;
                return ret;
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieves a byte array of specified length from the buffer
        public byte[] GetBytes(int length, bool peek = true)
        {
            UpdateReadBufferIfNecessary();
            byte[] ret = Buff.GetRange(readpos, length).ToArray();
            if (peek) readpos += length;
            return ret;
        }

        // Retrieves a short (2 bytes) from the buffer
        public short GetShort(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                UpdateReadBufferIfNecessary();
                short ret = BitConverter.ToInt16(readBuff, readpos);
                if (peek) readpos += 2;
                return ret;
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Updates the read buffer if the buffer has been modified
        private void UpdateReadBufferIfNecessary()
        {
            if (buffUpdate)
            {
                readBuff = Buff.ToArray();
                buffUpdate = false;
            }
        }

        // Tracks whether the object has been disposed
        private bool disposedValue = false;

        // Handles cleanup of resources
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Buff.Clear(); // Clear the buffer
                }
                readpos = 0;
                disposedValue = true;
            }
        }

        // Public Dispose method
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}