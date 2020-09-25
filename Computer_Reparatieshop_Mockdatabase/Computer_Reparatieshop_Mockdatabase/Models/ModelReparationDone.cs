using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ModelReparationDone
    {

        public string Id { get; set; }

        public string Omschrijving { get; set; }

        public string Klant { get; set; }

        public string Reparateur { get; set; }

        public double PrijsProducten { get; set; }

        public double PrijsArbeid { get; set; }

        public double Totaal { get; set; }
    }


}