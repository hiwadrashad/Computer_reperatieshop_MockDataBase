using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
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
        public ActionResult OpdrachtenOverview()
        {
            ViewBag.Bar = Singleton.StoreFactory.overview.CountStatus();
            return View(SingletonData.Singleton.StoreReparationInProgress.ReturnList());
        }



        // GET: Progress/Create
        public ActionResult AddNewopdracht()
        {
            return View();
        }

        // POST: Progress/Create
        [HttpPost]
        public ActionResult AddNewopdracht(Models.ModelReparatie progressviewmodel)
        {
            try
            {
                
                SingletonData.Singleton.StoreReparationInProgress.AddItem(progressviewmodel);
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

            MultiSelectList selectListItems = new MultiSelectList(GenerateDropDownDataFromPart, "", "");

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
        public ActionResult ChangeDataOpdracht(Models.ModelReparatie model, int i = 0)
        {
            try
            {
                // TODO: Add update logic here
                model.Klant = SingletonData.Singleton.StoreKlant.items.Where(x => x.Naam == model.StoreChoiceKlantFromDropDownList.Value).FirstOrDefault();
                model.Reparateur = SingletonData.Singleton.StoreWerknemer.items.Where(x => x.Naam == model.StoreChoiceReperateurFromDropDownList.Value).FirstOrDefault();
                SingletonData.Singleton.StoreReparationInProgress.UpdateItem(model);
                return RedirectToAction("OpdrachtenOverview");
            }
            catch
            {
                return View();
            }
        }


        // GET: Progress/Delete/5
        public ActionResult DeleteOpdracht(Models.ModelReparatie model)
        {
            
            return View(SingletonData.Singleton.StoreReparationInProgress.GetItemByItem(model));
        }

        // POST: Progress/Delete/5
        [HttpPost]
        public ActionResult DeleteOpdracht(Models.ModelReparatie model, int i = 0)
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
