using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Labb2Data;

namespace Labb2.Models
{
    public class Comment
    {
        
        public Guid CommentId { get; set; }
        [Required(ErrorMessage = "Please enter Comment")]
        public string CommentComment { get; set; }

        public DateTime Date { get; set; }

        public  Guid PhotoId { get; set; }

        public  Guid CommentByUserId { get; set; }


        public CommentDataModel Transform()
        {
            var dataModel = new CommentDataModel
            {
                CommentId = this.CommentId,
                CommentComment = this.CommentComment,
                Date = this.Date,
                PhotoId = this.PhotoId,
                CommentByUserId = this.CommentByUserId
            };
            return dataModel;
        }

        public Comment(CommentDataModel commentData)
        {
            CommentId = commentData.CommentId;
            CommentComment = commentData.CommentComment;
            Date = commentData.Date;
            PhotoId = commentData.PhotoId;
            CommentByUserId = commentData.CommentByUserId;
        }

        public Comment()
        {
            
        }

    }
}