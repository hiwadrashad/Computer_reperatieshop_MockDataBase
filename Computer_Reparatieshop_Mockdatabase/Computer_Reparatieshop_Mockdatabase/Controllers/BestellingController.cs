using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Org.BouncyCastle.Pkix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class BestellingController : Controller
    {
        // GET: Request

        public ActionResult BestellingenOverview()
        {
          
            return View(SingletonData.Singleton.StoreClientRequest.ReturnList());
        }

        public ActionResult ClientGegevens(string id)
        {
            return View(SingletonData.Singleton.StoreClientRequest.GetItem(id).ClientLogin);
        }


        // GET: Request/Create
        public ActionResult AddNewBestelling()
        {
           
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewBestelling(ModelBestelling model, HttpPostedFileBase StoredImage)
        {
            try
            {
                           
                model.StoredImage = StoredImage;

                model.ClientLogin = Singleton.StoreKlantLoginData;
                
                Singleton.StoreClientRequest.AddItem(model);
                
                return RedirectToAction("ChooseLoginOption", "StartPage");
            }
            catch
            {
                return View();
            }
        }



     


    }
}
