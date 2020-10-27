using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ParentModel
    {
        public virtual string Id { get; set; }

        public virtual string username { get; set; }

        public virtual string password { get; set; }

        public virtual string LoginErrorMessage { get; set; }

        public virtual string Naam { get; set; }

        public virtual string Straatnaam { get; set; }

        public virtual int AdressNummer { get; set; }

        public virtual string PostCode { get; set; }

        public virtual string Plaats { get; set; }

        public virtual string telefoonnummer { get; set; }

        [NotMapped]
        public virtual HttpPostedFileBase Image { get; set; }
    }
}