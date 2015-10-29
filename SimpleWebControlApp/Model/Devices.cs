using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebControlApp.Model
{
    class Devices
    {
        public static Module[] Device = new Module[25];

        //create an array of device module objects  
        public static void createDevice()
        {
            Device[0] = new Module("Device 0"); //unused
            Device[1] = new Module("Device 1");
            Device[2] = new Module("Device 2");
            Device[3] = new Module("Device 3");
            Device[4] = new Module("Device 4");
            Device[5] = new Module("Device 5");
            Device[6] = new Module("Device 6");
            Device[7] = new Module("Device 7"); //unused
        }
    }
}