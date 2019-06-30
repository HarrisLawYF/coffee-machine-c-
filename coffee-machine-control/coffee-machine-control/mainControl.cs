using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using coffee_machine_control.Functions;

namespace coffee_machine_control
{
    public partial class mainControl : Form
    {

        private List<Socket> Connections = null;
        private List<coffeeMachine> devices = null;
        private List<String> IPs = null;
        private int counter;
        private int range = 255;
        private bool isPanelAvailable = false;
        private String IPRange = "";
        private int marginRight = 20;
        private mainControlPanel mcp;

        public mainControl(String IPRange)
        {
            InitializeComponent();
            initView();
            Connections = new List<Socket>();
            IPs = new List<string>();
            devices = new List<coffeeMachine>();
            counter = -999;
                        this.IPRange = IPRange;
        }

        private void initView()
        {
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Right - this.Width - marginRight, Screen.AllScreens[0].WorkingArea.Bottom - this.Height);
            this.startBtn1.Image = ((System.Drawing.Image)(Properties.Resources.logo1));
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            this.startBtn1.Image = ((System.Drawing.Image)(Properties.Resources.logo1));
            //TODO: move this to a form
            connect(IPRange);
        }

        public async void connect(String ip)
        {
            if (isPanelAvailable == false)
            {
                isPanelAvailable = !isPanelAvailable;
                mcp = new mainControlPanel(marginRight,startBtn1.Height);
                mcp.Show();
                this.BringToFront();
                updateLabelDetails("Initiating...");
                counter = 30;
                Task.Run(() => countdown());
                Task.Factory.StartNew(() => createConnection(ip, 1));
            }
            else
            {
                isPanelAvailable = !isPanelAvailable;
                mcp.Close();
            }
        }

        private async void countdown()
        {
            if (isPanelAvailable == true)
            {
                if (counter <= 0)
                {
                    //Do nothing
                }
                else
                {
                    counter -= 1;
                    await Task.Delay(1000);
                    countdown();
                }
            }
        }

        private void updateLabelDetails(String text)
        {
            /*if (processLb.InvokeRequired)
            {
                processLb.BeginInvoke((MethodInvoker)delegate () { processLb.Text = text; });
            }
            else
            {
                processLb.Text = text;
            }*/
        }

        private async Task createConnection(String front, int end)
        {
            if (isPanelAvailable == true)
            {
                String ip = front + "." + end.ToString();
                if (IPs.Contains(ip))
                {
                    //Do nothing
                }
                else
                {
                    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddr = IPAddress.Parse(ip);
                    IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 13000);
                    Socket connection = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        updateLabelDetails("Connecting...");
                        IAsyncResult result = connection.BeginConnect(localEndPoint, null, null);
                        bool success = result.AsyncWaitHandle.WaitOne(50, true);
                        if (connection.Connected)
                        {
                            this.startBtn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.hoverLogo));
                            updateLabelDetails("Connected succeeded: " + ip);
                            Connections.Add(connection);
                            IPs.Add(ip);
                            coffeeMachine device = new coffeeMachine(connection, ip, devices.Count + 1);
                            devices.Add(device);
                        }
                        else
                        {
                            Debug.WriteLine("Connected failed exception...");
                        }
                    }
                    catch (Exception e)
                    {
                        updateLabelDetails("Error accepted: " + e.GetBaseException());
                    }

                    if (counter <= 0)
                    {
                        //Do nothing
                    }
                    else if (end >= range && counter > 0)
                    {
                        Task.Factory.StartNew(() => createConnection(front, 1));
                    }
                    else
                    {
                        Task.Factory.StartNew(() => createConnection(front, end + 1));
                    }
                }
            }
            else
            {
            }
        }

        private void mainControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            isPanelAvailable = false;
        }

        private void startBtn_MouseEnter(object sender, EventArgs e)
        {
            this.startBtn1.Image = ((System.Drawing.Image)(Properties.Resources.rotateLogo));
            
        }

        private void startBtn_MouseLeave(object sender, EventArgs e)
        {
            this.startBtn1.Image = ((System.Drawing.Image)(Properties.Resources.logo1));
        }
    }
}
