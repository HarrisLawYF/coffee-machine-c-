using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace coffee_machine_control.Functions
{
    public class coffeeMachine
    {
        private DevStates state;
        private int ID;
        private String IP;
        private String MAC;
        private String SSID;
        private String password;
        private int readDelay = 5000;
        private bool primeOn = false;
        private bool rfidOn = false;
        private Socket connection;
        private double weight = 0.0;
        private double totalDose = 0.0;
        private double fwVer = 0.0;
        private int totalMemSize = 0;
        private int usedMemSize = 0;
        private String animalEID = "";
        private String animalVID = "";

        private enum DevStates
        {
            STATE_SET_ID,
            STATE_SET_TIME,
            STATE_GET_SYS_INFO,
            STATE_GET_MEM_INFO,
            STATE_GET_ADAP_SETT,
            STATE_SET_FARM_INFO,
            STATE_DONE,
        }

        private byte LED_GREEN_BLINK = 0x01;
        private byte LED_GREEN_STOP = 0x02;
        private byte LED_ALL_STOP = 0x05;
        private byte LED_BLEED_START = 0x06;
        private byte LED_BLEED_DONE = 0x07;
        private byte LED_BLUE_BLINK = 0x08;
        private byte LED_BLUE_STOP = 0x09;
        private byte LED_PURPLE_BLINK = 0x0A;
        private byte LED_PURPLE_STOP = 0x0B;
        private byte LED_YELLOW_BLINK = 0x0C;
        private byte LED_YELLOW_STOP = 0x0D;
        private byte LED_WHITE_BLINK = 0x0E;
        private byte LED_WHITE_STOP = 0x0F;
        private byte LED_INDIGO_BLINK = 0x10;
        private byte LED_INDIGO_STOP = 0x11;
        private byte LED_GREEN_ON = 0x12;
        private byte LED_GREEN_OFF = 0x13;
        private byte LED_RED_ON = 0x14;
        private byte LED_RED_OFF = 0x15;
        private byte LED_BLUE_ON = 0x16;
        private byte LED_BLUE_OFF = 0x17;
        private byte LED_PURPLE_ON = 0x18;
        private byte LED_PURPLE_OFF = 0x19;
        private byte LED_YELLOW_ON = 0x1A;
        private byte LED_YELLOW_OFF = 0x1B;
        private byte LED_INDIGO_ON = 0x1C;
        private byte LED_INDIGO_OFF = 0x1D;
        private byte LED_WHITE_ON = 0x1E;
        private byte LED_WHITE_OFF = 0x1F;
        private byte LED_RED_BLINK = 0x03;
        private byte LED_RED_STOP = 0x04;

        public coffeeMachine(Socket Connection, String IP, int ID)
        {
            this.connection = Connection;
            this.IP = IP;
            this.ID = ID;
            this.MAC = "";
            this.state = DevStates.STATE_SET_ID;
            SetupDevice();
        }

        public int getID()
        {
            return ID;
        }

        public String getIP()
        {
            return IP;
        }

        public String getMAC()
        {
            return MAC;
        }

        public String getSSID()
        {
            return SSID;
        }

        public String getPassword()
        {
            return password;
        }

        public int getReadDelay()
        {
            return readDelay;
        }

        public bool isPrimeOn()
        {
            return primeOn;
        }

        public bool isRFIDOn()
        {
            return rfidOn;
        }

        public String getFwVerString()
        {
            return fwVer.ToString();
        }

        public void readMsg()
        {
            while (true)
            {
                byte[] request = new byte[255];
                int k = connection.Receive(request);
                Debug.WriteLine("--------New Msg-------------");
                Debug.WriteLine(BitConverter.ToString(request));
                processPacket(request, request.Length);

            }
        }

        public void setDateTime()
        {
            MemoryStream time_stream = new MemoryStream();
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Hour), 0, 1);
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Minute), 0, 1);
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Second), 0, 1);
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Day), 0, 1);
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Month), 0, 1);
            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Year % 100), 0, 1);
            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x08, time_stream.ToArray().Length, time_stream.ToArray(), 100);
            connection.Send(tcp.getBuffer());
        }

        public void Prime()
        {
            if (rfidOn == true)
            {
                Debug.WriteLine("Prime Not Available During RFID Scanning");
            }
            else
            {
                primeOn = !primeOn;
                if (primeOn)
                {
                    setDeviceLight(LED_PURPLE_BLINK);
                }
                else
                {
                    setDeviceLight(LED_PURPLE_STOP);
                }

                TcpPacket tcp = new TcpPacket(IP, 0x04, 0x0E, 0, null, 100);
                connection.Send(tcp.getBuffer());
            }
        }

        public void TurnRfidOn()
        {
            if (primeOn == false)
            {
                this.rfidOn = true;
                TcpPacket tcp = new TcpPacket(IP, 0x03, 0x09, 0, null, 100);
                connection.Send(tcp.getBuffer());
            }
            else
            {
                Debug.WriteLine("Info", "RFID Scanning Not Available During Prime");
            }
        }

        public void TurnRfidOff()
        {
            this.rfidOn = false;
            TcpPacket tcp = new TcpPacket(IP, 0x03, 0x0A, 0, null, 100);
            connection.Send(tcp.getBuffer());
        }

        public void setDeviceLight(int color)
        {
            MemoryStream light_stream = new MemoryStream();
            light_stream.Write(BitConverter.GetBytes(color), 0, 1);
            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x0F, light_stream.ToArray().Length, light_stream.ToArray(), readDelay);
            connection.Send(tcp.getBuffer());
        }

        private void SetupDevice()
        {
            Debug.WriteLine("Local(" + IP + "): " + Convert.ToString(state));
            switch (state)
            {
                case DevStates.STATE_SET_ID:
                    {
                        try
                        {
                            MemoryStream id_stream = new MemoryStream();
                            id_stream.Write(BitConverter.GetBytes(ID), 0, 1);
                            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x0B, id_stream.ToArray().Length, id_stream.ToArray(), readDelay);
                            connection.Send(tcp.getBuffer());
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("ID conf failed" + e.GetBaseException());
                            state = DevStates.STATE_DONE;
                        }

                    }
                    break;
                case DevStates.STATE_SET_TIME:
                    {
                        try
                        {
                            MemoryStream time_stream = new MemoryStream();
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Hour), 0, 1);
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Minute), 0, 1);
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Second), 0, 1);
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Day), 0, 1);
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Month), 0, 1);
                            time_stream.Write(BitConverter.GetBytes(DateTime.Now.Year % 100), 0, 1);
                            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x08, time_stream.ToArray().Length, time_stream.ToArray(), readDelay);
                            connection.Send(tcp.getBuffer());
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Time conf failed: " + e.GetBaseException());
                        }
                    }
                    break;
                case DevStates.STATE_GET_SYS_INFO:
                    {
                        try
                        {
                            int majorVersion = 1;
                            int minorVersion = 16;
                            MemoryStream version_stream = new MemoryStream();
                            version_stream.Write(BitConverter.GetBytes(majorVersion), 0, 1);
                            version_stream.Write(BitConverter.GetBytes(minorVersion), 0, 1);
                            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x09, version_stream.ToArray().Length, version_stream.ToArray(), readDelay);
                            connection.Send(tcp.getBuffer());

                            byte[] request = new byte[255];
                            connection.Receive(request);
                            Debug.WriteLine("--------New Msg-------------");
                            Debug.WriteLine(BitConverter.ToString(request));
                            processPacket(request, request.Length);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Sys conf failed: " + e.GetBaseException());
                        }
                    }

                    break;
                case DevStates.STATE_GET_MEM_INFO:
                    {
                        try
                        {
                            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x0A, 0, null, readDelay);
                            connection.Send(tcp.getBuffer());

                            byte[] request = new byte[255];
                            connection.Receive(request);
                            Debug.WriteLine("--------New Msg-------------");
                            Debug.WriteLine(BitConverter.ToString(request));
                            processPacket(request, request.Length);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Sys conf failed: " + e.GetBaseException());
                        }
                    }
                    break;
                case DevStates.STATE_GET_ADAP_SETT:
                    {
                        try
                        {
                            TcpPacket tcp = new TcpPacket(IP, 0x04, 0x0D, 0, null, readDelay);
                            connection.Send(tcp.getBuffer());

                            byte[] request = new byte[255];
                            connection.Receive(request);
                            Debug.WriteLine("--------New Msg-------------");
                            Debug.WriteLine(BitConverter.ToString(request));
                            processPacket(request, request.Length);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Adap get failed: " + e.GetBaseException());
                        }
                    }
                    break;
                case DevStates.STATE_SET_FARM_INFO:
                    break;
                case DevStates.STATE_DONE:
                    {
                        Debug.WriteLine("Setup Device Finished");
                        readMsg();
                    }
                    break;
            }
            if (state < DevStates.STATE_DONE)
            {
                Task.Delay(500).Wait();
                state++;
                SetupDevice();
            }
            else
            {
                state = DevStates.STATE_SET_ID;
            }
        }

        private int convertByteArrayToInt(byte[] b, int offset)
        {
            return b[3 + offset] & 0xFF |
                    (b[2 + offset] & 0xFF) << 8 |
                    (b[1 + offset] & 0xFF) << 16 |
                    (b[0 + offset] & 0xFF) << 24;
        }

        private String convertBytesToHex(byte[] input)
        {
            try
            {
                StringBuilder hex = new StringBuilder();
                foreach (byte b in input)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                return hex.ToString();
            }
            catch (Exception e)
            {
                return "Error converting: " + e.GetBaseException();
            }
        }

        private void processPacket(byte[] buffer, int len)
        {
            TcpPacket pck = new TcpPacket(buffer, len);
            int pckId = 0;
            pckId = pck.getId();
            switch (pckId)
            {
                case 0x0104:
                    {
                        Debug.WriteLine("GET password 0104", convertBytesToHex(pck.getData()));
                        password = convertBytesToHex(pck.getData());
                        break;
                    }
                case 0x0102:// get ssid
                    {
                        Debug.WriteLine("GET SSID 0102", convertBytesToHex(pck.getData()));
                    }
                    break;
                case 0x040D: // adapter settings
                    {
                        Debug.WriteLine("ADAPTER SETT 040D", convertBytesToHex(pck.getData()));
                        setDeviceLight(LED_YELLOW_ON);
                    }
                    break;
                case 0x0209: // system info
                    {
                        byte[] res = pck.getData();
                        Debug.WriteLine("SYS INFO 0209 (" + convertBytesToHex(res).Length.ToString() + ")", convertBytesToHex(res));
                        fwVer = res[1] | res[0] << 8;
                        if (convertBytesToHex(res).Length > 12)
                        {
                            String rawMac = convertBytesToHex(res);
                            MAC = rawMac[0] + rawMac[1] + ":" + rawMac[2] + rawMac[3] + ":" + rawMac[4] + rawMac[5] + ":" + rawMac[6] + rawMac[7] + ":" + rawMac[8] + rawMac[9] + ":" + rawMac[10] + rawMac[11];
                        }
                        else
                        {
                            int majorVersion = 1;
                            int minorVersion = 16;

                            /*MemoryStream version_stream = new MemoryStream();
                            version_stream.Write(BitConverter.GetBytes(majorVersion), 0, 1);
                            version_stream.Write(BitConverter.GetBytes(minorVersion), 0, 1);
                            TcpPacket tcp = new TcpPacket(IP, 0x02, 0x09, version_stream.ToArray().Length, version_stream.ToArray(), readDelay);
                            Stream stm = connection.GetStream();
                            stm.Write(tcp.getBuffer(), 0, tcp.getBuffer().Length);*/
                        }
                    }
                    break;
                case 0x020A:
                    {
                        byte[] res = pck.getData();
                        Debug.WriteLine("MEM INFO 020A", convertBytesToHex(res));
                        totalMemSize = convertByteArrayToInt(res, 0);
                        usedMemSize = convertByteArrayToInt(res, 4);
                    }
                    break;
                case 0x040C:
                    {
                        Debug.WriteLine("RECEIVE TREATMENT 040C", convertBytesToHex(pck.getData()));
                    }
                    break;
                case 0x0410:
                    {
                        Debug.WriteLine("MEDIC CONFIG REQ 0410", convertBytesToHex(pck.getData()));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
