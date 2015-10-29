using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebControlApp.Model
{
    //control methods available to the device module
    public class Module : ISwitch
    {
        public string Name { get; set; }

        public bool State { get; set; }

        public Module(string Name)
        {
            this.Name = Name;
        }

        public int Condition()
        {
            int n = 0;
            if (State == true)
            {
                n = 1;
            }
            else
            {
                n = 0;
            }
            return n;
        }

        public int Control(int x)
        {
            if (x == 1)
            {
                State = true;
            }
            else
            {
                State = false;
            }
            return x;
        }

        public void ON()
        {
            State = true;
        }

        public void OFF()
        {
            State = false;
        }
    }
}