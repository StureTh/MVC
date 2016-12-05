using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using Labb2Data;

namespace Labb2.Models
{
    public class User
    {
        
        public Guid UserId { get; set; }

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

       

        public List<Album> Albums { get; set; }

        public UserDataModel Transform()
        {
            var dataModel = new UserDataModel
            {
                UserId = this.UserId,
                UserName = this.UserName,
                Mail = this.Mail,
                Password = this.Password,
                ConfirmPassword = this.ConfirmPassword,
                Albums = this.Albums.Select(a => a.Transform()).ToList()
            };
            return dataModel;
        }

        public User(UserDataModel userData)
        {
            UserId = userData.UserId;
            UserName = userData.UserName;
            Mail = userData.Mail;
            Password = userData.Password;
            ConfirmPassword = userData.ConfirmPassword;
            Albums = new List<Album>();
        }

        public User()
        {
            Albums = new List<Album>();
        }
    }
}