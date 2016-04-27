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
using System.Data.Entity.Validation;

namespace Inspired.Controllers
{
    public class ForumsController : Controller
    {

        //    private CatsInTheBoxContext db = new CatsInTheBoxContext();

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
            ViewData["Alltopic"] = db.Topic.OrderBy(b => b.name).ToList<Topic>();
            return View();
        }

        public ActionResult FindOwner()
        {
            return View();
        }

        [Route("Forums/Create")]
        [Route("Forums/Create/{type}")]
        public ActionResult Create(int? type)
        {
            if (type != null)
            {
                ViewData["Type"] = Int32.Parse(type.ToString());
            }
            if (Session["Authen"] == null)
            { return RedirectToAction("Login", "Accounts"); }
            int userid = Int32.Parse(Session["accountid"].ToString());
            Account user = db.Account.Find(userid);
            ViewData["Tails"] = db.Tail.OrderBy(b => b.name).ToList<Tail>();
            ViewData["Coatcolors"] = db.Coatcolor.OrderBy(b => b.name).ToList<Coatcolor>();
            ViewData["Coatpatterns"] = db.Coatpattern.OrderBy(b => b.name).ToList<Coatpattern>();
            ViewData["Eyecolors"] = db.Eyecolor.OrderBy(b => b.name).ToList<Eyecolor>();
            ViewData["Breeds"] = db.Breed.OrderBy(b => b.name).ToList<Breed>();
            ViewData["Province"] = db.Province.OrderBy(p => p.name).ToList<Province>();
            ViewData["TopicType"] = db.Topictype.Where(c => c.usertypeid == user.usertypeid).OrderBy(c => c.name).ToList<Topictype>();
            return View();
        }

        [Route("Forums/Create")]
        [Route("Forums/Create/{typename}")]
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            int userid = Int32.Parse(Session["accountid"].ToString());
            int typeid = Int32.Parse(Request.Form["topic"].ToString());

            var newTopic = new Topic();
            newTopic.name = Request.Form["name"].ToString();
            newTopic.userid = userid;
            newTopic.topictypeid = typeid;
            newTopic.timestamp = DateTime.Now;
            newTopic.views = 0;
            newTopic.detail = Request.Unvalidated["detail"].ToString();
            db.Topic.Add(newTopic);
            db.SaveChanges();

            if (newTopic.topictypeid == 3)
            {
                /*Want owner cat*/
                int coatpatternid = Int32.Parse(Request.Form["coatpattern"].ToString());
                int eyecolorid = Int32.Parse(Request.Form["eyecolor"].ToString());
                int tailid = Int32.Parse(Request.Form["tail"].ToString());
                Cat wantownercat = new Cat();
                wantownercat.userid = userid;
                wantownercat.name = Request.Form["catname"];
                wantownercat.gender = Request.Form["gender"];
                wantownercat.lifestage = Request.Form["lifestage"];
                wantownercat.coatpatternid = coatpatternid;
                wantownercat.eyecolorid = eyecolorid;
                wantownercat.tailid = tailid;
                wantownercat.status = 2;
                wantownercat.birthdate = DateTime.Now;
                wantownercat.deathdate = DateTime.Now;
                wantownercat.adoptdate = DateTime.Now;
                db.Cat.Add(wantownercat);
                db.SaveChanges();

                /*Want owner cat breed*/
                string[] catbreeds = Request.Form.GetValues("breed");
                Catbreed wantownercatbreed = new Catbreed();
                foreach (string key in catbreeds)
                {
                    int breedid = Int32.Parse(key.ToString());
                    wantownercatbreed.catid = wantownercat.id;
                    wantownercatbreed.breedid = breedid;
                    db.Catbreed.Add(wantownercatbreed);
                    db.SaveChanges();
                }


                /* Want owner cat coat color*/
                string[] coatcolors = Request.Form.GetValues("coatcolor");
                Catcoatcolor wantownercatcoatcolors = new Catcoatcolor();
                foreach (string key in coatcolors)
                {
                    int colorid = Int32.Parse(key.ToString());
                    wantownercatcoatcolors.catid = wantownercat.id;
                    wantownercatcoatcolors.coatcolorid = colorid;
                    db.Catcoatcolor.Add(wantownercatcoatcolors);
                    db.SaveChanges();
                }

                /*Adoption form*/
                int provinceid = Int32.Parse(Request.Form["province"].ToString());
                Adoption adoption = new Adoption();
                adoption.topicid = newTopic.id;
                adoption.condition = Request.Unvalidated["condition"];
                adoption.provinceid = provinceid;
                adoption.status = 1;
                db.Adoption.Add(adoption);
                db.SaveChanges();

                /*Catadoption*/
                Catadoption catadoption = new Catadoption();
                catadoption.catid = wantownercat.id;
                catadoption.adoptionid = adoption.id;
                db.Catadoption.Add(catadoption);
                db.SaveChanges();
            }
            return RedirectToAction("MyForum", "Home");
        }


        public ActionResult Detail(int? topicid)
        {
            Topic topic = db.Topic.Find(topicid);
            return View(topic);
        }

        public ActionResult AdoptionForm()
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