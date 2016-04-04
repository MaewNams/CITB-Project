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

                Session["username"] = account.username;
                Session["accountid"] = account.id;
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
            if (ModelState.IsValid)
            {
                account.usertypeid = 2;
                var CheckUserNameDup = db.Account.Where(a => a.username == account.username).FirstOrDefault<Account>();
                var CheckEmailDup = db.Account.Where(a => a.username == account.email).FirstOrDefault<Account>();

                if (CheckUserNameDup != null)
                {
                    ViewBag.RegisterError = "Sorry, this username is already in use.";
                    return View();
                }
                if (CheckEmailDup != null)
                {
                    ViewBag.RegisterError = "Sorry, this email adress is already in use.";
                    return View();
                }
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("/Accounts/Login");
            }

            return View(account);
        }


    }
}