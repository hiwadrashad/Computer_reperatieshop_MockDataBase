﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Models
{
    public class ModelReparatie
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Start datum")]
        [DataType(DataType.Date)]
        public DateTime? StartDatum { get; set; }

        [Display(Name = "Eind datum")]
        [DataType(DataType.Date)]

        public DateTime? EindDatum { get; set; }

        public string status { get; set; }

        public string Omschrijving { get; set; }

        public  ClientModel Klant { get; set; }

        public WerknemerModel Reparateur { get; set; }

        [Display(Name = "Prijs producten")]
        public double PrijsProducten { get; set; }

        [Display(Name = "Prijs arbeid")]

        public double PrijsArbeid { get; set; }

        public double Totaal { get; set; }

        public PartModel onderdelen { get; set; }

    }

}