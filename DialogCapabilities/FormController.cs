using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogCapabilities
{
    public static class FormController
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClass, string lpCation);

        public static IntPtr Catch(string processTitle, int timeOutMs = 15000, int waitStep = 50)
        {
            var dialogHWnd = FindWindow(null, processTitle);

            Stopwatch st = new Stopwatch();
            st.Start();

            while (st.ElapsedMilliseconds < timeOutMs)
            {
                var catched = FindWindow(null, processTitle);

                if (catched != IntPtr.Zero)
                    return catched;

                Thread.Sleep(waitStep);
                //Task.Delay(waitStep);
            }

            throw new ControlNotFoundException(processTitle, timeOutMs);
        }
     
    }

    public static class IntPtrExtension
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);
        
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        /// <summary>
        /// Catch direct child of window
        /// </summary>
        public static IntPtr CatchControl(this IntPtr hWnd, string elemClass, int timeOutMs = 8000, int waitStep = 50)
        {
            IntPtr result = IntPtr.Zero;

            Stopwatch st = new Stopwatch();
            st.Start();

            while (st.ElapsedMilliseconds < timeOutMs)
            {
                result = FindWindowEx(hWnd, IntPtr.Zero, elemClass, null);

                if (result != IntPtr.Zero)
                    return result;

                Thread.Sleep(waitStep);
            }

            throw new ControlNotFoundException(elemClass, timeOutMs);
        }

        public static IntPtr CatchControlByPath(this IntPtr hWnd, string elemPath)
        {
            string[] elemClasses = elemPath.TrimEnd('/').Split('/');

            var currIntPtr = hWnd;
            foreach (string className in elemClasses)
            {
                currIntPtr = currIntPtr.CatchControl(className);
            }

            return currIntPtr;
        }

        const int WM_SETTEXT = 0X000C;
        const int WM_CLOSE = 0x0010;
        const int WM_LMB = 245;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;


        private static IntPtr Send(this IntPtr hCntrl, int WM, string txt = null)
        {
            SendMessage(hCntrl, WM, 0, txt);
            return hCntrl;
        }

        public static IntPtr SendText(this IntPtr hCntrl, string text) =>
            Send(hCntrl, WM_SETTEXT, text);

        public static IntPtr CloseWindow(this IntPtr hCntrl) =>
            Send(hCntrl, WM_CLOSE);

        public static IntPtr SendClick(this IntPtr hCntrl) =>
            Send(hCntrl, WM_LMB);
        
        public static IntPtr SetForeground(this IntPtr hWnd)
        {
            SetForegroundWindow(hWnd);

            return hWnd;
        }

        /// <summary>
        /// Works ONLY for foreground Window
        /// </summary>
        public static IntPtr SendKeys(this IntPtr hCtrl, string keysStr)
        {
            System.Windows.Forms.SendKeys.SendWait(keysStr);
            System.Windows.Forms.SendKeys.Flush();
            return hCtrl;
        }

        /// <summary>
        /// Works ONLY for foreground Window
        /// </summary>
        public static IntPtr SendKeys(this IntPtr hCtrl, DialogCommand cmnd) =>
            hCtrl.SendKeys(cmnd.ToString());


    }
}
