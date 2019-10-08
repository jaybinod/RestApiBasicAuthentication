using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeloipWebApi.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool ActiveStatus { get; set; }

        public bool LockStatus { get; set; }
    }

    public class LoginUser
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class UserLog
    {

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Action { get; set; }
        public System.DateTime ActionDateTime { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}