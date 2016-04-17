using CatsInTheBox.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspired.Controllers
{
    public class ForumsController : Controller
    {
        public CatsInTheBoxContext db { get; set; }
        public ForumsController()
        {
            this.db = new CatsInTheBoxContext();
        }
        public ForumsController(CatsInTheBoxContext db)
        {
            this.db = db;
        }
        // GET: Forums
        public ActionResult Index()
        {
            return View();
        }
    }
}