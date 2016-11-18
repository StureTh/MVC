using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

            public static List<User> userList = new List<User>(); 

        public ActionResult Index()
        {
            return View();
        }


        // Register
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User userAccount)
        {
            if (ModelState.IsValid)
            {
                userList.Add(userAccount);

                return RedirectToAction("Registerd", new { userName = userAccount.Name });
            }
            else
            {
                return View(userAccount);
            }
        }

        public ActionResult Registerd(string userName)
        {
            ViewBag.name = userName;
            return View();
        }


        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userAccount)
        {
            var user =
                userList.FirstOrDefault(usr => usr.Mail == userAccount.Mail && usr.Password == userAccount.Password);
            if (user != null)
            {
                Session["UserName"] = user.Name;
                Session["Mail"] = user.Mail;
                Session["Password"] = user.Password;
                Session["Admin?"] = user.IsAdmin;



                return RedirectToAction("LoggedIn");
            }

            return View(userAccount);

        }

        public ActionResult LoggedIn()
        {
            return View();
        }



        
    }
}