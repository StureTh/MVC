﻿using System;
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
                var image = ctx.Photos.FirstOrDefault(x => x.PhotoId == id);
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

        internal object GetRecentUploads(int count)
        {
            using (TheContext ctx = new TheContext())
            {
                var list = ctx.Photos.OrderByDescending(x => x.UploadDate).Take(count).ToList();
                return list;
            }
        }

        public void AddNewAlbum(Album album)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Albums.Add(album);
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
        public User LoginUser(User user)
        {
            using(TheContext ctx = new TheContext())
            {
                var userToLogin = ctx.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
                return userToLogin;
            }
        }

        public void AddNewComment(Comment comment)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }
        }
    }
}