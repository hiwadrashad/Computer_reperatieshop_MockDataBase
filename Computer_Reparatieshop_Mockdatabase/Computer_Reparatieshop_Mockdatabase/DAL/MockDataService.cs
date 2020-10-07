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
    public class MockDataServiceReparationDone :IDataService<ModelReparatie>
    {
        public readonly List<ModelReparatie> items;

        public MockDataServiceReparationDone()
        {
            items = new List<ModelReparatie>()
            {
            new ModelReparatie { Id = Guid.NewGuid().ToString(), EindDatum = new DateTime(2020,12,25), Klant = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 1, GebruikersNaam = "TheHedge", Naam = "Jan Piet", Plaats = "Utrecht", PostCode = "3445XA", Straatnaam ="Overvechtsestraat", telefoonnummer = "06-37551762", Wachtwoord="Vos789"  }, Omschrijving = "Koplamp is stuk", onderdelen = new PartModel { id = Guid.NewGuid().ToString(), Name = "Caborateur", numberofpartsavailable = 12, qualityofpart = "Moderate" } }
            };
        }

        public bool AddItem(ModelReparatie item)
        {
            items.Add(item);
            return  (true);
        }

        public  bool UpdateItem(ModelReparatie item)
        {
            var oldItem = items.Where((ModelReparatie arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return  (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((ModelReparatie arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return  (true);
        }

        public  ModelReparatie GetItem(string id)
        {
            return  (items.FirstOrDefault(s => s.Id == id));
        }

        public List<ModelReparatie> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }

    }

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

        public bool UpdateErrorMessage(WerknemerModel item)
        {
            var oldItem = items.Where((WerknemerModel arg) => arg.Id == item.Id).FirstOrDefault();
            oldItem.LoginErrorMessage = "Wrong Username or Password";
            return true;
        }

    }

    public class MockDataServiceReparationInProgress : IDataService<ModelReparatie>
    {
        public readonly List<ModelReparatie> items;

        public MockDataServiceReparationInProgress()
        {
            items = new List<ModelReparatie>()
            {
                new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}}
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

        public int CountInBehandeling()
        {
            return items.Where(x => x.status == new System.Web.Mvc.SelectListItem { Text = "in afwachting", Value = "in afwachting" }).Count();
        }

        public int CountWachtenOpOnderdelen()
        {
            return items.Where(x => x.status == new SelectListItem { Text = "wachten op onderdelen", Value = "wachten op onderdelen" }).Count();
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
                aantaalklaar = SingletonData.Singleton.StoreReparationDone.CountItemsList(),
                aantalinafwachting = SingletonData.Singleton.StoreClientRequest.CountItemsList(),
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
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk" , StoredImage =(HttpPostedFileBase) new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg")))  }
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
}