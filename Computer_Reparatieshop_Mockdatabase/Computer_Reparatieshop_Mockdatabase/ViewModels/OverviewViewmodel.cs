using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class OverviewViewmodel
    {
        public string id { get; set; }

        public int aantalinafwachting { get; set; }

        public int aantalinbehandeling { get; set; }

        public int aantalwachtoponderdelen { get; set; }

        public int aantaalklaar { get; set; }
    }
}