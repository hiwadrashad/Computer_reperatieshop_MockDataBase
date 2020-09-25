using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ModelReparationInProgress
    {
        public string Id { get; set; }

        [Display(Name = "Start datum")]
        [DataType(DataType.Date)]
        public DateTime? StartDatum { get; set; }

        [Display(Name = "Eind datum")]
        [DataType(DataType.Date)]

        public DateTime? EindDatum { get; set; }

    }

}