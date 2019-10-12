using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeckoTracker.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gecko()
        {
            return View();
        }

        public ActionResult Pairing()
        {
            return View();
        }

        public ActionResult Loan()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = ""; //took out messages in home/about & contact

            return View();
        }
    }
}