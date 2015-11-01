using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleWebControlApp.Model
{
    //used for a separate I/O control module but for now we are re-using it for local use
    public class Led
    {
        public string OutputModuleStatus { get; set; }
        public bool led1state { get; set; }
        public bool led2state { get; set; }
        public bool led3state { get; set; }
        public bool led4state { get; set; }
        public bool led5state { get; set; }
        public bool led6state { get; set; }
        public int rxData { get; set; }
        public int txData { get; set; }

        public string ControlAPI { get; set; }
    
        public void moduleStatus()
        {
            OutputModuleStatus = WebClientState.Error;
            if (WebClientState.Error == null)
            {
                OutputModuleStatus = "OK";
            }
            else
            {
                OutputModuleStatus = WebClientState.Error;
            }
        }
        //check state of all Led's in single pass
        public void checkLedStateSinglePass(int txdata)
        {
            //trivial check to ensure data integrity, TxData must be equal to RxData
            if (WebClientState.RxData != txdata)
            {
                WebClientState.Error = "Can't confirm led state? " + " RxData = " + WebClientState.RxData.ToString() + " TxData = " + txdata;
            }

            //if data is intact and no connection error, check all Led states, algorithm work starts 
            if (WebClientState.Error == null && WebClientState.RxData == txdata)
            {
                //simple algorithm to decode our received digital code (1000000 to 1111111)
                // ex.  leftmost 1 is dummy -->1000001<-- rightmost 1 indicates Led6 is ON
                // ex.  leftmost 1 is dummy -->1000010<-- 1 on second position indicates Led5 is ON
                // ex.  leftmost 1 is dummy -->1100000<-- 1 on sixth position indicates Led1 is ON
                string data = txdata.ToString();
                int[] LedState = new int[8];
                try
                {
                    //parsed value should be 1 or 0 only
                    LedState[6] = int.Parse(data.Remove(0, 6));
                    LedState[5] = int.Parse(data.Remove(0, 5).Remove(1, 1));
                    LedState[4] = int.Parse(data.Remove(0, 4).Remove(1, 2));
                    LedState[3] = int.Parse(data.Remove(0, 3).Remove(1, 3));
                    LedState[2] = int.Parse(data.Remove(0, 2).Remove(1, 4));
                    LedState[1] = int.Parse(data.Remove(0, 1).Remove(1, 5));
                }
                catch (Exception ex)
                {
                    WebClientState.Error = "Error : " + ex;
                }

                //*********** for test only **************
                //LedState[1] = 5; LedState[2] = 4; LedState[3] = 5; LedState[4] = 6; LedState[5] = 3; LedState[6] = 2;
                //any parsed value other than 0 or 1 should throw an error message 
                //****************************************

                if (LedState[1] > 1 || LedState[2] > 1 || LedState[3] > 1 || LedState[4] > 1 || LedState[5] > 1 || LedState[6] > 1)
                {
                    WebClientState.Error = "Can't confirm led state? " + " RxData = " + WebClientState.RxData + " TxData = " + txdata +
                   " LedState[1] = " + LedState[1] + " LedState[2] = " + LedState[2] + " LedState[3] = " + LedState[3] +
                   " LedState[4] = " + LedState[4] + " LedState[5] = " + LedState[5] + " LedState[6] = " + LedState[6];
                    return;
                }
                //need to improve this next time
                if (LedState[1] == 1)
                    led1state = true;
                if (LedState[2] == 1)
                    led2state = true;
                if (LedState[3] == 1)
                    led3state = true;
                if (LedState[4] == 1)
                    led4state = true;
                if (LedState[5] == 1)
                    led5state = true;
                if (LedState[6] == 1)
                    led6state = true;
                if (LedState[1] == 0)
                    led1state = false;
                if (LedState[2] == 0)
                    led2state = false;
                if (LedState[3] == 0)
                    led3state = false;
                if (LedState[4] == 0)
                    led4state = false;
                if (LedState[5] == 0)
                    led5state = false;
                if (LedState[6] == 0)
                    led6state = false;
            }
        }

        //combo method to control each Led, check connection status
        public void LedControl(int n)
        {
            //send ON/OFF control code to server 
            WebClientState.Client(n);
            //updates client view TxCode   
            txData = WebClientState.TxData;
            //updates client view RxData
            rxData = WebClientState.RxData;
            //check connection status everytime we connect to a remote server 
            moduleStatus();
        }

        //combo method to control each Led, check all Led status, check connection status, Led API for View
        public void comboLedControl(int n)
        {
           //send ON/OFF control code to server 
           WebClientState.Client(n);
           //updates client view TxCode   
           txData = WebClientState.TxData;
           //send request (code 55) to I/O module for Led status update
           checkLedStateSinglePass(WebClientState.Client(55));
           //used to maintain the LedAPI in View
           ControlAPI = ControlAPI;
           //updates client RxData in view
           rxData = WebClientState.RxData;
           //check connection status everytime we connect to a remote server 
           moduleStatus();
        }

        //combo method to control each Led, check all Led status, check connection status, Led API for View
        public void comboLedControlToggle()
        {
            //updates client view TxCode   
            txData = WebClientState.TxData;
            //send request (code 55) to I/O module for Led status update
            checkLedStateSinglePass(WebClientState.Client(55));
            //updates client RxData in view
            rxData = WebClientState.RxData;
            //check connection status everytime we connect to a remote server 
            moduleStatus();
        }
        
        //reset all Led's to OFF
        public void resetLedControl()
        {
           WebClientState.Client(2);
           WebClientState.Client(4);
           WebClientState.Client(6);
           WebClientState.Client(8);
           WebClientState.Client(10);
           WebClientState.Client(12);
        }
        //reset all Led's to ON
        internal void OnAllLedControl()
        {
            WebClientState.Client(1);
            WebClientState.Client(3);
            WebClientState.Client(5);
            WebClientState.Client(7);
            WebClientState.Client(9);
            WebClientState.Client(11);
        }
    }
}