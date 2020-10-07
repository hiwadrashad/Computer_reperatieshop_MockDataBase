using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class WerknemerModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Login error")]

        public string LoginErrorMessage { get; set; }

        public string Naam { get; set; }

        [Display(Name = "Straat naam")]

        public string Straatnaam { get; set; }

        [Display(Name = "Adress nummer")]
        public int AdressNummer { get; set; }

        [Display(Name = "Post code")]

        public string PostCode { get; set; }

        public string Plaats { get; set; }

        [Display(Name = "Telefoon nummer")]

        [Phone]
        public string telefoonnummer { get; set; }


        public HttpPostedFileBase Image { get; set; }

        public RolesWerknemer.Roles rol { get; set; }
    }
}