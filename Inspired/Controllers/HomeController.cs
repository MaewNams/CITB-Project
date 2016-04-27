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
        //private CatsInTheBoxContext db = new CatsInTheBoxContext();

        public CatsInTheBoxContext db { get; set; }
        public HomeController()
        {
            this.db = new CatsInTheBoxContext();
        }
        public HomeController(CatsInTheBoxContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            ViewData["RecentDiary"] = db.Diary.OrderByDescending(c => c.timestamp).Take(5).ToList<Diary>();
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
            ViewData["FollowDiary"] = db.Followdiary.Where(f => f.userid == userid).OrderBy(f => f.Diary.name).ToList<Followdiary>();
            return View();
        }

        [Route("Home/AllDiary/Recent")]
        public ActionResult AllDiary()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            ViewData["RecentDiary"] = db.Diary.OrderByDescending(d => d.timestamp).ToList<Diary>();
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

        [Route("Home/MyForum/{type}")]
        public ActionResult MyForum(string type)
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }

            int userid = Int32.Parse(Session["accountid"].ToString());
            Account user = db.Account.Find(userid);
            ViewData["Type"] = type;
            ViewData["TopicType"] = db.Topictype.Where(c => c.usertypeid == user.usertypeid).OrderBy(c => c.name).ToList<Topictype>();
            if (type == "All")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid).ToList<Topic>();
            }
            if (type == "Article")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Article").ToList<Topic>();
            }
            if (type == "News")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "News").ToList<Topic>();
            }
            if (type == "Adoption")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Adoption").ToList<Topic>();
            }
            if (type == "Lostcat")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Lostcat").ToList<Topic>();
            }
            if (type == "Findowner")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Findowner").ToList<Topic>();
            }
            if (type == "Discussion")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Discussion").ToList<Topic>();
            }
            if (type == "Tip")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "Tip").ToList<Topic>();
            }
            if (type == "SOS")
            {
                ViewData["Topic"] = db.Topic.Where(at => at.userid == userid && at.Topictype.name == "SOS").ToList<Topic>();
            }

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