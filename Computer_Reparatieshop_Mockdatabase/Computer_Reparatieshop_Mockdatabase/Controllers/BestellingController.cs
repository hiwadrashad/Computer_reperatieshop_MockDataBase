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

        public ActionResult Login()
        {
            
            return View();

        }

        [HttpPost]
        public ActionResult Autherize(AdminModel userModel)
        {
           
            var UserDetails = SingletonData.Singleton.StoreLogin.Login(userModel.username, userModel.password);
            var UserDetailsWerknemer = Singleton.StoreWerknemerLogin.Login(userModel.username, userModel.password);
            if (UserDetails == true)
            {
                return View("Adminarea");
            }
            else if (UserDetailsWerknemer == true)
            {
                return View("WerknemerArea");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return View("Login", userModel);

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

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                

                Singleton.StoreClientRequest.AddItem(model);
                

                return RedirectToAction("ChooseLoginOption");
            }
            catch
            {
                return View();
            }
        }

  
    }
}
