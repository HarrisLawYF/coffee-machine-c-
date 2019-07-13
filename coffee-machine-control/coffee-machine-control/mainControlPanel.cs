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
            this.TopMost = true;
            this.TransparencyKey = Color.LimeGreen;
        }

        private void espresso_MouseEnter(object sender, System.EventArgs e)
        {
            espressoPanel.BackColor = Color.DarkSalmon;
        }

        private void espresso_MouseLeave(object sender, System.EventArgs e)
        {
            espressoPanel.BackColor = Color.White;
        }

        private void machiato_MouseEnter(object sender, System.EventArgs e)
        {
            machiatoPanel.BackColor = Color.DarkSalmon;
        }

        private void machiato_MouseLeave(object sender, System.EventArgs e)
        {
            machiatoPanel.BackColor = Color.White;
        }

        private void americano_MouseEnter(object sender, System.EventArgs e)
        {
            americanoPanel.BackColor = Color.DarkSalmon;
        }

        private void americano_MouseLeave(object sender, System.EventArgs e)
        {
            americanoPanel.BackColor = Color.White;
        }
    }
}
