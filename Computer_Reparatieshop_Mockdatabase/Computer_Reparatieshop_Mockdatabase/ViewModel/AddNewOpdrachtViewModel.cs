using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.ViewModel
{
    public class AddNewOpdrachtViewModel
    {
        public List<SelectListItem> GenerateDropDownDataFromPart { get; set; }

        public List<SelectListItem> GenerateDropDownDataFromClients { get; set; }

        public List<SelectListItem> GenerateDropDownDataFromWerknemer { get; set; }

        public Models.ModelReparatie ModelReparatie { get; set; } 
    }
}