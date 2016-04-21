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
    public class ChaptersController : Controller
    {
        //private CatsInTheBoxContext db = new CatsInTheBoxContext();

        public CatsInTheBoxContext db { get; set; }
        public ChaptersController()
        {
            this.db = new CatsInTheBoxContext();
        }
        public ChaptersController(CatsInTheBoxContext db)
        {
            this.db = db;
        }

        // GET: Chapters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateChapter()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int diaryid = Int32.Parse(Session["diaryid"].ToString());
            Diary diary = db.Diary.Find(diaryid);
            if (diary == null)
            {
                return HttpNotFound();
            }

            return View(diary);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateChapter(string name, string detail)
        {
            int diaryid = Int32.Parse(Session["diaryid"].ToString());
            Chapter chapter = new Chapter();
            chapter.diaryid = diaryid;
            chapter.name = name;
            chapter.timestamp = DateTime.Now;
            chapter.detail = detail;
            chapter.views = 0;
            db.Chapter.Add(chapter);
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }


        [HttpPost]
        public ActionResult DeleteChapter(int? id)
        {
            Chapter chapter = db.Chapter.Where(c => c.id == id).FirstOrDefault();
            db.Chapter.Remove(chapter);
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }



        public ActionResult EditChapter(int? id)
        {

            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int diaryid = Int32.Parse(Session["diaryid"].ToString());
            Diary diary = db.Diary.Find(diaryid);

            ViewData["EditChapter"] = db.Chapter.Find(id);

            return View(diary);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditChapter(int chapterid, string newName, string newDetail)
        {
            Chapter chapter = db.Chapter.Find(chapterid);
            chapter.name = newName;
            chapter.detail = newDetail;
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }
    }
}