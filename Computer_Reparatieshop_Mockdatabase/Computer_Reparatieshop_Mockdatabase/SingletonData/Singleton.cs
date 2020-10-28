using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using iTextSharp.text.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.SingletonData
{
    public static class Singleton
    {
        public static MockDataService2 MockDataService2 { get; set; }
        public static Factory StoreFactory { get; set; }

        public static bool AllInitialized = false;
        public static ClientModel StoreKlantLoginData {get; set;}
        public static WerknemerModel StoreWerknemerLoginData { get; set; }

    }
}