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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autherize(AdminModel userModel)
        {

            var UserDetails = SingletonData.Singleton.StoreLogin.Login(userModel.username, userModel.password);
            var UserDetailsWerknemer = Singleton.StoreWerknemer.Login(userModel.username, userModel.password);
            if (UserDetails == true)
            {
                return RedirectToAction("Adminarea", "Admin");
            }
            else if (UserDetailsWerknemer == true)
            {
                var Werknemer = SingletonData.Singleton.StoreWerknemer.ReturnModelByNameAndPassword(userModel.username, userModel.password);
                SingletonData.Singleton.StoreWerknemerLoginData = Werknemer;
                return RedirectToAction("WerknemerArea", "Werknemer");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return RedirectToAction("Login", "Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AutherizeKlant(ClientModel userModel)
        {
            var UserDetails = SingletonData.Singleton.StoreKlant.Login(userModel.GebruikersNaam, userModel.Wachtwoord);
            if (UserDetails == true)
            {
                SingletonData.Singleton.StoreKlantLoginData = userModel;
                return RedirectToAction("CreateKlantAccount","Klant");
            }
            userModel.LoginErrorMessage = "Wrong username or password";
            return RedirectToAction("LoginKlant", "Login");
        }
    }
}