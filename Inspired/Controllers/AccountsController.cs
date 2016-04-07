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
    public class AccountsController : Controller
    {
        private CatsInTheBoxContext db = new CatsInTheBoxContext();
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "username,password")] Account account)
        {
            var Authentication = db.Account.Where(a => a.username == account.username && a.password == account.password).FirstOrDefault<Account>();

            if (Authentication != null)
            {
                Session["Authen"] = true;
                if (account.usertypeid == 1)
                    Session["Autho"] = true;
                else
                    Session["Autho"] = false;

                Session["username"] = Authentication.username;
                Session["accountid"] = Authentication.id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Autho"] = null;
                Session["username"] = null;
                Session["accountid"] = null;
                ViewBag.LoginError = "Your username or password may be wrong!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Authen"] = null;
            Session["Username"] = null;
            Session["AccountID"] = null;
            return RedirectToAction("Login", "Accounts");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,username,password,email,usertypeid")] Account account)
        { 
            account.usertypeid = 2;
            if (ModelState.IsValid) {
                var CheckUserNameDup = db.Account.Where(a => a.username == account.username).FirstOrDefault<Account>();
                var CheckEmailDup = db.Account.Where(a => a.email == account.email).FirstOrDefault<Account>();
                var repassword = Request.Form["repassword"];

                if (CheckUserNameDup != null)
                {
                    ViewBag.RegisterError = "This username is already in use.";
                    return View();
                }
                if (CheckEmailDup != null)
                {
                    ViewBag.RegisterError = "This email adress is already in use.";
                    return View();
                }
                if (account.username == null)
                {
                    ViewBag.RegisterError = "Please input username.";
                    return View();
                }
                if (account.password == null)
                {
                    ViewBag.RegisterError = "Please input password.";
                    return View();
                }
                if (repassword == null)
                {
                    ViewBag.RegisterError = "Please input re-password.";
                    return View();
                }
                if (account.email == null)
                {
                    ViewBag.RegisterError = "Please input password.";
                    return View();
                }
                if ((account.password != null) && (repassword != null) && (account.password != repassword))
                {
                    ViewBag.RegisterError = "Password does not match the re-password";
                    return View();
                }
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(account);
        }


    }
}