﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.ViewModel
{
    public class ChangeDataOpdrachtViewModel
    {

        public List<SelectListItem> GenerateDropDownDataFromPart { get; set; }

        public List<SelectListItem> GenerateDropDownDataFromClients { get; set; }

        public List<SelectListItem> GenerateDropDownDataFromWerknemer { get; set; }

        [Required]
        public string StoreChoiceKlantFromDropDownList { get; set; }

        [Required]
        public string StoreChoiceReperateurFromDropDownList { get; set; }

        [Required]
        public string StoreChoicesOnderdelen { get; set; }

        public Models.ModelReparatie ModelReparatie { get; set; }
    }
}