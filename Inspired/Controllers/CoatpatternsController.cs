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
    public class CoatpatternsController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();

        // GET: Coatpatterns
        public ActionResult Index()
        {
            return View(db.Coatpattern.ToList());
        }

        // GET: Coatpatterns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coatpattern coatpattern = db.Coatpattern.Find(id);
            if (coatpattern == null)
            {
                return HttpNotFound();
            }
            return View(coatpattern);
        }

        // GET: Coatpatterns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coatpatterns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,detail")] Coatpattern coatpattern)
        {
            if (ModelState.IsValid)
            {
                db.Coatpattern.Add(coatpattern);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coatpattern);
        }

        // GET: Coatpatterns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coatpattern coatpattern = db.Coatpattern.Find(id);
            if (coatpattern == null)
            {
                return HttpNotFound();
            }
            return View(coatpattern);
        }

        // POST: Coatpatterns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,detail")] Coatpattern coatpattern)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coatpattern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coatpattern);
        }

        // GET: Coatpatterns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coatpattern coatpattern = db.Coatpattern.Find(id);
            if (coatpattern == null)
            {
                return HttpNotFound();
            }
            return View(coatpattern);
        }

        // POST: Coatpatterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coatpattern coatpattern = db.Coatpattern.Find(id);
            db.Coatpattern.Remove(coatpattern);
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
