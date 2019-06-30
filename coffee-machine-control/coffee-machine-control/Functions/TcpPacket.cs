using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee_machine_control.Functions
{
    public class TcpPacket
    {
        private byte[] Data;
        private String IP;
        private int Delay;

        public TcpPacket(byte[] data, int Len)
        {
            Data = new byte[Len];
            System.Array.Copy(data, 0, Data, 0, Len);
            this.IP = "";
            this.Delay = 0;
        }
        public TcpPacket(String IP, byte ClassID, byte CommandID, int Length, byte[] data, int delay)
        {

            this.Delay = delay;
            this.IP = IP;
            int appendedDataLength = 0;

            if (data != null)
            {
                appendedDataLength = data.Length;
            }
            Data = new byte[4 + appendedDataLength];
            Data[0] = ClassID;
            Data[1] = CommandID;
            Data[2] = (byte)Length;
            Data[3] = (byte)(Length >> 8);

            if (data != null)
            {
                System.Array.Copy(data, 0, Data, 4, data.Length);
            }
        }

        public int getDelay()
        {
            return Delay;
        }

        public String getIP()
        {
            return IP;
        }

        public int getId()
        {
            return (int)Data[0] << 8 | Data[1];
        }

        public byte getClassId()
        {
            return Data[0];
        }

        public byte getCommandId()
        {
            return Data[1];
        }

        public int getDataLength()
        {
            return Data[3] | Data[2];
        }

        public byte[] getBuffer()
        {
            Debug.WriteLine("Packet:" + BitConverter.ToString(Data));
            return Data;
        }

        public byte[] getData()
        {
            int len = getDataLength();
            if (Data.Length < len + 4)
            {
                return null;
            }
            byte[] buf = new byte[len];
            System.Array.Copy(Data, 4, buf, 0, len);
            return buf;
        }
    }
}
