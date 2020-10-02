using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Adminarea()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (SingletonData.Singleton.StoreLoginInitialized == false)
            {
                SingletonData.Singleton.StoreLogin = new MockDataserviceLogin();
                SingletonData.Singleton.StoreLoginInitialized = true;
            }
            return View();

        }

        [HttpPost]
        public ActionResult Autherize(LoginModel userModel)
        {
            if (SingletonData.Singleton.StoreLoginInitialized == false)
            {
                SingletonData.Singleton.StoreLogin = new MockDataserviceLogin();
                SingletonData.Singleton.StoreLoginInitialized = true;
            }
            var UserDetails = SingletonData.Singleton.StoreLogin.Login(userModel.username, userModel.password);
            if (UserDetails == false)
            {
                userModel.LoginErrorMessage = "Wrong username or password";
                return View("Login", userModel);
            }
            return View("Adminarea");
        }

        public ActionResult ChooseLoginOption()
        {
            return View();
        }

        public ActionResult Openfile(string id)
        {
            var model = Singleton.StoreClientRequest.GetItem(id);
            MemoryStream target = new MemoryStream();
            model.StoredImage.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            var base64 = Convert.ToBase64String(data);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            ViewBag.imgSrc = imgSrc;
            return View("ViewImage");
        }
        public ActionResult Index()
        {
            if (SingletonData.Singleton.StoreclienRequestInitalized == false)
            {
                SingletonData.Singleton.StoreClientRequest = new MockDataServiceClientRequest();
                SingletonData.Singleton.StoreclienRequestInitalized = true;
            }
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
            if (SingletonData.Singleton.StoreclienRequestInitalized == false)
            {
                SingletonData.Singleton.StoreClientRequest = new MockDataServiceClientRequest();
                SingletonData.Singleton.StoreclienRequestInitalized = true;
            }
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(RequestViewModel model, HttpPostedFileBase StoredImage)
        {
            try
            {
                if (SingletonData.Singleton.StoreclienRequestInitalized == false)
                {
                    SingletonData.Singleton.StoreClientRequest = new MockDataServiceClientRequest();
                    SingletonData.Singleton.StoreclienRequestInitalized = true;
                }
                

          
                    model.StoredImage = StoredImage;
                

                Singleton.StoreClientRequest.AddItem(model);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

  
    }
}
