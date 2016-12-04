using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;


namespace Labb2.Controllers
{
    public class CommentController : Controller
    {
        DataAccess _dal = new DataAccess();
        // GET: Comment
        public ActionResult Index()
        { 
            return View();
        }

        //[HttpGet]
        public ActionResult ViewComments(Guid photoId)
        {
            var photo = _dal.GetPhotoById(photoId);
            var comment = photo.Comments.OrderByDescending(c => c.Date);
            return PartialView(comment);
        }

        public ActionResult PostComment()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PostComment(Guid photoId,Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentId = Guid.NewGuid();
                comment.Date = DateTime.Now;

                _dal.AddNewComment(photoId, comment);
                return PartialView();
            }
            else
            {
                return View(comment);
            }
        }

        public ActionResult DeleteComment(Guid commentId)
        {
            _dal.DeleteComment(commentId);
            return RedirectToAction("Index", "Gallery");
        }
    }
}