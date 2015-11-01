using System;
using System.Diagnostics;

namespace SimpleWebControlApp.Model
{
    class SimpleProcessControl
    {
        public static void StartProcess()
        {
            try
            {
                Process.Start(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe");
            }
            catch (InvalidOperationException ex)
            {
                SimpleWebControlApp.Model.WebClientState.Error = "Error : " + ex.Message + " Check Process Status!";
            }
        }

        public static void KillProcess()
        {
            Process[] currentProcesses = Process.GetProcessesByName("iexplore");
            try
            {
                foreach (Process proc in currentProcesses)
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
            }
            catch (InvalidOperationException ex)
            {
                SimpleWebControlApp.Model.WebClientState.Error = "Error : " + ex.Message + " Check Process Status!";
            }
        }
    }
}
