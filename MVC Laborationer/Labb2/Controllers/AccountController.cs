using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;
using Labb2Data;


namespace Labb2.Controllers
{
    public class AccountController : Controller
    {
        private static UserRepository Dal = new UserRepository();
        
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
            Dal.AddNewUser(userAccount.Transform());
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
            var user = Dal.LoginUser(userAccount.Transform());
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                Session["Mail"] = user.Mail;
                Session["Password"] = user.Password;
               

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
                return Redirect("Login");
            }
            return Redirect(url);
        }

       

    }
   
}