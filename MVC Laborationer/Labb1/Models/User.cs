using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }


        [Required (ErrorMessage = "Please enter UserName")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Mail is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password",ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public bool IsAdmin { get; set; }

    }
}