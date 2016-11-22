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
        [Key]
        public int CommentId { get; set; }

        public string CommentComment { get; set; }

        public virtual User UserId { get; set; }
        

    }
}