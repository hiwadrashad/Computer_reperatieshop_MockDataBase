using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class ProgressViewModel
    {
        public string id { get; set; }

        public ModelReparationInProgress basemodel { get; set; }

        public SelectListItem status { get; set; }
        public int aantalinafwachting { get; set; }

        public int aantalinbehandeling { get; set; }

        public int aantalwachtoponderdelen { get; set; }

        public int aantaalklaar { get; set; }
    }
}