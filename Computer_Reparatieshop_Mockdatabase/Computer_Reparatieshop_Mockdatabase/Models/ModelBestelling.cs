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

        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }

        [Display(Name = "Ophalen ja/nee")]

        public OphalenJaNee.ophalen ophalen { get; set; }


        [Display(Name = "Extra informatie")]

        public string extrainformatie { get; set; }


    }

}