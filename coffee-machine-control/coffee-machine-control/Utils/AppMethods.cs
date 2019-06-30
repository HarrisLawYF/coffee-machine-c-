using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee_machine_control.Utils
{
    public class AppMethods
    {
        public static String secondsToDateTime(long Seconds, String dateFormat)
        {
            DateTime dt = DateTime.MinValue;
            DateTime dtfommls = dt.AddMilliseconds(Seconds);
            return dtfommls.ToString();
        }
    }
}
