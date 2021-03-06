﻿using Computer_Reparatieshop_Mockdatabase.DAL;
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
                SingletonData.Singleton.MockDataService2 = MockDataService2.GetMockDataService2();

                SingletonData.Singleton.StoreFactory = new Factory();

                SingletonData.Singleton.AllInitialized = true;
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
