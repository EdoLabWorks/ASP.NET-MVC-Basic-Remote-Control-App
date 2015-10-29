using SimpleWebControlApp.Model;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace SimpleWebControlApp.Model
{
    public class WebClientState
    {
        public static string Error { get; set; }
        public static int RxData { get; set; }
        public static int TxData { get; set; }

        public static int Client(int TxCode)
        {
            Error = null;
            RxData = 0;
            TxData = TxCode;
            try
            {
                RxData = ClientProcess(TxCode);
            }
            catch (Exception ex)
            {
                Error = "Error : " + ex.Message + " Check I/O module!";
            }
            return RxData;
        }

        private static int ClientProcess(int TxData)
        {
            int outputdata = 0;

            //code below 20 is used to control the Device LED state
            if (TxData < 20)
            {
                outputdata = ControlProcess.DeviceControl(TxData);
            }
            //code 55 is used to get the status of the Device LED's all at the same time
            else if (TxData == 55)
            {
                outputdata = ControlProcess.CheckSwitchState(TxData);
            }
            return outputdata;
        }
    }
}
