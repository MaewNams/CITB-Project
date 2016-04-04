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
    public class CatsController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();

        // GET: Cats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userid,name,gender,age,lifestage,pic,eyecolorid,coatpatternid,tailid,birthdate,deathdate,habit,liked,disliked,description,note,marked,status")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Cat.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Home/CatCensus");
            }

            return View(cat);
        }
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}