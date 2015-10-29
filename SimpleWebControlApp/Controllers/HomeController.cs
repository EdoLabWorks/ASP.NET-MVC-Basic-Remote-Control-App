using System.Web.Mvc;

namespace SimpleWebControlApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A Simple Web Framework for Remote Control application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ed Alegrid";

            return View();
        }
    }
}