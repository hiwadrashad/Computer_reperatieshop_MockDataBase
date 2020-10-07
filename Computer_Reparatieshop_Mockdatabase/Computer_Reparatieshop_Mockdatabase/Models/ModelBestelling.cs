using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ModelBestelling
    {
        [Key]
        public string Id { get; set; }

        public string omschrijving { get; set; }

        [Display(Name = "opgeslagen foto")]
        public HttpPostedFileBase StoredImage { get; set; }

        public ClientModel ClientLogin { get; set; }

        public DateTime? Datum { get; set; }

        [Display(Name = "Ophalen of niet")]

        public OphalenJaNee opgehaald { get;set;}

        [Display(Name = "Extra informatie")]

        public string extrainformatie { get; set; }


    }

}