using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ViewModel
{
    public class ViewModel
    {

        public class AddStatusViewModel
        {
            public Models.ModelStatus StatusBar { get; set; }

            public Models.ModelReparatie Reperatie { get; set; }
        }
    }
}