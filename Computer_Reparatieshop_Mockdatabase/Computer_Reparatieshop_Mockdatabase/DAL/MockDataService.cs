using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
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
    public class MockDataServiceReparationDone :IDataService<DoneViewModel>
    {
        public readonly List<DoneViewModel> items;

        public MockDataServiceReparationDone()
        {
            items = new List<DoneViewModel>()
            {
            new DoneViewModel { id = Guid.NewGuid().ToString(), basemodel = new ModelReparationDone() { Id = Guid.NewGuid().ToString(), Klant = "John Smith", Omschrijving = "reparatie airbag", PrijsArbeid = 40, PrijsProducten = 300, Reparateur = "Mitch Summers", Totaal = 340 },onderdelen = "Wiel, stuur, uitlaat" }
            };
        }

        public bool AddItem(DoneViewModel item)
        {
            items.Add(item);
            return  (true);
        }

        public  bool UpdateItem(DoneViewModel item)
        {
            var oldItem = items.Where((DoneViewModel arg) => arg.id == item.id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return  (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((DoneViewModel arg) => arg.id == id).FirstOrDefault();
            items.Remove(oldItem);

            return  (true);
        }

        public  DoneViewModel GetItem(string id)
        {
            return  (items.FirstOrDefault(s => s.id == id));
        }

        public List<DoneViewModel> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }

    }

    public class MockDataServiceReparationInProgress : IDataService<ProgressViewModel>
    {
        public readonly List<ProgressViewModel> items;

        public MockDataServiceReparationInProgress()
        {
            items = new List<ProgressViewModel>()
            {
                new ProgressViewModel { id = Guid.NewGuid().ToString(), basemodel = new ModelReparationInProgress() { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25)}, status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}}
            };
        }

        public bool AddItem(ProgressViewModel item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(ProgressViewModel item)
        {
            var oldItem = items.Where((ProgressViewModel arg) => arg.id == item.id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((ProgressViewModel arg) => arg.id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public ProgressViewModel GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.id == id));
        }

        public bool RemoveModelByModel(ProgressViewModel model)
        {
            var item = items.Where(x => x.id == model.id).FirstOrDefault();
            items.Remove(item);
            return (true);
        }

        public ProgressViewModel GetItemByItem(ProgressViewModel model)
        {
           
            return items.FirstOrDefault(s => s.id == model.id);
        }

        public List<ProgressViewModel> ReturnList()
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
        public readonly OverviewViewmodel items;

        public MockDataServiceOverview()
        {
            items = new OverviewViewmodel()
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
        public readonly List<LoginModel> items;

        public MockDataserviceLogin()
        {
            items = new List<LoginModel>()
            {
                new LoginModel { Id = Guid.NewGuid().ToString(), username = "username", password = "password"}
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

        public bool UpdateErrorMessage(LoginModel item)
        {
            var oldItem = items.Where((LoginModel arg) => arg.Id == item.Id).FirstOrDefault();
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

    public class MockDataServiceClientRequest : IDataService<RequestViewModel>
    {
        public readonly List<RequestViewModel> items;

        public MockDataServiceClientRequest()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "KoplampImage.jpg");
            items = new List<RequestViewModel>()
            {
                new RequestViewModel { Id = Guid.NewGuid().ToString(), basemodel = new ModelClientRequest() { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk" }, StoredImage =(HttpPostedFileBase) new MemoryPostedFile(File.ReadAllBytes(@"C:\Users\itv-admin\source\repos\Computer_reperatieshop_MockDataBase\Computer_Reparatieshop_Mockdatabase\Computer_Reparatieshop_Mockdatabase\Images\KoplampImage.jpg"))  }
            };
        }

        public bool AddItem(RequestViewModel item)
        {
            items.Add(item);
            return (true);
        }

        public bool UpdateItem(RequestViewModel item)
        {
            var oldItem = items.Where((RequestViewModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return (true);
        }

        public bool DeleteItem(string id)
        {
            var oldItem = items.Where((RequestViewModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return (true);
        }

        public RequestViewModel GetItem(string id)
        {
            return (items.FirstOrDefault(s => s.Id == id));
        }

        public List<RequestViewModel> ReturnList()
        {
            return items;
        }

        public int CountItemsList()
        {
            return items.Count();
        }
    }
}