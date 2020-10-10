using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class StartPageController : Controller
    {
        // GET: StartPage

        public ActionResult ChooseLoginOption()
        {
            return View();
        }
    }
}