using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspired.Controllers
{
    public class DiariesController : Controller
    {
        // GET: Diaries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SettingDiary()
        {
            return View();
        }


        public ActionResult StatisticDiary()
        {
            return View();
        }
        public ActionResult ChapterDiary()
        {
            return View();
        }

    }
}