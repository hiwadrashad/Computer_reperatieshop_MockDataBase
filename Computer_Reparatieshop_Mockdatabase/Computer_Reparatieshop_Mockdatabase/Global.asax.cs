using Computer_Reparatieshop_Mockdatabase.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Computer_Reparatieshop_Mockdatabase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (SingletonData.Singleton.AllInitialized == false)
            {
                SingletonData.Singleton.StoreClientRequest = new MockDataServiceClientRequest();
                SingletonData.Singleton.StoreLogin = new MockDataserviceLogin();
                SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                SingletonData.Singleton.StoreFactory = new Factory();
                SingletonData.Singleton.StoreWerknemer = new MockDataServiceWerknemer();
                SingletonData.Singleton.StoreKlant = new MockDataServiceKlant();
                SingletonData.Singleton.StoreParts = new MockDataServiceStoreParts();
                SingletonData.Singleton.AllInitialized = true;
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
