using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Labb2Data;

namespace Labb2.Models
{
    public class Album
    {
        
        public Guid AlbumId { get; set; }

        [Required(ErrorMessage ="Must enter album name")]
        public string AlbumName { get; set; }
        public List<Photo> Photos { get; set; }

        public AlbumDataModel Transform()
        {
            var dataModel = new AlbumDataModel
            {
                AlbumId = this.AlbumId,
                AlbumName = this.AlbumName,
                Photos = this.Photos.Select(p => p.Transform()).ToList()
            };
            return dataModel;
        }

        public Album(AlbumDataModel Albumdata)
        {
            AlbumId = Albumdata.AlbumId;
            AlbumName = Albumdata.AlbumName;
            Photos = new List<Photo>();
        }

        public Album()
        {
            Photos = new List<Photo>();
        }
    }
}