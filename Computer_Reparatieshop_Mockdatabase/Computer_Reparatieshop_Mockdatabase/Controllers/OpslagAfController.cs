using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
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
    public class OpslagAfController : Controller
    {
        // GET: Done
        public ActionResult Index()
        {
 

            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllReparaties().ToList())
            {
                item.Totaal = item.PrijsArbeid + item.PrijsProducten;
            }
            return View(SingletonData.Singleton.MockDataService2.GetAllReparaties().ToList());
        }

        // GET: Done/Details/5


        public ActionResult Details(string id)
        {
           
            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllReparaties().ToList())
            {
                item.Totaal = item.PrijsArbeid + item.PrijsProducten;
            }
            return View(SingletonData.Singleton.MockDataService2.GetAllReparaties().Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: Done/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Done/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ModelReparatie model)
        {
            try
            {
                // TODO: Add insert logic here
                
                foreach (var item in SingletonData.Singleton.MockDataService2.GetAllReparaties().ToList())
                {
                    item.Totaal = item.PrijsArbeid + item.PrijsProducten;
                }

                SingletonData.Singleton.MockDataService2.AddReparatie(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
