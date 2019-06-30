using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace coffee_machine_control.tools
{
    public partial class startBtn : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(gpath);
            base.OnPaint(e);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
