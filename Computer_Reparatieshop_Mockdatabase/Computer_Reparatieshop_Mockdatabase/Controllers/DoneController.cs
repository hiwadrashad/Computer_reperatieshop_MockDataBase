﻿using Computer_Reparatieshop_Mockdatabase.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class DoneController : Controller
    {
        // GET: Done
        public ActionResult Index()
        {
            if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
            {
                SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                SingletonData.Singleton.StoreReparationDoneInitialized = true;
            }
            return View();
        }

        // GET: Done/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Done/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Done/Create
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

        // GET: Done/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Done/Edit/5
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

        // GET: Done/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Done/Delete/5
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