using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;

namespace Labb2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        [MinLength(3),MaxLength(20)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re enter password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}