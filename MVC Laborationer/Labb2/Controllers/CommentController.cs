using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;


namespace Labb2.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        { 
            return View();
        }
    }
}