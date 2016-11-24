using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;

namespace Labb2.Controllers
{
    public class GalleryController : Controller
    {
        public static readonly DataAccess Dal = new DataAccess();
        // GET: Gallery
        public ActionResult Index()
        {
            if (Session["UserId"]!= null)
            {
                var photoList = Dal.GetPhotos();
                return View(photoList);
            }
            return RedirectToAction("Login","Account");
        }

        public ActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photo photo, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                if (image == null)
                {
                    return View(photo);
                }
                return View(photo);
            }
            photo.PhotoUrl = "~/GalleryPhotos/" + image.FileName;
            photo.UploadDate = DateTime.Now;
            photo.PhotoId = Guid.NewGuid();
            Dal.AddNewPhoto(photo);

            image.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), image.FileName));
            return RedirectToAction("Index");


        }
    }
}