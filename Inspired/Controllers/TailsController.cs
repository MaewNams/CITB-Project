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
    public class TailsController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();

        // GET: Tails
        public ActionResult Index()
        {
            return View(db.Tail.ToList());
        }

        // GET: Tails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tail tail = db.Tail.Find(id);
            if (tail == null)
            {
                return HttpNotFound();
            }
            return View(tail);
        }

        // GET: Tails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Tail tail)
        {
            if (ModelState.IsValid)
            {
                db.Tail.Add(tail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tail);
        }

        // GET: Tails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tail tail = db.Tail.Find(id);
            if (tail == null)
            {
                return HttpNotFound();
            }
            return View(tail);
        }

        // POST: Tails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Tail tail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tail);
        }

        // GET: Tails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tail tail = db.Tail.Find(id);
            if (tail == null)
            {
                return HttpNotFound();
            }
            return View(tail);
        }

        // POST: Tails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tail tail = db.Tail.Find(id);
            db.Tail.Remove(tail);
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
