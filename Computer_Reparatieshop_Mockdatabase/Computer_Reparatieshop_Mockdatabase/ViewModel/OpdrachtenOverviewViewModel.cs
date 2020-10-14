using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.ViewModel
{
    public class OpdrachtenOverviewViewModel
    {
        [Display(Name = "Aantal in afwachting")]

        public int aantalinafwachting { get; set; }

        [Display(Name = "Aantal in behandeling")]

        public int aantalinbehandeling { get; set; }

        [Display(Name = "Aantal wachten op onderdelen")]

        public int aantalwachtoponderdelen { get; set; }

        [Display(Name = "Aantal klaar")]

        public int aantaalklaar { get; set; }

        [Display(Name = "Start datum")]
        [DataType(DataType.Date)]
        public DateTime? StartDatum { get; set; }

        [Display(Name = "Eind datum")]
        [DataType(DataType.Date)]

        public DateTime? EindDatum { get; set; }

        public SelectListItem status { get; set; }

        public string Omschrijving { get; set; }

        public ClientModel Klant { get; set; }

        public SelectListItem StoreChoiceKlantFromDropDownList { get; set; }

        public WerknemerModel Reparateur { get; set; }

        public SelectListItem StoreChoiceReperateurFromDropDownList { get; set; }

        public List<SelectListItem> StoreChoicesOnderdelen { get; set; }

        [Display(Name = "Prijs producten")]
        public double PrijsProducten { get; set; }

        [Display(Name = "Prijs arbeid")]

        public double PrijsArbeid { get; set; }

        public double Totaal { get; set; }

        public PartModel onderdelen { get; set; }

        public List<ModelReparatie> modelReparatie { get; set; }
    }
}