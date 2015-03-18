using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Movie.Controllers
{
    public class HelloWorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int ID = 1)
        {
            ViewBag.Message = string.Format("Hello {0}.", name);
            ViewBag.NumTimes = ID;

            return View();
        }
    }
}