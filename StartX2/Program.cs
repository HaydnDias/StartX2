using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartX2
{
    class Program
    {
        static void Main(string[] args)
        {
            // args[0] - Process
            // args[1] - X coord
            // args[2] - Y coord
            // args[3] - milliseconds to wait, defaulted to 500
            try
            {
                using (Process StartedApp = new Process())
                {
                    const short SWP_NOSIZE = 1;
                    const short SWP_NOZORDER = 0X4;
                    const int SWP_SHOWWINDOW = 0x0040;
                    StartedApp.StartInfo.FileName = args[0];
                    StartedApp.Start();
                    Thread.Sleep(args.Length == 4 ? int.Parse(args[3]) : 500);
                    SetWindowPos(StartedApp.MainWindowHandle, 0, int.Parse(args[1]), int.Parse(args[2]), 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(String.Format("Yikes - {0}", ex.Message));
            }


        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    }
}
