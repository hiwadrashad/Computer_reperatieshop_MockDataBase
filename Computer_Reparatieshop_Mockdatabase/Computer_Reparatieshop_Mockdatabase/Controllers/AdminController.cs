using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class AdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View(SingletonData.Singleton.StoreWerknemer.items.ToList());
        }



        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Models.WerknemerModel werknemerModel)
        {
            try
            {
                // TODO: Add insert logic here
                SingletonData.Singleton.StoreWerknemer.AddItem(werknemerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(string id)
        {
           
            return View(SingletonData.Singleton.StoreWerknemer.GetItem(id));
        }

      
        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Models.WerknemerModel werknemerModel)
        {
            try
            {
                // TODO: Add update logic here
                SingletonData.Singleton.StoreWerknemer.UpdateItem(werknemerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
