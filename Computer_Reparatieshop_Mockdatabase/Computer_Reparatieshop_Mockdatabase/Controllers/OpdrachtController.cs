using Computer_Reparatieshop_Mockdatabase.DAL;
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
            OpdrachtenOverviewViewModel opdrachtenOverviewViewModel = new OpdrachtenOverviewViewModel();
            opdrachtenOverviewViewModel = Singleton.StoreFactory.overview.CountStatus();
            opdrachtenOverviewViewModel.modelReparatie = Singleton.StoreReparationInProgress.ReturnList() ;
            return View(opdrachtenOverviewViewModel);
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
                progressviewmodel.ModelReparatie.Klant = SingletonData.Singleton.StoreKlant.items.Where(x => x.Naam == progressviewmodel.StoreChoiceKlantFromDropDownList).FirstOrDefault();
                progressviewmodel.ModelReparatie.Reparateur = SingletonData.Singleton.StoreWerknemer.items.Where(x => x.Naam == progressviewmodel.StoreChoiceReperateurFromDropDownList).FirstOrDefault();
                List<PartModel> partModels = new List<PartModel>();
                foreach (var item in progressviewmodel.StoreChoicesOnderdelen)
                {
                    var SingleCoincidedPart = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == item).FirstOrDefault();
                    progressviewmodel.ModelReparatie.onderdelen.Add(SingleCoincidedPart);
                }
                // progressviewmodel.ModelReparatie.onderdelen = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == progressviewmodel.ModelReparatie.StoreChoicesOnderdelen.Value.FirstOrDefault());
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
            ChangeDataOpdrachtViewModel changeDataOpdrachtViewModel = new ChangeDataOpdrachtViewModel();
            changeDataOpdrachtViewModel.GenerateDropDownDataFromClients = new List<SelectListItem>();
            changeDataOpdrachtViewModel.GenerateDropDownDataFromPart = new List<SelectListItem>();
            changeDataOpdrachtViewModel.GenerateDropDownDataFromWerknemer = new List<SelectListItem>();
            foreach (var item in SingletonData.Singleton.StoreParts.items)
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromPart.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

          //  ViewBag.ClientDrop
            foreach (var item in SingletonData.Singleton.StoreKlant.items)
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromClients.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }

            foreach (var item in SingletonData.Singleton.StoreWerknemer.items)
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromWerknemer.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }
            changeDataOpdrachtViewModel.ModelReparatie = Singleton.StoreReparationInProgress.GetItem(id);
           
            return View (changeDataOpdrachtViewModel);
        }

        // POST: Progress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDataOpdracht(ChangeDataOpdrachtViewModel model, int i = 0)
        {
            try
            {
                List<PartModel> partModels = new List<PartModel>();
                foreach (var item in model.StoreChoicesOnderdelen)
                {
                    var SingleCoincidedPart = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == item).FirstOrDefault();
                    model.ModelReparatie.onderdelen.Add(SingleCoincidedPart);
                }
                model.ModelReparatie.Klant = SingletonData.Singleton.StoreKlant.items.Where(x => x.Naam == model.StoreChoiceKlantFromDropDownList).FirstOrDefault();
                model.ModelReparatie.Reparateur = SingletonData.Singleton.StoreWerknemer.items.Where(x => x.Naam == model.StoreChoiceReperateurFromDropDownList).FirstOrDefault();
  
                //  model.onderdelen  = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == model.StoreChoicesOnderdelen.Value).FirstOrDefault();
                SingletonData.Singleton.StoreReparationInProgress.UpdateItem(model.ModelReparatie);
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
