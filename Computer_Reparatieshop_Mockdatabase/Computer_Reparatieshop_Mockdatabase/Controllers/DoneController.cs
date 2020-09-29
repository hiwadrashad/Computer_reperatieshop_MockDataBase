using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class DoneController : Controller
    {
        // GET: Done
        public ActionResult Index()
        {
            if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
            {
                SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                SingletonData.Singleton.StoreReparationDoneInitialized = true;
            }

            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(SingletonData.Singleton.StoreReparationDone.ReturnList());
        }

        // GET: Done/Details/5
        public ActionResult Details(DoneViewModel model)
        {
            if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
            {
                SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                SingletonData.Singleton.StoreReparationDoneInitialized = true;
            }

            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(model);
        }

        // GET: Done/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Done/Create
        [HttpPost]
        public ActionResult Create(DoneViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
                {
                    SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                    SingletonData.Singleton.StoreReparationDoneInitialized = true;
                }

                foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
                {
                    item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
                }

                SingletonData.Singleton.StoreReparationDone.AddItem(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
