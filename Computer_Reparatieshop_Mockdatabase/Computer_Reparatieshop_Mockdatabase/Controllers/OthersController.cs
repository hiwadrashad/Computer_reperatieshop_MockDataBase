using Computer_Reparatieshop_Mockdatabase.SingletonData;
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
            ViewBag.imgSrc = Singleton.StoreFactory.imageProcessing.ConvertHttpPostfilebaseto64bytearray(id);
            return RedirectToAction("ViewImage", "Others");
        }

        public ActionResult Print(string id)
        {

            Singleton.StoreFactory.print.ExecutePrinting(id);


            return RedirectToAction("OpdrachtenOverview", "Opdracht");
        }
    }
}