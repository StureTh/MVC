using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Data
{
   public class CommentDataModel
    {
        [Key]
        public Guid CommentId { get; set; }

        public string CommentComment { get; set; }
        public DateTime Date { get; set; }
        public Guid PhotoId { get; set; }
        public Guid CommentByUserId { get; set; }   
    }
}
