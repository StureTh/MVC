using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;
using System.IO;
using Labb2Data;
using System.Security.Cryptography.X509Certificates;

namespace Labb2.Controllers
{
    
    public class AlbumController : Controller
    {
        AlbumRepository Dal = new AlbumRepository();
        // GET: Album
        public ActionResult Index()
        {
           
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


            Dal.AddNewAlbum(album.Transform(), (Guid)Session["UserId"]);
            return RedirectToAction("Index", "Gallery");

        } 

        public ActionResult ViewAlbum(Guid id)
        {
            var album = new Album(Dal.GetAlbumById(id));
            album.Photos = Dal.GetAlbumPhotos(id).Select(x => new Photo(x)).ToList();
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
            var userRepo = new UserRepository();
            
            var user = new User(userRepo.GetUserById((Guid)Session["UserId"])); 
            var album = new Album(Dal.GetAlbumById(albumId));


            user.Albums = Dal.GetUserAlbum(user.UserId).Select(x => new Album(x)).ToList();
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

                Dal.SavePhotoInAlbum(albumId, photo.Transform());

                file.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), file.FileName));


                return RedirectToAction("ViewAlbum", "Album", new { id = albumId });
            }
            else
            {
                return View(photo);
            }

            




        }

        public ActionResult DeleteAlbum(Guid albumId)
        {
            var userRepo = new UserRepository();

            var user = new User(userRepo.GetUserById((Guid)Session["UserId"])); 

            user.Albums = Dal.GetUserAlbum(user.UserId).Select(x => new Album(x)).ToList();


                //var albumToDelete = new Album(Dal.GetAlbumById(albumId)); 
            if (user.Albums.Any(u => u.AlbumId == albumId))
            {


                var albumToDelete = Dal.GetAlbumById(albumId);

                   
                    
                        foreach (var img in albumToDelete.Photos)
                        {
                            var filePath = Request.MapPath(img.PhotoUrl);
                            FileInfo file = new FileInfo(filePath);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                    


                    Dal.DeleteAlbum(albumToDelete.AlbumId);
                    return RedirectToAction("Index", "Gallery");

                
            }
            
                return RedirectToAction("Index", "Home");


            


        }

        public ActionResult PhotoSlider(Guid id)
        {
            var album = new Album(Dal.GetAlbumById(id));
            album.Photos = Dal.GetAlbumPhotos(id).Select(x => new Photo(x)).ToList();
            return PartialView(album);
        }






    }
}