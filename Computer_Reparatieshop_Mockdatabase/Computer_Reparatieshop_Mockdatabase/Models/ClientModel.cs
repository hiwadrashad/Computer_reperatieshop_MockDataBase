using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ClientModel
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Gebruikers naam")]

        public string GebruikersNaam { get; set; }

        public string Wachtwoord { get; set; }
        public string Naam { get; set; }

        [Display( Name = "Straat naam")]

        public string Straatnaam { get; set; }

        [Display( Name = "Adress nummer")]
        public int AdressNummer { get; set; }

        [Display( Name ="Post code")]

        public string PostCode { get; set; }

        public string Plaats { get; set; }

        [Display( Name = "Telefoon nummer")]

        [Phone]
        public string telefoonnummer { get; set; }
    }
}