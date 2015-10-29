using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWebControlApp.Model
{
    //switch feature added to the device module
    public interface ISwitch
    {
        string Name { get; set; }
        bool State { get; set; }
        int Condition();
        int Control(int x);
        void ON();
        void OFF();
    }
}
