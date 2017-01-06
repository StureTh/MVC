using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labb2.Areas.MyArea.Controllers
{
    public class MyAreaController : Controller
    {
        // GET: MyArea/MyArea
        public ActionResult Index()
        {
            return View();
        }
    }
}