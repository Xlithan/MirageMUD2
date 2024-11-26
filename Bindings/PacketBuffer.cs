using System;
using System.Collections.Generic;
using System.Text;

namespace Bindings
{
    internal class PacketBuffer : IDisposable
    {
        List<byte> Buff;
        byte[] readBuff;
        int readpos;
        bool buffUpdate = false;

        public PacketBuffer()
        {
            Buff = new List<byte>();
            readpos = 0;
        }

        public int GetReadPos()
        {
            return readpos;
        }

        public byte[] ToArray()
        {
            return Buff.ToArray();
        }

        public int Count()
        {
            return Buff.Count;
        }

        public int Length()
        {
            return Count() - readpos;
        }

        public void Clear()
        {
            Buff.Clear();
            readpos = 0;
        }

        // Write Data
        public void AddInteger(int Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        public void AddFloat(float Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        public void AddString(string Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input.Length));
            Buff.AddRange(Encoding.ASCII.GetBytes(Input));
            buffUpdate = true;
        }

        public void AddByte(byte Input)
        {
            Buff.Add(Input);
            buffUpdate = true;
        }

        public void AddBytes(byte[] Input)
        {
            Buff.AddRange(Input);
            buffUpdate = true;
        }

        public void AddShort(short Input)
        {
            Buff.AddRange(BitConverter.GetBytes(Input));
            buffUpdate = true;
        }

        // Read Data
        public int GetInteger(bool peek = true)
        {
            if(Buff.Count > readpos)
            {
                if(buffUpdate == true)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                int ret = BitConverter.ToInt32(readBuff, readpos);
                if(peek && Buff.Count > readpos)
                {
                    readpos += 4;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limit.");
            }
        }

        public float GetFloat(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                if (buffUpdate == true)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                float ret = BitConverter.ToSingle(readBuff, readpos);
                if (peek && Buff.Count > readpos)
                {
                    readpos += 4;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limit.");
            }
        }

        public string GetString(bool peek = true)
        {
            int length = GetInteger(true);
            if (buffUpdate == true)
            {
                readBuff = Buff.ToArray();
                buffUpdate = false;
            }

            string ret = Encoding.ASCII.GetString(readBuff, readpos, length);
            if (peek && Buff.Count > readpos)
            {
                if(ret.Length > 0)
                {
                    readpos += length;
                }
            }
            return ret;
        }

        public byte GetByte(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                if (buffUpdate == true)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                byte ret = readBuff[readpos];
                if (peek && Buff.Count > readpos)
                {
                    readpos += 1;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limit.");
            }
        }

        public byte[] GetBytes(int length, bool peek = true)
        {
            if (buffUpdate == true)
            {
                readBuff = Buff.ToArray();
                buffUpdate = false;
            }

            byte[] ret = Buff.GetRange(readpos, length).ToArray();
            if(peek)
            {
                readpos += length;
            }
            return ret;
        }

        public short GetShort(bool peek = true)
        {
            if (Buff.Count > readpos)
            {
                if (buffUpdate == true)
                {
                    readBuff = Buff.ToArray();
                    buffUpdate = false;
                }

                short ret = BitConverter.ToInt16(readBuff, readpos);
                if (peek && Buff.Count > readpos)
                {
                    readpos += 4;
                }
                return ret;
            }
            else
            {
                throw new Exception("Packet Buffer is past its limit.");
            }
        }

        private bool disposedValue = false;

        //IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if(disposing)
                {
                    Buff.Clear();
                }

                readpos = 0;
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
