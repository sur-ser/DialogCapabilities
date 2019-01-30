using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DialogCapabilities
{
    public static class BaseDialog
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);

        public static IntPtr Catch(string processTitle, int timeOutMs = 15000, int waitStep = 50)
        {
            var dialogHWnd = FindWindow(null, processTitle);
            var setFocus = SetForegroundWindow(dialogHWnd);

            Stopwatch st = new Stopwatch();
            st.Start();

            while (st.ElapsedMilliseconds < timeOutMs)
            {
                var catched = FindWindow(null, processTitle);

                if (catched != IntPtr.Zero)
                    return catched;

                Task.Delay(waitStep);
            }

            throw new ControlNotFoundException(processTitle, timeOutMs);
        }

        public static IntPtr CatchControlIn(IntPtr hWnd, string elemName, int timeOutMs = 3000, int waitStep = 50)
        {
            IntPtr result = IntPtr.Zero;

            Stopwatch st = new Stopwatch();
            st.Start();

            while (st.ElapsedMilliseconds < timeOutMs)
            {
                result =  FindWindowEx(hWnd, IntPtr.Zero, elemName, null);

                if (result != IntPtr.Zero)
                    return result;

                Task.Delay(waitStep);
            }

            throw new ControlNotFoundException(elemName,timeOutMs);
        }

        public static void SendText(IntPtr hCntrl, string text)
        {
            SendMessage(hCntrl, 0X000C, 0, text);
        }

        public static void SendClick(IntPtr hCntrl)
        {
            SendMessage(hCntrl, 245, 0, null);
        }
    }
}
