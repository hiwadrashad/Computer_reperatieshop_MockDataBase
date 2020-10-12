using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class PartModel
    {
        [Key]

        public string id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Aantal")]
        public int numberofpartsavailable { get; set; }

        [Display(Name = "Kwaliteit")]
        public string qualityofpart { get; set; }

    }
}