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
    public class EyecolorsController : Controller
    {
        //private CatsInTheBoxContext db = new CatsInTheBoxContext();

        public CatsInTheBoxContext db { get; set; }
        public EyecolorsController()
        {
            this.db = new CatsInTheBoxContext();
        }
        public EyecolorsController(CatsInTheBoxContext db)
        {
            this.db = db;
        }

        // GET: Eyecolors
        public ActionResult Index()
        {
            return View(db.Eyecolor.ToList());
        }

        // GET: Eyecolors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eyecolor eyecolor = db.Eyecolor.Find(id);
            if (eyecolor == null)
            {
                return HttpNotFound();
            }
            return View(eyecolor);
        }

        // GET: Eyecolors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eyecolors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Eyecolor eyecolor)
        {
            if (ModelState.IsValid)
            {
                db.Eyecolor.Add(eyecolor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eyecolor);
        }

        // GET: Eyecolors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eyecolor eyecolor = db.Eyecolor.Find(id);
            if (eyecolor == null)
            {
                return HttpNotFound();
            }
            return View(eyecolor);
        }

        // POST: Eyecolors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Eyecolor eyecolor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eyecolor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eyecolor);
        }

        // GET: Eyecolors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eyecolor eyecolor = db.Eyecolor.Find(id);
            if (eyecolor == null)
            {
                return HttpNotFound();
            }
            return View(eyecolor);
        }

        // POST: Eyecolors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eyecolor eyecolor = db.Eyecolor.Find(id);
            db.Eyecolor.Remove(eyecolor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
