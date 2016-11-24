using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;
namespace Labb2.Controllers
{
    public class AccountController : Controller
    {
        private static DataAccess Dal = new DataAccess();
        
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User userAccount)
        {
            if (!ModelState.IsValid)
            {
                return View(userAccount);

            }
            userAccount.UserId = Guid.NewGuid();
            Dal.AddNewUser(userAccount);
            ViewBag.Message = userAccount.UserName + "Success";

            return View();



        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userAccount)
        {
            var user = Dal.LoginUser(userAccount);
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                Session["Mail"] = user.Mail;
                Session["Password"] = user.Password;
                Session["Admin"] = user.IsAdmin;

                return RedirectToAction("LoggedIn");
            }
            else
            {
                return View(userAccount);
            }
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserName"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout(string url)
        {
            if (Session["Mail"] != null)
            {
                Session.Clear();
                return Redirect(url);
            }
            return Redirect(url);
        }

    }
}