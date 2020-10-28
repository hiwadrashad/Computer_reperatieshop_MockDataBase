using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class KlantController : Controller
    {
        // GET: Klant

        public ActionResult ChangeDataKlantOnlyForEmployees(string id)
        {
            return View(Singleton.MockDataService2.GetKlant(id));
        }

        [HttpPost]

        public ActionResult KlantOverviewOnlyForEmployees(ClientModel clientModel)
        {
            SingletonData.Singleton.MockDataService2.UpdateKlant(clientModel);
            return RedirectToAction("KlantOverviewOnlyForEmployees");
        }

        public ActionResult DeleteDataKlantOnlyForEmployees(string id)
        {
            return View(Singleton.MockDataService2.GetKlant(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteDataKlantOnlyForEmployees(ClientModel clientModel)
        {
            SingletonData.Singleton.MockDataService2.DeleteKlant(clientModel.Id);
            return RedirectToAction("KlantOverviewOnlyForEmployees");
        }

        public ActionResult CreateKlantAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateKlantAccount(ClientModel clientModel)
        {

            Singleton.MockDataService2.AddKlant(clientModel);
            return RedirectToAction("ChooseLoginOrCreateAccountKlant");
        }


        public ActionResult ChangeDataKlant()
        {
            return View(Singleton.StoreKlantLoginData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ChangeDataKlant(ClientModel clientModel)
        {
            try
            {
                SingletonData.Singleton.MockDataService2.UpdateKlant(clientModel);
                return RedirectToAction("ChooseLoginOrCreateAccountKlant");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult KlantOverviewOnlyForEmployees()
        {
            return View(SingletonData.Singleton.MockDataService2.GetAllKlanten());
        }


        public ActionResult ChooseLoginOrCreateAccountKlant()
        {
            return View();
        }


    }
}