using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer


        // GET: Login/Edit/5

        public ActionResult WerknemerArea()
        {
            return View();
        }

        public ActionResult ChangeDataWerknemer()
        {
            return View(Singleton.StoreWerknemerLoginData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDataWerknemer(WerknemerModel werknemerModel)
        {

            try
            {
                Singleton.StoreWerknemer.UpdateItem(werknemerModel);
                return RedirectToAction("WerknemerArea");
            }
            catch
            {
                return View();
            }

        }




    }
}