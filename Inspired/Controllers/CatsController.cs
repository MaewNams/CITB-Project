using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspired.Controllers
{
    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
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