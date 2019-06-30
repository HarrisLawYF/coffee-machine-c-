using System.Drawing;
using System.Windows.Forms;

namespace coffee_machine_control
{
    public partial class mainControlPanel : Form
    {
        private int adjustableRight = 50;
        private int adjustableBottom = 53;
        public mainControlPanel(int marginRight, int marginBottom)
        {
            InitializeComponent();
            initView(marginRight, marginBottom);
        }
        private void initView(int marginRight, int marginBottom)
        {
            this.Location = new Point(Screen.AllScreens[0].WorkingArea.Right - this.Width - marginRight - adjustableRight, Screen.AllScreens[0].WorkingArea.Bottom - this.Height - marginBottom + adjustableBottom);
            cornerCut.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }

        private void panel1_MouseEnter(object sender, System.EventArgs e)
        {
            panel1.BackColor = Color.DarkSalmon;
        }

        private void panel1_MouseLeave(object sender, System.EventArgs e)
        {
            panel1.BackColor = Color.White;
        }

        private void panel2_MouseEnter(object sender, System.EventArgs e)
        {
            panel2.BackColor = Color.DarkSalmon;
        }

        private void panel2_MouseLeave(object sender, System.EventArgs e)
        {
            panel2.BackColor = Color.White;
        }

        private void panel3_MouseEnter(object sender, System.EventArgs e)
        {
            panel3.BackColor = Color.DarkSalmon;
        }

        private void panel3_MouseLeave(object sender, System.EventArgs e)
        {
            panel3.BackColor = Color.White;
        }
    }
}
