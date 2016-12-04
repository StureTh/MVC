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
            //if (Session["UserId"]!= null)
            //{
            //    var photoList = Dal.GetPhotos();
            //    return View(photoList);
            //}
            //return RedirectToAction("Login","Account");
          

            // Test till Album
            if (Session["UserId"] !=null)
            {
                var albumList = Dal.GetAlbums();
                return View(albumList);
            }
            return RedirectToAction("Login", "Account");
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

        public ActionResult ShowImage(Guid id)
        {
            var photo = Dal.GetPhotoById(id);
            return View(model: photo);
        }

        public ActionResult RecentUpload()
        {
            var list = Dal.GetRecentUploads(3);
            return PartialView(model: list);
            
        }

        
        public ActionResult DeletePhoto(string photoId)

        {
            var inputPhotoId = Guid.Parse(photoId);
            var photo = Dal.GetPhotoById(inputPhotoId);
            string absolutePath = HttpContext.Server.MapPath((photo.PhotoUrl));
            if (System.IO.File.Exists(absolutePath))
            {
                Dal.DeletePhoto(photo.PhotoId);
                System.IO.File.Delete(absolutePath);
                return RedirectToAction("Index", "Gallery");
            }



            return RedirectToAction("Index","Gallery");


        }


    }
}