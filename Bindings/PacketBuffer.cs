using System;
using System.Collections.Generic;
using System.Text;

namespace Bindings
{
    internal class PacketBuffer : IDisposable
    {
        // Stores the buffer as a list of bytes
        List<byte> Buff;

        // Temporary array for reading data
        byte[] readBuff;

        // Tracks the current reading position in the buffer
        int readpos;

        // Indicates whether the buffer has been updated
        bool buffUpdate = false;

        // Constructor: Initialises the buffer and reading position
        public PacketBuffer()
        {
            Buff = new List<byte>(); // Initialise the buffer list
            readpos = 0;             // Set initial reading position to 0
        }

        // Returns the current reading position
        public int GetReadPos()
        {
            return readpos; // Return the index of the current read position
        }

        // Converts the buffer to a byte array
        public byte[] ToArray()
        {
            return Buff.ToArray(); // Convert the list of bytes to an array
        }

        // Returns the total number of bytes in the buffer
        public int Count()
        {
            return Buff.Count; // Return the total count of bytes in the buffer
        }

        // Returns the number of unread bytes in the buffer
        public int Length()
        {
            return Count() - readpos; // Subtract read position from total count
        }

        // Clears the buffer and resets the reading position
        public void Clear()
        {
            Buff.Clear();    // Clear all bytes in the buffer
            readpos = 0;     // Reset the reading position to the start
        }

        // Add integer (4 bytes) to the buffer
        public void AddInteger(int Input)
        {
            // Convert the integer to a byte array and add it to the buffer
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true; // Mark the buffer as updated
        }

        // Add float (4 bytes) to the buffer
        public void AddFloat(float Input)
        {
            // Convert the float to a byte array and add it to the buffer
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true; // Mark the buffer as updated
        }

        // Add string to the buffer (length-prefixed)
        public void AddString(string Input)
        {
            // Add the string's length as a 4-byte integer
            Buff.AddRange(BitConverter.GetBytes(Input.Length));

            // Add the string's characters as bytes
            Buff.AddRange(Encoding.ASCII.GetBytes(Input));

            buffUpdate = true; // Mark the buffer as updated
        }

        // Add single byte to the buffer
        public void AddByte(byte Input)
        {
            Buff.Add(Input);    // Add the byte to the buffer
            buffUpdate = true;  // Mark the buffer as updated
        }

        // Add byte array to the buffer
        public void AddBytes(byte[] Input)
        {
            Buff.AddRange(Input); // Add the array of bytes to the buffer
            buffUpdate = true;    // Mark the buffer as updated
        }

        // Add short (2 bytes) to the buffer
        public void AddShort(short Input)
        {
            // Convert the short to a byte array and add it to the buffer
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true; // Mark the buffer as updated
        }

        // Retrieve integer (4 bytes) from the buffer
        public int GetInteger(bool peek = true)
        {
            // Check if there are enough bytes left to read an integer
            if (Buff.Count > readpos)
            {
                // Update the read buffer if necessary
                if (buffUpdate)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                // Read the integer from the current position
                int ret = BitConverter.ToInt32(readBuff, readpos);

                // Move the read position forward by 4 bytes if peek is true
                if (peek) readpos += 4;

                return ret; // Return the read integer
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieve float (4 bytes) from the buffer
        public float GetFloat(bool peek = true)
        {
            // Check if there are enough bytes left to read a float
            if (Buff.Count > readpos)
            {
                // Update the read buffer if necessary
                if (buffUpdate)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                // Read the float from the current position
                float ret = BitConverter.ToSingle(readBuff, readpos);

                // Move the read position forward by 4 bytes if peek is true
                if (peek) readpos += 4;

                return ret; // Return the read float
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieve string (length-prefixed) from the buffer
        public string GetString(bool peek = true)
        {
            // Get the length of the string (stored as a 4-byte integer)
            int length = GetInteger(true);

            // Update the read buffer if necessary
            if (buffUpdate)
            {
                readBuff = Buff.ToArray();
                buffUpdate = false;
            }

            // Read the string using the length and current position
            string ret = Encoding.ASCII.GetString(readBuff, readpos, length);

            // Move the read position forward by the string length if peek is true
            if (peek) readpos += length;

            return ret; // Return the read string
        }

        // Retrieve single byte from the buffer
        public byte GetByte(bool peek = true)
        {
            // Check if there are enough bytes left to read
            if (Buff.Count > readpos)
            {
                // Update the read buffer if necessary
                if (buffUpdate)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                // Read the byte at the current position
                byte ret = readBuff[readpos];

                // Move the read position forward by 1 byte if peek is true
                if (peek) readpos += 1;

                return ret; // Return the read byte
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Retrieve byte array of specified length from the buffer
        public byte[] GetBytes(int length, bool peek = true)
        {
            // Update the read buffer if necessary
            if (buffUpdate)
            {
                readBuff = Buff.ToArray();
                buffUpdate = false;
            }

            // Read the specified number of bytes
            byte[] ret = Buff.GetRange(readpos, length).ToArray();

            // Move the read position forward by the length if peek is true
            if (peek) readpos += length;

            return ret; // Return the byte array
        }

        // Retrieve short (2 bytes) from the buffer
        public short GetShort(bool peek = true)
        {
            // Check if there are enough bytes left to read a short
            if (Buff.Count > readpos)
            {
                // Update the read buffer if necessary
                if (buffUpdate)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                // Read the short from the current position
                short ret = BitConverter.ToInt16(readBuff, readpos);

                // Move the read position forward by 2 bytes if peek is true
                if (peek) readpos += 2;

                return ret; // Return the read short
            }
            throw new Exception("Packet Buffer is past its limit.");
        }

        // Tracks whether the object has been disposed
        private bool disposedValue = false;

        // Handles resource cleanup
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Buff.Clear(); // Clear buffer resources
                }

                readpos = 0; // Reset reading position
                disposedValue = true; // Mark as disposed
            }
        }

        // Public Dispose method to clean up resources
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Suppress finalisation by garbage collector
        }
    }
}
