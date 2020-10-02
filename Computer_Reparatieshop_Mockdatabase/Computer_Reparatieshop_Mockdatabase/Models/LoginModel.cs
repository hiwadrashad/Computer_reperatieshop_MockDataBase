using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class LoginModel
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Login error")]

        public string LoginErrorMessage { get; set; }
    }
}