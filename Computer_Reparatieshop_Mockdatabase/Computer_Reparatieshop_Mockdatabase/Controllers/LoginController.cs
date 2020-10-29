using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class LoginController : Controller
    {
        // GET: WerknemerEnAdminLogin
        public ActionResult LoginWerknemers()
        {
            return View();
        }

        public ActionResult LoginKlant()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Autherize(AdminModel userModel)
        {

            var UserDetails = SingletonData.Singleton.MockDataService2.LoginAdmin(userModel.username, userModel.password);
            var UserDetailsWerknemer = Singleton.MockDataService2.LoginWerknemer(userModel.username, userModel.password);
            if (UserDetails == true)
            {
                return RedirectToAction("Adminarea", "Admin");
            }
            else if (UserDetailsWerknemer == true)
            {

                var Werknemer = SingletonData.Singleton.MockDataService2.GetWerknemerByPasswordAndUsername(userModel.username, userModel.password);
                SingletonData.Singleton.StoreWerknemerLoginData = Werknemer;
                return RedirectToAction("WerknemerArea", "Werknemer");

            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return RedirectToAction("LoginWerknemers", "Login");
        }

        [HttpPost]
        public ActionResult AutherizeKlant(ClientModel userModel)
        {
            var UserDetails = SingletonData.Singleton.MockDataService2.LoginKlant(userModel.GebruikersNaam, userModel.Wachtwoord);
            if (UserDetails == true)
            {
                SingletonData.Singleton.StoreKlantLoginData = userModel;
                return RedirectToAction("AddNewBestelling","Bestelling");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return RedirectToAction("LoginKlant", "Login");
        }
    }
}