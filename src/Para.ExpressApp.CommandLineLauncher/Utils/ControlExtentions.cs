using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Para.ExpressApp.CommandLineLauncher.Win.Utils
{
    public static class ControlExtentions
    {
        public delegate void InvokeHandler();

        public static void SafeInvoke(this Control control, InvokeHandler handler)
        {
            if (control.InvokeRequired) control.Invoke(handler);
            else handler();
        }
    }
}
