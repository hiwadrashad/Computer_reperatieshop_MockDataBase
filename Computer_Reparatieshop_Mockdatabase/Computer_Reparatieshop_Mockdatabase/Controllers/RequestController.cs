using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult Index(int i =0)
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
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
             
                // TODO: Add insert logic here

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
