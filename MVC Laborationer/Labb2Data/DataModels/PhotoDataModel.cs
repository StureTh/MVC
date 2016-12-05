using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class PhotoDataModel
    {
        [Key]
        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }
        public DateTime? UploadDate { get; set; }
        public string PhotoUrl { get; set; }

        public virtual ICollection<AlbumDataModel> Albums { get; set; }
        public virtual ICollection<CommentDataModel> Comments { get; set; }

        public PhotoDataModel()
        {
                this.Comments = new HashSet<CommentDataModel>();
        }
    }
}
