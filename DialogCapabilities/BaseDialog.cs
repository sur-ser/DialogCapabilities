using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DialogCapabilities
{
    public static class BaseDialog
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
        public static IntPtr Catch(string processTitle, int timeOutMs = 15000, int waitStep = 50)
        {
            var dialogHWnd = FindWindow(null, processTitle);
            var setFocus = SetForegroundWindow(dialogHWnd);

            Stopwatch st = new Stopwatch();
            st.Start();

            while (st.ElapsedMilliseconds < timeOutMs)
            {
                Task.Delay(waitStep);
                var catched = FindWindow(null, processTitle);

                if (catched != IntPtr.Zero)
                {
                    return catched;
                }
            }

            return IntPtr.Zero;
        }

        public static bool PerformAction(IntPtr dialogHWnd, DialogCommand command)
        {
            var setFocus = SetForegroundWindow(dialogHWnd);
            if (setFocus)
            {
                System.Windows.Forms.SendKeys.SendWait(command.Command);
                return true;
            }

            return false;
        }
    }
}
