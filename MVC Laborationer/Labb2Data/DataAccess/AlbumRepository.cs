using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class AlbumRepository: IAlbumRepository
    {
        public void AddNewAlbum(AlbumDataModel album, Guid userId)
        {
            using (TheContext ctx = new TheContext())
            {
                ctx.Albums.Add(album);
                var user = ctx.Users.Include("Albums").FirstOrDefault(x => x.UserId == userId);
                user.Albums.Add(album);
                ctx.SaveChanges();
            }
        }

        public AlbumDataModel GetAlbumById(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(a => a.AlbumId == id);
                return album;
            }
        }

        public List<AlbumDataModel> GetAlbums()
        {
            using (TheContext ctx = new TheContext())
            {
                var albumList = ctx.Albums.Include("Photos").ToList();
                return albumList;
            }
        }

        public void SavePhotoInAlbum(Guid id, PhotoDataModel photo)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(a => a.AlbumId == id);
                album.Photos.Add(photo);
                ctx.SaveChanges();
            }
        }
        public void DeleteAlbum(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(a => a.AlbumId == id);
                ctx.Albums.Remove(album);
                ctx.SaveChanges();
            }
        }

       public List<AlbumDataModel> GetUserAlbum(Guid id)
       {
           using (TheContext ctx = new TheContext())
           {
               var userAlbum = ctx.Users.Include("Albums").FirstOrDefault(u => u.UserId == id);
               return userAlbum.Albums.ToList();
           }
       }

       public List<PhotoDataModel> GetAlbumPhotos(Guid id)
       {
           using (TheContext ctx = new TheContext())
           {
               var album = ctx.Albums.Include("Photos").FirstOrDefault(x => x.AlbumId == id);
               return album.Photos.ToList();
           }
       }
    }
}
