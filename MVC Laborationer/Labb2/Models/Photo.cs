using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.CodeDom;
using Labb2Data;

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

        public  List<Album> Albums { get; set; } 

        public List<Comment> Comments { get; set; }

        public PhotoDataModel Transform()
        {
            var dataModel = new PhotoDataModel
            {
                PhotoId = this.PhotoId,
                PhotoName = this.PhotoName,
                UploadDate = this.UploadDate,
                PhotoUrl = this.PhotoUrl,
                Albums = this.Albums.Select(a => a.Transform()).ToList(),
                Comments = this.Comments.Select(c => c.Transform()).ToList()
            };
            return dataModel;
        }
        public Photo(PhotoDataModel photoData)
        {
            PhotoId = photoData.PhotoId;
            PhotoName = photoData.PhotoName;
            UploadDate = photoData.UploadDate;
            PhotoUrl = photoData.PhotoUrl;
            Albums = new List<Album>();
            Comments = new List<Comment>();
        }

        public Photo()
        {
            Albums = new List<Album>();
            Comments = new List<Comment>();
        }
    }
}