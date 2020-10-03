using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class DoneController : Controller
    {
        // GET: Done
        public ActionResult Index()
        {
 

            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(SingletonData.Singleton.StoreReparationDone.ReturnList());
        }

        // GET: Done/Details/5

        public ActionResult Print(string id)
        {

          Singleton.StoreFactory.print.ExecutePrinting(id);


            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
           
            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(SingletonData.Singleton.StoreReparationDone.items.Where(x => x.id == id).FirstOrDefault());
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
