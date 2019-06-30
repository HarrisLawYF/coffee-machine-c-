using System;
using System.Windows.Forms;

namespace coffee_machine_control
{
    public sealed class main
    {
        public main()
        {
        }

        public Form getFormControl(String IPRange)
        {
            mainControl control = new mainControl(IPRange);
            return control;
        }
    }
}
