﻿using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
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

            return View(SingletonData.Singleton.StoreReparationInProgress.ReturnList());
        }



        // GET: Progress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Progress/Create
        [HttpPost]
        public ActionResult Create(ProgressViewModel progressviewmodel)
        {
            try
            {
                if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
                {
                    SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                    SingletonData.Singleton.StoreReparationInProgressInitalized = true;
                }
                SingletonData.Singleton.StoreReparationInProgress.AddItem(progressviewmodel);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Progress/Edit/5
        public ActionResult Edit(ProgressViewModel model)
        {
            if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
            {
                SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                SingletonData.Singleton.StoreReparationInProgressInitalized = true;
            }
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItemByItem(model));
        }

        // POST: Progress/Edit/5
        [HttpPost]
        public ActionResult Edit(ProgressViewModel model, int i = 0)
        {
            try
            {
                // TODO: Add update logic here
                if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
                {
                    SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                    SingletonData.Singleton.StoreReparationInProgressInitalized = true;
                }
                SingletonData.Singleton.StoreReparationInProgress.UpdateItem(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Progress/Delete/5
        public ActionResult Delete(ProgressViewModel model)
        {
            if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
            {
                SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                SingletonData.Singleton.StoreReparationInProgressInitalized = true;
            }
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItemByItem(model));
        }

        // POST: Progress/Delete/5
        [HttpPost]
        public ActionResult Delete(ProgressViewModel model, int i = 0)
        {
            try
            {
                if (SingletonData.Singleton.StoreReparationInProgressInitalized == false)
                {
                    SingletonData.Singleton.StoreReparationInProgress = new MockDataServiceReparationInProgress();
                    SingletonData.Singleton.StoreReparationInProgressInitalized = true;
                }
                var item = SingletonData.Singleton.StoreReparationInProgress.RemoveModelByModel(model);
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
