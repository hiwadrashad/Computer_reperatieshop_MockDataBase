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
            return View(Singleton.StoreKlant.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KlantOverviewOnlyForEmployees(ClientModel clientModel)
        {
            SingletonData.Singleton.StoreKlant.UpdateItem(clientModel);
            return RedirectToAction("KlantOverviewOnlyForEmployees");
        }

        public ActionResult DeleteDataKlantOnlyForEmployees(string id)
        {
            return View(Singleton.StoreKlant.GetItem(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteDataKlantOnlyForEmployees(ClientModel clientModel)
        {
            SingletonData.Singleton.StoreKlant.DeleteItem(clientModel.Id);
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

            Singleton.StoreKlant.AddItem(clientModel);
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
                SingletonData.Singleton.StoreKlant.UpdateItem(clientModel);
                return RedirectToAction("ChooseLoginOrCreateAccountKlant");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult KlantOverviewOnlyForEmployees()
        {
            return View();
        }



  
    }
}