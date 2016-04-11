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
    public class DiariesController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();
        // GET: Diaries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            ViewData["Cat"] = db.Cat.Where(c => c.userid == userid).OrderBy(c => c.name).ToList<Cat>();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,userid,timestamp")] Diary diary)
        {
            int userid = Int32.Parse(Session["accountid"].ToString());
            ViewData["Cat"] = db.Cat.Where(c => c.userid == userid).OrderBy(c => c.name).ToList<Cat>();
            Catdiary catdiary = new Catdiary();
            diary.userid = Int32.Parse(Session["accountid"].ToString());
            diary.timestamp = DateTime.Now;
            string[] catowners = Request.Form.GetValues("catsdiary");
            if (ModelState.IsValid)
            {
                if (diary.name == null && catowners == null)
                {
                    ViewBag.DiaryNameError = "Diary have to has a name.";
                    ViewBag.DiaryOwnerError = "Diary have to has atleast 1 cat owner.";
                    return View();
                }

                if (diary.name == null)
                {
                    ViewBag.DiaryNameError = "Diary have to has a name.";
                    return View();
                }

                if (catowners == null)
                {
                    ViewBag.DiaryOwnerError = "Diary have to has atleast 1 cat owner.";
                    return View();
                }

                db.Diary.Add(diary);
                db.SaveChanges();
                foreach (string key in catowners)
                {
                    int catid = Int32.Parse(key.ToString());
                    catdiary.catid = catid;
                    catdiary.diaryid = diary.id;
                    db.Catdiary.Add(catdiary);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Setting");

        }
        public ActionResult SettingDiary()
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

    }
}