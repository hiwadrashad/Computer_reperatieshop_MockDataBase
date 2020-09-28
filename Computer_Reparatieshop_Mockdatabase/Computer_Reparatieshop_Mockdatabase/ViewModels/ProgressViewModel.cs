using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class ProgressViewModel
    {
        public string id { get; set; }

        public ModelReparationInProgress basemodel { get; set; }

        public SelectListItem status { get; set; }
    }
}