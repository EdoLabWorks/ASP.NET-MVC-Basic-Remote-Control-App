using SimpleWebControlApp.Model;
using System.Web.Mvc;

//namespace WebApplication1.Controllers
namespace SimpleWebControlApp.Controllers
{
    public class LedAPIController : Controller
    {
        Led myLed = new Led { ControlAPI = "LedAPI" };
        int n = 0;

        public ActionResult Index()
        {
            //create Devices instance (Device1 to Device6)
            if (Devices.Device[1] == null) //check one device first and then create instances for all
            {
                Devices.createDevice();
            }
            myLed.comboLedControl(0);
            return View(myLed);
        }

        /********************
        -O-     LED 1     -0-
        ********************/
        public ActionResult LedON()//led1 ON
        {
            n = 1;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult LedOFF()//led1 OFF
        {
            n = 2;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        /********************
        -O-      LED 2    -0-
        ********************/
        public ActionResult Led2ON()//led2 ON
        {
            n = 3;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult Led2OFF()//led2 OFF
        {
            n = 4;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        /********************
        -O-      LED 3    -0-
        ********************/
        public ActionResult Led3ON()//led3 ON
        {
            n = 5;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult Led3OFF()//led3 OFF
        {
            n = 6;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        /********************
        -O-      LED 4    -0-
        ********************/
        public ActionResult Led4ON()//led4 ON
        {
            n = 7;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult Led4OFF()//led4 OFF
        {
            n = 8;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        /********************
        -O-      LED 5    -0-
        ********************/
        public ActionResult Led5ON()//led5 ON
        {
            n = 9;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult Led5OFF()//led5 OFF
        {
            n = 10;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        /********************
        -O-      LED 6    -0-
        ********************/
        public ActionResult Led6ON()//led6 ON
        {
            n = 11;
            myLed.comboLedControl(n);
            return View(myLed);
        }

        public ActionResult Led6OFF()//led6 OFF
        {
            n = 12;
            myLed.comboLedControl(n);
            return View(myLed);
        }
    }
}