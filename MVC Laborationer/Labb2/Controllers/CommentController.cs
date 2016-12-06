using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb2.Models;
using Labb2Data;


namespace Labb2.Controllers
{
    public class CommentController : Controller
    {
        CommentRepository _dal = new CommentRepository();
        // GET: Comment
        public ActionResult Index()
        { 
            return View();
        }

        //[HttpGet]
        public ActionResult ViewComments(Guid photoId)
        {



            var comment = _dal.GetPhotoComments(photoId).Select(x => new Comment(x)).ToList();
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

                _dal.AddNewComment(photoId, comment.Transform());
                return PartialView();
            }
            else
            {
                return View(comment);
            }
        }

        public ActionResult DeleteComment(Guid commentId,Guid photoId)
        {
            
           
            _dal.DeleteComment(commentId);
            return RedirectToAction("ShowImage", "Gallery",new {id = photoId });

        }
    }
} 