using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmsWebUI.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "username is required")]
        [StringLength(25, ErrorMessage = "username is not grater than 25 characters")]
        public string username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(25, ErrorMessage = "password is not grater than 25 characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(25, ErrorMessage = "password is not grater than 25 characters")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "passwords are not equal")]
        public string repeatedPassword { get; set; }
    }
}