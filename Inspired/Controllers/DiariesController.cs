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

        [Route("{username}/Diary/{id}")]
        public ActionResult DiaryIndex(int? id, string username)
        {
            Session["diaryid"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diary.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            ViewData["Chapter"] = db.Chapter.Where(c => c.diaryid == id).OrderByDescending(c => c.timestamp).ToList<Chapter>();
            ViewData["RecentChapter"] = db.Chapter.Where(c => c.diaryid == id).OrderByDescending(c => c.timestamp).Take(5).ToList<Chapter>();
            return View(diary);

        }

        [Route("{username}/Diary/{id}/{chaptername}")]
        public ActionResult ChapterDetail(string username, int? id, string chaptername, int chapterid)
        {

            Session["diaryid"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diary.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            ViewData["RecentChapter"] = db.Chapter.Where(c => c.diaryid == id).OrderByDescending(c => c.timestamp).Take(5).ToList<Chapter>();
            ViewData["Chapter"] = db.Chapter.Find(chapterid);

            Chapter chapterview = db.Chapter.Find(chapterid);
            chapterview.views += 1;
            db.SaveChanges();
            return View(diary);

        }


        [Route("ManageDiary/Index/{id}")]
        public ActionResult Index(int? id)
        {
            Session["diaryid"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diary.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);

        }


        [Route("ManageDiary/CreateDiary")]
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
            if (ViewData["Cat"] == null)

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
            return RedirectToAction("Index", new { id = diary.id });

        }

        [Route("ManageDiary/SettingDiary/{id}")]
        public ActionResult SettingDiary(int? id)
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }

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
            int diaryid = Int32.Parse(Session["diaryid"].ToString());
            Catdiary catdiary = db.Catdiary.Where(c => c.catid == catid && c.diaryid == diaryid).FirstOrDefault();
            db.Catdiary.Remove(catdiary);
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }

        [HttpPost]
        public ActionResult EditDiary(int diaryid, string newName, string newDescription)
        {
            Diary diary = db.Diary.Find(diaryid);
            diary.name = newName;
            diary.description = newDescription;
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }

        [HttpPost]
        public ActionResult DeleteDiary(int? diaryid)
        {
            Diary diary = db.Diary.Find(diaryid);
            ViewData["DeleteChapter"] = db.Chapter.Where(c => c.diaryid == diaryid).ToList<Chapter>();
            List<Chapter> deletechapter = (List<Chapter>)ViewData["DeleteChapter"];
            foreach (Chapter chapter in deletechapter)
            {
                db.Chapter.Remove(chapter);
                db.SaveChanges();
            }

            ViewData["DeleteCatDiary"] = db.Catdiary.Where(cd => cd.diaryid == diaryid).ToList<Catdiary>();
            List<Catdiary> deletecatdiary = (List<Catdiary>)ViewData["DeleteCatDiary"];
            foreach (Catdiary catdiary in deletecatdiary)
            {
                db.Catdiary.Remove(catdiary);
                db.SaveChanges();
            }
            db.Diary.Remove(diary);
            db.SaveChanges();
            return Json(new { Result = "Success" });
        }

        [Route("ManageDiary/Statistic/{id}")]
        public ActionResult StatisticDiary(int? id)
        {
            Session["diaryid"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diary.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);

        }

        [Route("ManageDiary/Chapter/{id}")]
        public ActionResult ChapterDiary(int? id)
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }

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

            ViewData["Chapter"] = db.Chapter.Where(c => c.diaryid == id).OrderBy(c => c.timestamp).ToList<Chapter>(); ;

            return View(diary);
        }



    }

}
