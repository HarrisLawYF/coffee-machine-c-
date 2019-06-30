using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coffee_machine_control;
namespace coffee_machine_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main floatBtn = new main();
            //Requires external system to activate Windows Mobile Hotspot, and search for the IP range.
            //For testing, replace this hardcoded IP with others.
            floatBtn.getFormControl("192.168.137").Show();
        }
    }
}
