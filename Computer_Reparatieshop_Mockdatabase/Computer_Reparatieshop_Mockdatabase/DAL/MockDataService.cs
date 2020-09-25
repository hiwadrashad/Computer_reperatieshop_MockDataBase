using Computer_Reparatieshop_Mockdatabase.Models;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{
    public class MockDataServiceReparationDone :IDataService<DoneViewModel>
    {
        public readonly List<DoneViewModel> items;

        public MockDataServiceReparationDone()
        {
            items = new List<DoneViewModel>()
            {
            new DoneViewModel { id = Guid.NewGuid().ToString(), basemodel = new ModelReparationDone() { Id = Guid.NewGuid().ToString(), Klant = "John Smith", Omschrijving = "reparatie airbag", PrijsArbeid = 40, PrijsProducten = 300, Reparateur = "Mitch Summers", Totaal = 340 },onderdelen = }
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

    }

    public class MockDataServiceReparationInProgress : IDataService<ProgressViewModel>
    {
        public readonly List<ProgressViewModel> items;

        public MockDataServiceReparationInProgress()
        {
            items = new List<ProgressViewModel>()
            {
                new ProgressViewModel { id = Guid.NewGuid().ToString(), basemodel = new ModelReparationInProgress() { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25)}, aantaalklaar = 12, aantalinafwachting = 21, aantalinbehandeling= 9, aantalwachtoponderdelen = 5}
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

        public List<ProgressViewModel> ReturnList()
        {
            return items;
        }

    }

    public class MockDataServiceClientRequest : IDataService<RequestViewModel>
    {
        public readonly List<RequestViewModel> items;

        public MockDataServiceClientRequest()
        {
            items = new List<RequestViewModel>()
            {
                new RequestViewModel { Id = Guid.NewGuid().ToString(), basemodel = new ModelClientRequest() { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk" }, StoredImage =  }
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

    }
}