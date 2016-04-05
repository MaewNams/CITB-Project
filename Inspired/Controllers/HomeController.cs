using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatsInTheBox.DAL;
using Inspired.Models;


namespace Inspired.Controllers
{
    public class HomeController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AdoptionDetail()
        {
            return View();
        }
        public ActionResult Adoption()
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