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
        public ActionResult Create([Bind(Include = "id,name,userid,timestamp,description")] Diary diary)
        {
            int userid = Int32.Parse(Session["accountid"].ToString());
            ViewData["Cat"] = db.Cat.Where(c => c.userid == userid).OrderBy(c => c.name).ToList<Cat>();
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
                Catdiary catdiary = new Catdiary();
                foreach (string key in catowners)
                {
                    int catid = Int32.Parse(key.ToString());
                    catdiary.catid = catid;
                    catdiary.diaryid = diary.id;
                    db.Catdiary.Add(catdiary);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("SettingDiary", new { id = diary.id });

        }
        public ActionResult SettingDiary(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["diaryid"] = id;
            Diary diary = db.Diary.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            int userid = Int32.Parse(Session["accountid"].ToString());

            ViewData["CatsOwnDiary"] = db.Catdiary
                .Where(cd => cd.diaryid == id)
                .Select(cd => cd.Cat).ToList<Cat>();

            ViewData["AllMyCats"] = db.Cat.Where(c => c.userid == userid).OrderBy(c => c.name).ToList<Cat>();
            List<Cat> allmycats = (List<Cat>)ViewData["AllMyCats"];
            List<Cat> catowndiary = (List<Cat>)ViewData["CatsOwnDiary"];

            ViewData["SelectableCat"] = allmycats.Where(c => !catowndiary.Any(c2 => c2.id == c.id)).OrderBy(c => c.name).ToList<Cat>();
            return View(diary);
        }

        [HttpPost]
        public ActionResult AddOwner(int catid)
        {
            int diaryid = Int32.Parse(Session["diaryid"].ToString());
            Catdiary catdiary = new Catdiary();
            catdiary.catid = catid;
            catdiary.diaryid = diaryid;
            db.Catdiary.Add(catdiary);
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }

        [HttpPost]
        public ActionResult DeleteOwner(int? catid)
        {
            int diaryid = Int32.Parse(Session["diaryid"].ToString()) ;
            Catdiary catdiary = db.Catdiary.Where(c => c.catid == catid && c.diaryid == diaryid).FirstOrDefault();
            db.Catdiary.Remove(catdiary);
            db.SaveChanges();
            return Json(new { Result = "Success" });
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