using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;
using System.IO;

namespace Labb2.Controllers
{
    
    public class AlbumController : Controller
    {
        DataAccess Dal = new DataAccess();
        // GET: Album
        public ActionResult Index()
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}

            //var photolist = Dal.GetPhotos();


            //return View(photolist);
            return View();

        }
        public ActionResult NewAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                if (album == null)
                {
                    return View(album);
                }

                return View(album);
            }

            album.AlbumId = Guid.NewGuid();


            Dal.AddNewAlbum(album, (Guid)Session["UserId"]);
            return RedirectToAction("Index", "Gallery");

        }

        public ActionResult ViewAlbum(Guid id)
        {
            var album = Dal.GettAlbumById(id);
            return View(model: album);
                
                
            

        }

        public ActionResult UploadToAlbum(Guid albumId)
        {
            ViewBag.id = albumId;
            return View();
        }

        [HttpPost]
        public ActionResult UploadToAlbum(Photo photo, HttpPostedFileBase file, Guid albumId)
        {
            var user = Dal.GettUserByID((Guid)Session["UserId"]);
            var album = Dal.GettAlbumById(albumId);



            if (user.Albums.Any(x => x.AlbumId == albumId))
            {


                if (!ModelState.IsValid)
                {
                    if (file == null)
                    {
                        return View(photo);
                    }
                    return View(photo);
                }








                photo.PhotoId = Guid.NewGuid();
                photo.UploadDate = DateTime.Now;
                photo.PhotoUrl = "~/GalleryPhotos/" + file.FileName;

                Dal.SavePhotoInAlbum(albumId, photo);

                file.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), file.FileName));


                return RedirectToAction("ViewAlbum", "Album", new { id = albumId });
            }
            else
            {
                return View(photo);
            }




        }






    }
}