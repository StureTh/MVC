using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Labb2.Models
{
    public class Comment
    {
        
        public Guid CommentId { get; set; }

        public string CommentComment { get; set; }

        public DateTime Date { get; set; }

        public virtual Guid UserId { get; set; }
        

    }
}