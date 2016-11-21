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
       private static IList<Photo> UpdatedPhotoList = new List<Photo>();
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
            photo.UploadDate = DateTime.Now;
            photo.ImgUrl = "~/PhotoGallery" + file.FileName;
             
            UpdatedPhotoList.Add(photo);


            file.SaveAs(Path.Combine(Server.MapPath("~/PhotoGallery"), file.FileName));

            return View();
        }

        public ActionResult ShowImg(string image)
        {
            return View(model:image);
        }

        public ActionResult Delete(string image)
        {
            string imgPath = HttpContext.Server.MapPath(image);
            if (System.IO.File.Exists(imgPath))
            {
                System.IO.File.Delete(imgPath);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowImg", new {image = image});
            }
        }

        public ActionResult RecentPhotos()
        {
            if (UpdatedPhotoList != null)
            {
                var list = UpdatedPhotoList.OrderByDescending(x => x.UploadDate)
                    .Take(3)
                    .ToList();
                ViewBag.list = list;
            }
            return PartialView();
        }
    }
}