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
        public ActionResult Adminarea()
        {
            return View();
        }

        public ActionResult CreateKlant()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateKlant(ClientModel clientModel)
        {
           
            Singleton.StoreKlant.AddItem(clientModel);
            return View("ChooseLoginOrCreateAccountKlant");
        }

        public ActionResult Login()
        {
            
            return View();

        }

        [HttpPost]
        public ActionResult Autherize(AdminModel userModel)
        {
           
            var UserDetails = SingletonData.Singleton.StoreLogin.Login(userModel.username, userModel.password);
            var UserDetailsWerknemer = Singleton.StoreWerknemer.Login(userModel.username, userModel.password);
            if (UserDetails == true)
            {
                return View("Adminarea");
            }
            else if (UserDetailsWerknemer == true)
            {
                var Werknemer = SingletonData.Singleton.StoreWerknemer.ReturnModelByNameAndPassword(userModel.username, userModel.password);
                SingletonData.Singleton.StoreWerknemerLoginData = Werknemer;
                return View("WerknemerArea");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return View("Login", userModel);

        }

        [HttpPost]
        public ActionResult AutherizeKlant(ClientModel userModel)
        {
            var UserDetails = SingletonData.Singleton.StoreKlant.Login(userModel.GebruikersNaam, userModel.Wachtwoord);
            if (UserDetails == true)
            {
                SingletonData.Singleton.StoreKlantLoginData = userModel;
                return View("Create");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return View("LoginKlant", userModel);

        }

        public ActionResult ChooseLoginOption()
        {
            return View();
        }

        public ActionResult Openfile(string id)
        {
            ViewBag.imgSrc = Singleton.StoreFactory.imageProcessing.ConvertHttpPostfilebaseto64bytearray(id);
            return View("ViewImage");
        }
        public ActionResult Index()
        {
          
            return View(SingletonData.Singleton.StoreClientRequest.ReturnList());
        }


        // GET: Request/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(ModelBestelling model, HttpPostedFileBase StoredImage)
        {
            try
            {
                           
                model.StoredImage = StoredImage;

                model.ClientLogin = Singleton.StoreKlantLoginData;
                
                Singleton.StoreClientRequest.AddItem(model);
                
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditWerknemer()
        {
            return View(Singleton.StoreWerknemerLoginData);
        }


        [HttpPost]

        public ActionResult Editwerknemer(WerknemerModel werknemerModel)
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

        public ActionResult EditKlant()
        {
            return View(Singleton.StoreKlantLoginData);
        }

        [HttpPost]

        public ActionResult EditKlant(ClientModel clientModel)
        {
            try
            {
                SingletonData.Singleton.StoreKlant.UpdateItem(clientModel);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }

        }


    }
}
