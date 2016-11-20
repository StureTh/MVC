using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Labb1.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }

        public string ImgUrl { get; set; }

    }
}