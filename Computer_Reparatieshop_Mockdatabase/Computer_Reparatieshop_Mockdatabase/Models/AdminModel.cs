using Computer_Reparatieshop_Mockdatabase.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class AdminModel : ParentModel
    {

        [Key]
        public override string Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public override string username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public override string password { get; set; }

        [Display(Name = "Login error")]

        public override string LoginErrorMessage { get; set; }


        public override string Naam { get; set; }

        [Display(Name = "Straat naam")]

        public override string Straatnaam { get; set; }

        [Display(Name = "Adress nummer")]
        public override int AdressNummer { get; set; }

        [Display(Name = "Post code")]

        public override string PostCode { get; set; }

        public override string Plaats { get; set; }

        [Display(Name = "Telefoon nummer")]

        [Phone]
        public override string telefoonnummer { get; set; }

        public override HttpPostedFileBase Image { get; set; }

    }
}