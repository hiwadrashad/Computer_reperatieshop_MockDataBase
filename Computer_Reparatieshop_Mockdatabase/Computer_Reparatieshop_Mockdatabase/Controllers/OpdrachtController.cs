﻿using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using System.Web.WebSockets;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class OpdrachtController : Controller
    {
        // GET: Progress
        public ActionResult OnderdelenGegevens(string id)
        {
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItem(id).onderdelen);
        }

        public ActionResult RepereateurGegevens(string id)
        {
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItem(id).Reparateur);
        }

        public ActionResult ClientGegevens(string id)
        {
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItem(id).Klant);
        }
        public ActionResult OpdrachtenOverview()
        {
            //ModelopdrachtViewModel
            ViewBag.Bar = Singleton.StoreFactory.overview.CountStatus();
            return View(SingletonData.Singleton.StoreReparationInProgress.ReturnList());
        }



        // GET: Progress/Create
        public ActionResult AddNewopdracht()
        {
            AddNewOpdrachtViewModel addNewOpdrachtViewModel = new AddNewOpdrachtViewModel();
            addNewOpdrachtViewModel.GenerateDropDownDataFromPart = new List<SelectListItem>();
            addNewOpdrachtViewModel.GenerateDropDownDataFromClients = new List<SelectListItem>();
            addNewOpdrachtViewModel.GenerateDropDownDataFromWerknemer = new List<SelectListItem>();

            foreach (var item in SingletonData.Singleton.StoreParts.items)
            {
                addNewOpdrachtViewModel.GenerateDropDownDataFromPart.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            //  ViewBag.ClientDrop

            foreach (var item in SingletonData.Singleton.StoreKlant.items)
            {
                addNewOpdrachtViewModel.GenerateDropDownDataFromClients.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }

            foreach (var item in SingletonData.Singleton.StoreWerknemer.items)
            {
                addNewOpdrachtViewModel.GenerateDropDownDataFromWerknemer.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }

            return View(addNewOpdrachtViewModel);
        }

        // POST: Progress/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewopdracht(AddNewOpdrachtViewModel progressviewmodel)
        {
            try
            {
                progressviewmodel.ModelReparatie.Klant = SingletonData.Singleton.StoreKlant.items.Where(x => x.Naam == progressviewmodel.ModelReparatie.StoreChoiceKlantFromDropDownList.Value).FirstOrDefault();
                progressviewmodel.ModelReparatie.Reparateur = SingletonData.Singleton.StoreWerknemer.items.Where(x => x.Naam == progressviewmodel.ModelReparatie.StoreChoiceReperateurFromDropDownList.Value).FirstOrDefault();
                progressviewmodel.ModelReparatie.onderdelen = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == progressviewmodel.ModelReparatie.StoreChoicesOnderdelen.Value).FirstOrDefault();
                SingletonData.Singleton.StoreReparationInProgress.AddItem(progressviewmodel.ModelReparatie);
                // TODO: Add insert logic here
                return RedirectToAction("OpdrachtenOverview");
            }
            catch
            {
                return View();
            }
        }

        // GET: Progress/Edit/5
        public ActionResult ChangeDataOpdracht(string id)
        {
            List<SelectListItem> GenerateDropDownDataFromPart = new List<SelectListItem>();
            foreach (var item in SingletonData.Singleton.StoreParts.items)
            {
                GenerateDropDownDataFromPart.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            ViewBag.OnderdelenDropDownList = GenerateDropDownDataFromPart;

          //  ViewBag.ClientDrop
         
            List<SelectListItem> GenerateDropdDownDataFromClients = new List<SelectListItem>();
            foreach (var item in SingletonData.Singleton.StoreKlant.items)
            {
                GenerateDropdDownDataFromClients.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }
            ViewBag.ClientDropDownlist = GenerateDropdDownDataFromClients;

            List<SelectListItem> GenerateDropDownDataFromWerknemer = new List<SelectListItem>();
            foreach (var item in SingletonData.Singleton.StoreWerknemer.items)
            {
                GenerateDropDownDataFromWerknemer.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }
            ViewBag.WerknemerDropDownList = GenerateDropDownDataFromWerknemer;

           
            return View (Singleton.StoreReparationInProgress.GetItem(id));
        }

        // POST: Progress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDataOpdracht(Models.ModelReparatie model, int i = 0)
        {
            try
            {
                // TODO: Add update logic here
                model.Klant = SingletonData.Singleton.StoreKlant.items.Where(x => x.Naam == model.StoreChoiceKlantFromDropDownList.Value).FirstOrDefault();
                model.Reparateur = SingletonData.Singleton.StoreWerknemer.items.Where(x => x.Naam == model.StoreChoiceReperateurFromDropDownList.Value).FirstOrDefault();
              //  model.onderdelen  = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == model.StoreChoicesOnderdelen.Value).FirstOrDefault();
                SingletonData.Singleton.StoreReparationInProgress.UpdateItem(model);
                return RedirectToAction("OpdrachtenOverview");
            }
            catch
            {
                return View();
            }
        }


        // GET: Progress/Delete/5
        public ActionResult DeleteOpdracht(string id)
        {
            
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItem(id));
        }

        // POST: Progress/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOpdracht(Models.ModelReparatie model)
        {
            try
            {
               
                var item = SingletonData.Singleton.StoreReparationInProgress.RemoveModelByModel(model);
                // TODO: Add delete logic here

                return RedirectToAction("OpdrachtenOverview");
            }
            catch
            {
                return View();
            }
        }
    }
}
