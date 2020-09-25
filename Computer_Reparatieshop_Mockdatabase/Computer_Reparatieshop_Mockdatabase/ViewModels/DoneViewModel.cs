using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class DoneViewModel
    {
        public string id { get; set; }
        public ModelReparationDone basemodel { get; set; }
        public SelectListItem onderdelen { get; set; }


    }
}