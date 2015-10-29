using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebControlApp.Model
{
  /* Using a simple integer pattern
    Device1   ON = 1,  OFF = 2
    Device2   ON = 3,  OFF = 4
    Device3   ON = 5,  OFF = 6
    Device4   ON = 7,  OFF = 8
    Device5   ON = 9,  OFF = 10 
    Device6   ON = 11, OFF = 12 */

    /*************************************************************************************
    -o-  Add process, DLL driver, Class method you want to control as shown below  -o-
    **************************************************************************************/

    class ControlProcess
    {
        static  ISwitch[] Device = Devices.Device;

        public static int DeviceControl(int n)
        {
            int x = 0;
            switch (n)
            {
                case 0:
                    x = 0;

                    Device[0].OFF();
                    break;
                case 1:
                    x = 1;

                    //There are many ways you to start, control and stop a process/dll driver methods, this is just a simple example 
                    //Ideally it's better to use a class container to control any processes

                    /*** process to start, uncomment to enable ***/
                    //SimpleProcessControl.StartProcess(); //start a process

                    Device[x].ON();
                    break;
                case 2:
                    x = 1;
                    Device[x].OFF();

                    //Follow similar pattern to other devices

                    /*** process to stop, uncomment to enable ***/
                    //SimpleProcessControl.KillProcess(); //stop a process
                   
                    break;
                case 3:
                    x = 2;
                    Device[x].ON();
                    break;
                case 4:
                    x = 2;
                    Device[x].OFF();
                    break;
                case 5:
                    x = 3;
                    Device[x].ON();
                    break;
                case 6:
                    x = 3;
                    Device[x].OFF();
                    break;
                case 7:
                    x = 4;
                    Device[x].ON();
                    break;
                case 8:
                    x = 4;
                    Device[x].OFF();
                    break;
                case 9:
                    x = 5;
                    Device[x].ON();
                    break;
                case 10:
                    x = 5;
                    Device[x].OFF();
                    break;
                case 11:
                    x = 6;
                    Device[x].ON();
                    break;
                case 12:
                    x = 6;
                    Device[x].OFF();
                    break;
                case 13:
                    x = 7;
                    Device[x].ON();
                    break;
                case 14:
                    x = 7;
                    Device[x].OFF();
                    break;
                default:
                    throw new ArgumentException("unexpected control code type");
            }
            Console.WriteLine(Device[x].Name + " : " + Device[x].State);
            return n;
        }

        //check all Led's state in a single pass
        public static int CheckSwitchState(int n)
        {
            int[] State = new int[10];
            string BinaryState = "";

            //array range, LedState[1] to LedState[6] 
            for (int i = 1; i < 7; i++)
            {
                try
                {
                    State[i] = Device[i].Condition();
                    BinaryState += State[i].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }
            }
            int binaryData = 1000000 + int.Parse(BinaryState);
            return binaryData;
        }
    }
}