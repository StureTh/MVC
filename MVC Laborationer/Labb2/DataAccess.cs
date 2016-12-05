using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Labb2.Models;

namespace Labb2
{
    public class DataAccess
    {
        public List<Photo> GetPhotos()
        {
            using (TheContext ctx = new TheContext())
            {
                var list = ctx.Photos.ToList();
                return list;
            }

        }

        public Photo GetPhotoById(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var image = ctx.Photos.Include("Comments").FirstOrDefault(x => x.PhotoId == id);
                return image;
            }
        }
        public void AddNewPhoto(Photo photo)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Photos.Add(photo);
                ctx.SaveChanges();
            }
        }

        public void DeletePhoto(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var photo = ctx.Photos.FirstOrDefault(p => p.PhotoId == id);

                ctx.Photos.Remove(photo);
                ctx.SaveChanges();
            }
        }

        internal object GetRecentUploads(int count)
        {
            using (TheContext ctx = new TheContext())
            {
                var list = ctx.Photos.OrderByDescending(x => x.UploadDate).Take(count).ToList();
                return list;
            }
        }

        public List<Album> GetAlbums()
        {
            using (TheContext ctx = new TheContext())
            {
                var albumList = ctx.Albums.Include("Photos").ToList();

                return albumList;
            }
        }

        public Album GettAlbumById(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(a => a.AlbumId == id);
                return album;
            }
        }

        public void SavePhotoInAlbum(Guid id, Photo photo)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(a => a.AlbumId == id);

                album.Photos.Add(photo);
                ctx.SaveChanges();



            }
        } 

        public void AddNewAlbum(Album album, Guid userId)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Albums.Add(album);
               
                var user = ctx.Users.FirstOrDefault(x => x.UserId == userId);
                user.Albums.Add(album);
                ctx.SaveChanges();
            }
        }

      

        public void DeleteAlbum(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.FirstOrDefault(a => a.AlbumId == id);
                ctx.Albums.Remove(album);
                ctx.SaveChanges();
            }
        }

        public void AddNewUser(User user)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }

        public User GettUserByID(Guid id)
        {
            using(TheContext ctx = new TheContext())
            {
                var currentUser = ctx.Users.Include("Albums").Single(u => u.UserId == id);
                return currentUser;
            }
        }
        public User LoginUser(User user)
        {
            using(TheContext ctx = new TheContext())
            {
                var userToLogin = ctx.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
                return userToLogin;
            }
        }

        public void AddNewComment(Guid photoId,Comment comment)
        {
            using (TheContext ctx = new TheContext())
            {
                var photo = ctx.Photos.Single(p => p.PhotoId == photoId);
                photo.Comments.Add(comment);

                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }
        }

    
        public void DeleteComment(Guid commentId)
        {
            using (TheContext ctx = new TheContext())
            {
                var comment = ctx.Comments.FirstOrDefault(c => c.CommentId == commentId);

                ctx.Comments.Remove(comment);
                ctx.SaveChanges();
            }
        }

      
    }
}