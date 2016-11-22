using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb2.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage ="Must enter album name")]
        public string AlbumName { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}