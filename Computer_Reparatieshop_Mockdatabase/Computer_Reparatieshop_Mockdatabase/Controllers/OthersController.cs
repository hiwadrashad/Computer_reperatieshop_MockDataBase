using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class OthersController : Controller
    {
        // GET: Others
        public ActionResult ViewImage(string id)
        {
            ViewImageViewModel viewImageViewModel = new ViewImageViewModel();
            viewImageViewModel.StoreString64ByteArrayFromImage = Singleton.StoreFactory.imageProcessing.ConvertHttpPostfilebaseto64bytearray(id);
            //    ViewBag.imgSrc = Singleton.StoreFactory.imageProcessing.ConvertHttpPostfilebaseto64bytearray(id);
            return View(viewImageViewModel);
        }

        public ActionResult Print(string id)
        {

            Singleton.StoreFactory.print.ExecutePrinting(id);


            return RedirectToAction("OpdrachtenOverview", "Opdracht");
        }
    }
}