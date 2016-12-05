using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class CommentRepository:ICommentRepository
    {
        public void AddNewComment(Guid photoId, CommentDataModel comment)
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

       public List<CommentDataModel> GetPhotoComments(Guid id)
       {
           using (TheContext ctx = new TheContext())
           {
               var comments = ctx.Comments.Where(c => c.PhotoId == id).ToList();

               return comments;
           }
       } 
    }
}
