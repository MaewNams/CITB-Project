using System;
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
    public class ArticlesController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();
        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Aricle.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userid,name,detail,pic,timestamp")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.userid = Int32.Parse(Session["accountid"].ToString());
                article.timestamp = DateTime.Now;
                db.Aricle.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }


        // GET: Aritcles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Aricle.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
    }
}