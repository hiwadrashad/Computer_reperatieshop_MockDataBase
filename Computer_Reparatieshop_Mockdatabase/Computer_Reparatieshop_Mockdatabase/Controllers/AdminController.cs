using Computer_Reparatieshop_Mockdatabase.Models;
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
        public ActionResult Adminarea()
        {
            return View();
        }

        public ActionResult WerknemerOverviewOnlyForAdmin()
        {

            return View(SingletonData.Singleton.StoreWerknemer.items.ToList());
        }



        // GET: Login/Create
        public ActionResult AddnewWerknemerOnlyForAdmin()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddnewWerknemerOnlyForAdmin(Models.WerknemerModel werknemerModel)
        {
            try
            {
                // TODO: Add insert logic here
                SingletonData.Singleton.StoreWerknemer.AddItem(werknemerModel);
                return RedirectToAction("WerknemerOverview");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        
        public ActionResult ChangeDataWerknemerOnlyForAdmin(string id)
        {
           
            return View(SingletonData.Singleton.StoreWerknemer.GetItem(id));
        }

      
        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDataWerknemerOnlyForAdmin(string id, Models.WerknemerModel werknemerModel)
        {
            try
            {
                // TODO: Add update logic here
                SingletonData.Singleton.StoreWerknemer.UpdateItem(werknemerModel);
                return RedirectToAction("WerknemerOverview");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult DeleteWerknemerOnlyForAdmin(string id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWerknemerOnlyForAdmin(string id, WerknemerModel werknemerModel)
        {
            try
            {
                // TODO: Add delete logic here
                SingletonData.Singleton.StoreWerknemer.DeleteItem(werknemerModel.Id);

                return RedirectToAction("WerknemerOverview");
            }
            catch
            {
                return View();
            }
        }
    }
}
