using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            var photoList =
                Directory.EnumerateFiles(Server.MapPath("~/GalleryPhotos"))
                    .Select(x => "~/GalleryPhotos/" + Path.GetFileName(x)).ToList();

            return View(photoList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase file)
        {
            file.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), file.FileName));

            return View();
        }
    }
}