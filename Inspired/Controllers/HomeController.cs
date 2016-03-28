using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspired.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdoptonDetail()
        {
            return View();
        }
        public ActionResult Adopton()
        {
            return View();
        }

        public ActionResult MyDiary()
        {
            return View();
        }

        public ActionResult CatCensus()
        {
            return View();
        }
        public ActionResult CatTimeline()
        {
            return View();
        }
        public ActionResult MyBoard()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult StatisticDiary()
        {
            return View();
        }
        public ActionResult ChapterDiary()
        {
            return View();
        }


        public ActionResult SettingDiary()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}