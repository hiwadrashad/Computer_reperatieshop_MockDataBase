using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModel;
using Microsoft.Ajax.Utilities;
using Org.BouncyCastle.Crypto.Tls;
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
            return View(SingletonData.Singleton.MockDataService2.GetReparatie(id).onderdelen);
        }

        public ActionResult RepereateurGegevens(string id)
        {
            return View(SingletonData.Singleton.MockDataService2.GetReparatie(id).Reparateur);
        }

        public ActionResult ClientGegevens(string id)
        {
            return View(SingletonData.Singleton.MockDataService2.GetReparatie(id).Klant);
        }
        public ActionResult OpdrachtenOverview()
        {
            //ModelopdrachtViewModel
            OpdrachtenOverviewViewModel opdrachtenOverviewViewModel = new OpdrachtenOverviewViewModel();
            opdrachtenOverviewViewModel = Singleton.StoreFactory.overview.CountStatus();
            opdrachtenOverviewViewModel.modelReparatie = Singleton.MockDataService2.GetAllReparaties().ToList() ;
            return View(opdrachtenOverviewViewModel);
        }



        // GET: Progress/Create
        public ActionResult AddNewopdracht()
        {
            AddNewOpdrachtViewModel addNewOpdrachtViewModel = new AddNewOpdrachtViewModel();
            addNewOpdrachtViewModel.GenerateDropDownDataFromPart = new List<SelectListItem>();
            addNewOpdrachtViewModel.GenerateDropDownDataFromClients = new List<SelectListItem>();
            addNewOpdrachtViewModel.GenerateDropDownDataFromWerknemer = new List<SelectListItem>();

            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllOnderdeel())
            {
                addNewOpdrachtViewModel.GenerateDropDownDataFromPart.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            //  ViewBag.ClientDrop

            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllKlanten())
            {
                addNewOpdrachtViewModel.GenerateDropDownDataFromClients.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }

            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllWerknemers())
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
                progressviewmodel.ModelReparatie.Totaal = progressviewmodel.ModelReparatie.PrijsArbeid + progressviewmodel.ModelReparatie.PrijsProducten;
                progressviewmodel.ModelReparatie.Klant = SingletonData.Singleton.MockDataService2.GetAllKlanten().Where(x => x.Naam == progressviewmodel.StoreChoiceKlantFromDropDownList).FirstOrDefault();
                progressviewmodel.ModelReparatie.Reparateur = SingletonData.Singleton.MockDataService2.GetAllWerknemers().Where(x => x.Naam == progressviewmodel.StoreChoiceReperateurFromDropDownList).FirstOrDefault();
                //List<PartModel> partModels = new List<PartModel>();
                //foreach (var item in progressviewmodel.StoreChoicesOnderdelen)
                // {
                //     var SingleCoincidedPart = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == item).FirstOrDefault();
                //     progressviewmodel.ModelReparatie.onderdelen.Add(SingleCoincidedPart);
                // }
                progressviewmodel.ModelReparatie.onderdelen = SingletonData.Singleton.MockDataService2.GetAllOnderdeel().Where(x => x.Name == progressviewmodel.StoreChoicesOnderdelen).FirstOrDefault();
                progressviewmodel.ModelReparatie.onderdelen.numberofpartsavailable = progressviewmodel.ModelReparatie.onderdelen.numberofpartsavailable - 1;
                if (progressviewmodel.ModelReparatie.onderdelen.numberofpartsavailable <= 0)
                {

                  return  Content("<script language='javascript' type='text/javascript'>alert('onderdeel is op!');</script>");
           
                } 
                SingletonData.Singleton.MockDataService2.AddReparatie(progressviewmodel.ModelReparatie);
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
            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllOnderdeel())
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromPart.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

          //  ViewBag.ClientDrop
            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllKlanten())
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromClients.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }

            foreach (var item in SingletonData.Singleton.MockDataService2.GetAllWerknemers())
            {
                changeDataOpdrachtViewModel.GenerateDropDownDataFromWerknemer.Add(new SelectListItem { Text = item.Naam, Value = item.Naam });
            }
            changeDataOpdrachtViewModel.ModelReparatie = Singleton.MockDataService2.GetReparatie(id);
           
            return View (changeDataOpdrachtViewModel);
        }

        // POST: Progress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeDataOpdracht(ChangeDataOpdrachtViewModel model, int i = 0)
        {
            try
            {
                model.ModelReparatie.Totaal = model.ModelReparatie.PrijsArbeid + model.ModelReparatie.PrijsProducten;

                List<PartModel> partModels = new List<PartModel>();
              //  foreach (var item in model.StoreChoicesOnderdelen)
              //  {
              //      var SingleCoincidedPart = SingletonData.Singleton.StoreParts.items.Where(x => x.Name == item).FirstOrDefault();
              //      model.ModelReparatie.onderdelen.Add(SingleCoincidedPart);
              //  }
                model.ModelReparatie.Klant = SingletonData.Singleton.MockDataService2.GetAllKlanten().Where(x => x.Naam == model.StoreChoiceKlantFromDropDownList).FirstOrDefault();
                model.ModelReparatie.Reparateur = SingletonData.Singleton.MockDataService2.GetAllWerknemers().Where(x => x.Naam == model.StoreChoiceReperateurFromDropDownList).FirstOrDefault();
  
                model.ModelReparatie.onderdelen  = SingletonData.Singleton.MockDataService2.GetAllOnderdeel().Where(x => x.Name == model.StoreChoicesOnderdelen).FirstOrDefault();
                SingletonData.Singleton.MockDataService2.UpdateReparatie(model.ModelReparatie);
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
            
            return View(SingletonData.Singleton.MockDataService2.GetReparatie(id));
        }

        // POST: Progress/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOpdracht(Models.ModelReparatie model)
        {
            try
            {
               
                var item = SingletonData.Singleton.MockDataService2.DeleteReparatie(model.Id);
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
