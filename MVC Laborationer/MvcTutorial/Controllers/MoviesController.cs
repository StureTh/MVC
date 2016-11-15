using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTutorial.Models;

namespace MvcTutorial.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Star wars" };
            //return View(movie);
            return HttpNotFound();
        }
    }
}