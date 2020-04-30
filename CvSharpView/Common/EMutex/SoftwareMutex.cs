using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CvSharpView.Common.Helpers;

namespace CvSharpView.Common.EMutex
{
    public class SoftwareMutex
    {
        private static Mutex AppMutex { get; set; }

        public static void RunMutext()
        {
            if (AppMutex != null) return;
            AppMutex = new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out var createdNew);
            if (createdNew) return;
            var current = Process.GetCurrentProcess();

            foreach (var process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id == current.Id) continue;
                Win32Helper.SetForegroundWindow(process.MainWindowHandle);
                break;
            }
            System.Windows.Application.Current.Shutdown();
        }
    }
}
