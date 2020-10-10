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
        public ActionResult CreateKlantAccount()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateKlantAccount(ClientModel clientModel)
        {

            Singleton.StoreKlant.AddItem(clientModel);
            return View("ChooseLoginOrCreateAccountKlant");
        }


        public ActionResult ChangeDataKlant()
        {
            return View(Singleton.StoreKlantLoginData);
        }

        [HttpPost]

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
    }
}