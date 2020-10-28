using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class PartsController : Controller
    {
        // GET: Parts

        public ActionResult OnderdelenOverview()
        {
            return View(Singleton.MockDataService2.GetAllOnderdeel().ToList());
        }
        public ActionResult VoegNieuwOnderdeelToe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoegNieuwOnderdeelToe(PartModel partModel)
        {
            try
            {
                Singleton.MockDataService2.AddOnderdeel(partModel);
                return RedirectToAction("OnderdelenOverview");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult VeranderDataOnderdeeel(string id)
        {
            return View(Singleton.MockDataService2.GetOnderdeel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VeranderDataOnderdeeel(PartModel partModel)
        {
            try
            {
                Singleton.MockDataService2.UpdateOnderdeel(partModel);
                return RedirectToAction("OnderdelenOverview");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteOnderdeel(string id)
        {
            return View(Singleton.MockDataService2.GetOnderdeel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteOnderdeel(PartModel partModel)
        {
            try
            {
                Singleton.MockDataService2.DeleteOnderdeel(partModel.id);
                return RedirectToAction("OnderdelenOverview");
            }
            catch
            {
                return View();
            }
        }
    }
}