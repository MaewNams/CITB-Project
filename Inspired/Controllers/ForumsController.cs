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
    public class ForumsController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();
        // GET: Forums
        public ActionResult Index()
        {
            return View();
        }
        [Route("Forums/Create")]
        [Route("Forums/Create/{type}")]
        public ActionResult Create(int? type)
        {
            if(type != null)
            {
                ViewData["Type"] = Int32.Parse(type.ToString());
            }
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            Account user = db.Account.Find(userid);
            ViewData["TopicType"] = db.Topictype.Where(c => c.usertypeid == user.usertypeid).OrderBy(c => c.name).ToList<Topictype>();
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
            {

            }
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
                diary.userid = userid;
                diary.timestamp = DateTime.Now;
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


        public ActionResult TopicForm()
        {
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            Account user = db.Account.Find(userid);
            ViewData["TopicType"] = db.Topictype.Where(c => c.usertypeid == user.usertypeid).OrderBy(c => c.name).ToList<Topictype>();
            return View();
        }



    }


}