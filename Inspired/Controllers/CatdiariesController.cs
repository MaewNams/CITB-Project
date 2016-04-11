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
    public class CatdiariesController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();

        // GET: Catdiaries
        public ActionResult Index()
        {
            var catdiary = db.Catdiary.Include(c => c.Cat).Include(c => c.Diary);
            return View(catdiary.ToList());
        }

        // GET: Catdiaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catdiary catdiary = db.Catdiary.Find(id);
            if (catdiary == null)
            {
                return HttpNotFound();
            }
            return View(catdiary);
        }

        // GET: Catdiaries/Create
        public ActionResult Create()
        {
            ViewBag.catid = new SelectList(db.Cat, "id", "name");
            ViewBag.diaryid = new SelectList(db.Diary, "id", "name");
            return View();
        }

        // POST: Catdiaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,catid,diaryid")] Catdiary catdiary)
        {
            if (ModelState.IsValid)
            {
                db.Catdiary.Add(catdiary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catid = new SelectList(db.Cat, "id", "name", catdiary.catid);
            ViewBag.diaryid = new SelectList(db.Diary, "id", "name", catdiary.diaryid);
            return View(catdiary);
        }

        // GET: Catdiaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catdiary catdiary = db.Catdiary.Find(id);
            if (catdiary == null)
            {
                return HttpNotFound();
            }
            ViewBag.catid = new SelectList(db.Cat, "id", "name", catdiary.catid);
            ViewBag.diaryid = new SelectList(db.Diary, "id", "name", catdiary.diaryid);
            return View(catdiary);
        }

        // POST: Catdiaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,catid,diaryid")] Catdiary catdiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catdiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catid = new SelectList(db.Cat, "id", "name", catdiary.catid);
            ViewBag.diaryid = new SelectList(db.Diary, "id", "name", catdiary.diaryid);
            return View(catdiary);
        }

        // GET: Catdiaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catdiary catdiary = db.Catdiary.Find(id);
            if (catdiary == null)
            {
                return HttpNotFound();
            }
            return View(catdiary);
        }

        // POST: Catdiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catdiary catdiary = db.Catdiary.Find(id);
            db.Catdiary.Remove(catdiary);
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
