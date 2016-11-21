using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb2.Models
{
    public class Photo
    {
        public Guid PhotoId { get; set; }

        public string PhotoName { get; set; }

        public DateTime UploadDate { get; set; }

        
        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

    }
}