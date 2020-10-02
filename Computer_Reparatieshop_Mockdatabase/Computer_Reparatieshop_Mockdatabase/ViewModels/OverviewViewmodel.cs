using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class OverviewViewmodel
    {
        public string id { get; set; }

        [Display(Name = "Aantal in afwachting")]

        public int aantalinafwachting { get; set; }

        [Display(Name = "Aantal in behandeling")]

        public int aantalinbehandeling { get; set; }

        [Display(Name = "Aantal wachten op onderdelen")]

        public int aantalwachtoponderdelen { get; set; }

        [Display(Name = "Aantal klaar")]

        public int aantaalklaar { get; set; }
    }
}