using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{


    public class MockDataServiceWerknemer : IDataService<WerknemerModel>
    {
        public readonly List<WerknemerModel> items;

        public MockDataServiceWerknemer()
        {
            items = new List<WerknemerModel>()
            {
            new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats", AdressNummer = 9, Image = (HttpPostedFileBase) new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password ="MijnWachtwoord", Plaats="Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845",    }
            };
        }

        public bool AddItem(WerknemerModel item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(WerknemerModel item)
        {
            var oldItem = items.Where((WerknemerModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((WerknemerModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public WerknemerModel GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.Id == id));
        }

        public List<WerknemerModel> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }

        public bool Login(string username, string password)
        {
            if (items.Where(s => s.username == username && s.password == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public WerknemerModel ReturnModelByNameAndPassword(string username, string password)
        {
            return items.Where(s => s.username == username && s.password == password).FirstOrDefault();
        }
        public bool UpdateErrorMessage(WerknemerModel item)
        {
            var oldItem = items.Where((WerknemerModel arg) => arg.Id == item.Id).FirstOrDefault();
            oldItem.LoginErrorMessage = "Wrong Username or Password";
            return true;
        }

    }

    public class MockDataServiceKlant
    {
        public readonly List<ClientModel> items;

        public MockDataServiceKlant()
        {
            items = new List<ClientModel>
            {
            new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano12", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010"}
            };
        }
        public bool Login(string username, string password)
        {
            if (items.Where(s => s.GebruikersNaam == username && s.Wachtwoord == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateErrorMessage(ClientModel item)
        {
            var oldItem = items.Where((ClientModel arg) => arg.Id == item.Id).FirstOrDefault();
            oldItem.LoginErrorMessage = "Wrong Username or Password";
            return true;
        }

        public bool AddItem(ClientModel item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(ClientModel item)
        {
            var oldItem = items.Where((ClientModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((ClientModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public ClientModel GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.Id == id));
        }

        public bool RemoveModelByModel(ClientModel model)
        {
            var item = items.Where(x => x.Id == model.Id).FirstOrDefault();
            items.Remove(item);
            return (true);
        }

        public ClientModel GetItemByItem(ClientModel model)
        {

            return items.FirstOrDefault(s => s.Id == model.Id);
        }

        public List<ClientModel> ReturnList()
        {
            return items;
        }
    }

    public class MockDataServiceReparationInProgress : IDataService<ModelReparatie>
    {
        public readonly List<ModelReparatie> items;

        public MockDataServiceReparationInProgress()
        {
            items = new List<ModelReparatie>()
            {
                new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}, PrijsArbeid = 150, PrijsProducten = 1200, Totaal = 1350, Omschrijving = "Collide lekt", onderdelen = new PartModel  { id = Guid.NewGuid().ToString(), Name ="Collide", numberofpartsavailable = 12, qualityofpart = "Medium" } , Klant = new ClientModel {  Id = Guid.NewGuid().ToString(), AdressNummer = 56, GebruikersNaam = "fox132", Naam = "Donatello", Plaats = "Amersfoort", PostCode = "5645KM", Straatnaam = "Amsterdamseestraatweg", telefoonnummer = "06-3656456", Wachtwoord ="kangaroo6897" }, Reparateur = new WerknemerModel { Id = Guid.NewGuid().ToString(), AdressNummer = 76, Naam = "antilope345", password ="turtle3234", Plaats = "Groningen", PostCode = "5657PG", Straatnaam = "Bernhoflaan", telefoonnummer = "030-26672672", username = "Moose123", rol = RolesWerknemer.Roles.coördinator } }

            };
        }

        public bool AddItem(ModelReparatie item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(ModelReparatie item)
        {
            var oldItem = items.Where((ModelReparatie arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((ModelReparatie arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public ModelReparatie GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.Id == id));
        }

        public bool RemoveModelByModel(ModelReparatie model)
        {
            var item = items.Where(x => x.Id == model.Id).FirstOrDefault();
            items.Remove(item);
            return (true);
        }

        public ModelReparatie GetItemByItem(ModelReparatie model)
        {

            return items.FirstOrDefault(s => s.Id == model.Id);
        }

        public List<ModelReparatie> ReturnList()
        {
            return items;
        }

        public int CountKlaar()
        {
            return items.Where(x => x.status == new SelectListItem { Text = "klaar", Value = "klaar" }).Count();
        }

        public int CountInBehandeling()
        {
            return items.Where(x => x.status == new System.Web.Mvc.SelectListItem { Text = "in behandeling", Value = "in behandeling" }).Count();
        }

        public int CountWachtenOpOnderdelen()
        {
            return items.Where(x => x.status == new SelectListItem { Text = "wachten op onderdelen", Value = "wachten op onderdelen" }).Count();
        }
        public int CountInAfwachting()
        {
            return items.Where(x => x.status == new SelectListItem { Text = "in afwachting", Value = "in afwachting" }).Count();
        }

    }

    public class MockDataServiceOverview
    {
        public readonly Models.ModelStatus items;

        public MockDataServiceOverview()
        {
            items = new Models.ModelStatus()
            {
                id = Guid.NewGuid().ToString(),
                aantaalklaar = SingletonData.Singleton.StoreReparationInProgress.CountKlaar(),
                aantalinafwachting = SingletonData.Singleton.StoreClientRequest.CountItemsList() + SingletonData.Singleton.StoreReparationInProgress.CountInAfwachting(),
                aantalinbehandeling = SingletonData.Singleton.StoreReparationInProgress.CountInBehandeling(),
                aantalwachtoponderdelen = SingletonData.Singleton.StoreReparationInProgress.CountWachtenOpOnderdelen()
            };
        }
    }

    public class MockDataserviceLogin
    {
        public readonly List<AdminModel> items;

        public MockDataserviceLogin()
        {
            items = new List<AdminModel>()
            {
                new AdminModel { Id = Guid.NewGuid().ToString(), username = "username", password = "password"}
            };
        }

        public bool Login(string username, string password)
        {
            if (items.Where(s => s.username == username && s.password == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateErrorMessage(AdminModel item)
        {
            var oldItem = items.Where((AdminModel arg) => arg.Id == item.Id).FirstOrDefault();
            oldItem.LoginErrorMessage = "Wrong Username or Password";
            return true;
        }
    }


    public class MemoryPostedFile : HttpPostedFileBase
    {
        private readonly byte[] fileBytes;

        public MemoryPostedFile(byte[] fileBytes, string fileName = null)
        {
            this.fileBytes = fileBytes;
            this.FileName = fileName;
            this.InputStream = new MemoryStream(fileBytes);
        }

        public override int ContentLength => fileBytes.Length;

        public override string FileName { get; }

        public override Stream InputStream { get; }
    }

    public class MockDataServiceClientRequest : IDataService<ModelBestelling>
    {
        public readonly List<ModelBestelling> items;

        public MockDataServiceClientRequest()
        {

            items = new List<ModelBestelling>()
            {
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk" , StoredImage =(HttpPostedFileBase) new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12,12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie ="N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString() , AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" }  }
            };
        }

        public bool AddItem(ModelBestelling item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(ModelBestelling item)
        {
            var oldItem = items.Where((ModelBestelling arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((ModelBestelling arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public ModelBestelling GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.Id == id));
        }

        public List<ModelBestelling> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }


    }
    public class MockDataServiceStoreParts : IDataService<PartModel>
    {
        public readonly List<PartModel> items;

        public MockDataServiceStoreParts()
        {

            items = new List<PartModel>()
            {
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat", numberofpartsavailable = 12, qualityofpart = "Good"}
            };
        }

        public bool AddItem(PartModel item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(PartModel item)
        {
            var oldItem = items.Where((PartModel arg) => arg.id == item.id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((PartModel arg) => arg.id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public PartModel GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.id == id));
        }

        public List<PartModel> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }

    }
}