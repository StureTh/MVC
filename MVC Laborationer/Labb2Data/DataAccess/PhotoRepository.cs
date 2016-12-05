using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class PhotoRepository:IPhotoRepository
    {
        public List<PhotoDataModel> GetPhotos()
        {
            using (TheContext ctx = new TheContext())
            {
                var list = ctx.Photos.ToList();
                return list;
            }
        }

        public PhotoDataModel GetPhotoById(Guid id)
        {
            using (TheContext ctx = new TheContext())
            {
                var photo = ctx.Photos.Include("Comments").FirstOrDefault(x => x.PhotoId == id);
                return photo;
            }
        }

        public void AddNewPhoto(PhotoDataModel photo)
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
        public IEnumerable<PhotoDataModel> GetRecentUploads(int count)
        {
            using (TheContext ctx = new TheContext())
            {
                var list = ctx.Photos.OrderByDescending(x => x.UploadDate).Take(count).ToList();
                return list;
            }
        }
    }
}
