using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            var photoList =
                Directory.EnumerateFiles(Server.MapPath("~/PhotoGallery"))
                    .Select(photo => "~/PhotoGallery/" + Path.GetFileName(photo)).ToList();
            return View(photoList);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase file)
        {
            file.SaveAs(Path.Combine(Server.MapPath("~/PhotoGallery"), file.FileName));

            return View();
        }

        public ActionResult ShowImg(string image)
        {
            return View(model:image);
        }
    }
}