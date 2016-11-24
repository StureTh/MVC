using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.CodeDom;

namespace Labb2.Models
{
    public class Photo
    {
        
        public Guid PhotoId { get; set; }

        [Required(ErrorMessage ="Enter image name")]
        [MinLength(3),MaxLength(20)]
        public string PhotoName { get; set; }

        public DateTime? UploadDate { get; set; }

        
        
        public string PhotoUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}