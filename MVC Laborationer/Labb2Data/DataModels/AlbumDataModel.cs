using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class AlbumDataModel
    {
        [Key]
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }
        public virtual ICollection<PhotoDataModel> Photos { get; set; }

        public AlbumDataModel()
        {
                this.Photos = new HashSet<PhotoDataModel>();
        }
    }
}
