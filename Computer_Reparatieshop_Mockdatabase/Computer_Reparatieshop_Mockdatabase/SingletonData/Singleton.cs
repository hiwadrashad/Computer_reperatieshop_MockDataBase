using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.SingletonData
{
    public static class Singleton
    {
        public static MockDataServiceReparationDone StoreReparationDone { get; set; }

        public static MockDataServiceClientRequest StoreClientRequest { get; set; }

        public static MockDataServiceReparationInProgress StoreReparationInProgress { get; set; }

        public static MockDataserviceLogin StoreLogin { get; set; }

        public static MockDataServiceWerknemer StoreWerknemer { get; set; }

        public static MockDataServiceKlant StoreKlant { get; set; }

        public static Factory StoreFactory { get; set; }

        public static bool AllInitialized = false;

        public static ClientModel StoreKlantLoginData {get; set;}

        public static WerknemerModel StoreWerknemerLoginData { get; set; }
    }
}