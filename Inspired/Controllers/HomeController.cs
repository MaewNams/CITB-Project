using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatsInTheBox.DAL;
using Inspired.Models;
using System;

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
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }

            return View();
        }

        public ActionResult MyDiary()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            ViewData["Diary"] = db.Diary.Where(d => d.userid == userid).OrderByDescending(d => d.timestamp).ToList<Diary>();
            return View();
        }



        public ActionResult CatCensus()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }

            int userid = Int32.Parse(Session["accountid"].ToString());

            ViewData["Breeds"] = db.Breed.OrderBy(b => b.name).ToList<Breed>();
            ViewData["Cats"] = db.Cat.Where(c => c.userid == userid && c.status == 1).OrderBy(c => c.name).ToList<Cat>();
            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CatCensus([Bind(Include = "id,name,userid,status,birthdate,adoptdate,deathdate")] Cat cat)
        {
            cat.userid = Int32.Parse(Session["accountid"].ToString());
            cat.status = 1;

            cat.birthdate = DateTime.Now;
            cat.adoptdate = DateTime.Now;
            cat.deathdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Cat.Add(cat);
                db.SaveChanges();
                return RedirectToAction("CatCensus");
            }

            return View(cat);
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