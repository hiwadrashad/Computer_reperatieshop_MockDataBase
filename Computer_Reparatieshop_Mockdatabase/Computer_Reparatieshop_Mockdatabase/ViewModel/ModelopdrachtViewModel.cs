using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.ViewModel
{
    public class ModelopdrachtViewModel
    {

        [Display(Name = "Aantal in afwachting")]

        public int aantalinafwachting { get; set; }

        [Display(Name = "Aantal in behandeling")]

        public int aantalinbehandeling { get; set; }

        [Display(Name = "Aantal wachten op onderdelen")]

        public int aantalwachtoponderdelen { get; set; }

        [Display(Name = "Aantal klaar")]

        public int aantaalklaar { get; set; }
        
        [Display(Name = "Opdrachten")]

        public SelectListItem status { get; set; }

        public SelectListItem StoreChoiceKlantFromDropDownList { get; set; }

        public SelectListItem StoreChoiceReperateurFromDropDownList { get; set; }

        public SelectListItem StoreChoicesOnderdelen { get; set; }

        List<ModelReparatie> opdrachtenlijst { get; set; }
    }
}