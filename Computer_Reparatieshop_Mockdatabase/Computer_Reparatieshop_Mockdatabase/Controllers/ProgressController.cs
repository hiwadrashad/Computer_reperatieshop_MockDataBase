using Computer_Reparatieshop_Mockdatabase.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class ProgressController : Controller
    {
        // GET: Progress
        public ActionResult Index()
        {
            if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
            {
                SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                SingletonData.Singleton.StoreReparationInProgressInitalized = true;
            }
            return View();
        }

        // GET: Progress/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Progress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Progress/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Progress/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Progress/Edit/5
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

        // GET: Progress/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Progress/Delete/5
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
