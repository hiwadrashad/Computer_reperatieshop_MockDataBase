using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{

    public class MockDataService2 : IDataService
    {
        private List<PartModel> _parts;
        private List<ModelBestelling> _bestellingen;
        private List<ClientModel> _klanten;
        private List<ModelReparatie> _reparaties;
        private List<WerknemerModel> _werknemers;
        private List<AdminModel> _admin;

        private static MockDataService2 _mockDataService2;

        private MockDataService2()
        {
            
        }

        public static MockDataService2 GetMockDataService2()
        {
            if (_mockDataService2 == null)
            {
                _mockDataService2 = new MockDataService2();
                _mockDataService2.InitData();
            }
            return _mockDataService2;
        }

        private void InitData()
        {
            _admin = new List<AdminModel>()
            {
                new AdminModel { Id = Guid.NewGuid().ToString(), username = "username", password = "password"}
            };

            _parts = new List<PartModel>
            {
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat1", numberofpartsavailable = 12, qualityofpart = "Good"},
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat2", numberofpartsavailable = 12, qualityofpart = "Good"},
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat3", numberofpartsavailable = 12, qualityofpart = "Good" },
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat4", numberofpartsavailable = 12, qualityofpart = "Good" },
                new PartModel { id = Guid.NewGuid().ToString(), Name = "Uitlaat5", numberofpartsavailable = 12, qualityofpart = "Good" },
            };

            _bestellingen = new List<ModelBestelling>
            {
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk", StoredImage = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12, 12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie = "N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" }},
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk", StoredImage = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12, 12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie = "N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" } },
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk", StoredImage = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12, 12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie = "N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" } },
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk", StoredImage = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12, 12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie = "N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" } },
                new ModelBestelling { Id = Guid.NewGuid().ToString(), omschrijving = "Koplamp is stuk", StoredImage = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Datum = new DateTime(2020, 12, 12), ophalen = OphalenJaNee.ophalen.ja, extrainformatie = "N.V.T", ClientLogin = new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 8, GebruikersNaam = "Lofilover", Naam = "Anna Li", Plaats = "Canada", PostCode = "3435KL", Straatnaam = "Westonroad", telefoonnummer = "08-2366723", Wachtwoord = "dogsarepets" } },
            };

            _klanten = new List<ClientModel>
            {
                new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano1", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010"},
                new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano2", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010"},
                new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano3", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010" },
                new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano4", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010" },
                new ClientModel { Id = Guid.NewGuid().ToString(), AdressNummer = 9, GebruikersNaam = "Evano5", Naam = "Becky Lin", Plaats = "Nieuwegein", PostCode = "4556XL", Straatnaam = "Verwerfstraat", telefoonnummer = "06-56776788", Wachtwoord = "Baby1010" }
            };

            _werknemers = new List<WerknemerModel>()
            {
                new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats1", AdressNummer = 9, Image = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password ="MijnWachtwoord", Plaats="Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845"   },
                new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats2", AdressNummer = 9, Image = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password ="MijnWachtwoord", Plaats="Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845"   },
                new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats3", AdressNummer = 9, Image = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password = "MijnWachtwoord", Plaats = "Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845" },
                new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats4", AdressNummer = 9, Image = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password = "MijnWachtwoord", Plaats = "Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845" },
                new WerknemerModel { Id = Guid.NewGuid().ToString(), username = "iLikeCats5", AdressNummer = 9, Image = new MemoryPostedFile(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~/Images/Koplampimage.jpg"))), Naam = "Pim Van  Horst", password = "MijnWachtwoord", Plaats = "Amsterdam", PostCode = "3545CL", rol = RolesWerknemer.Roles.hoofdreperateur, Straatnaam = "Vorststraat", telefoonnummer = "06-366576845" }
            };

            _reparaties = new List<ModelReparatie>()
            {
                new ModelReparatie
                {
                    Id = Guid.NewGuid().ToString(),
                    StartDatum = new DateTime(2020,9,25),
                    EindDatum = new DateTime(2020,12,25),
                    status = "in afwachting",
                    PrijsArbeid = 150,
                    PrijsProducten = 1200,
                    Totaal = 1350,
                    Omschrijving = "Collide lekt",
                    onderdelen = new PartModel
                    {
                     id = Guid.NewGuid().ToString(),
                     Name = "Collide",
                     numberofpartsavailable = 9,
                     qualityofpart = "good"
                    },
                    Klant = _klanten.FirstOrDefault(k => k.GebruikersNaam == "Evano1"),
                    Reparateur = _werknemers.FirstOrDefault(w => w.username == "iLikeCats1")
                }
                   //     new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}, PrijsArbeid = 150, PrijsProducten = 1200, Totaal = 1350, Omschrijving = "Collide lekt", onderdelen = new PartModel  { id = Guid.NewGuid().ToString(), Name ="Collide", numberofpartsavailable = 12, qualityofpart = "Medium" } , Klant = new ClientModel {  Id = Guid.NewGuid().ToString(), AdressNummer = 56, GebruikersNaam = "fox132", Naam = "Donatello", Plaats = "Amersfoort", PostCode = "5645KM", Straatnaam = "Amsterdamseestraatweg", telefoonnummer = "06-3656456", Wachtwoord ="kangaroo6897" }, Reparateur = new WerknemerModel { Id = Guid.NewGuid().ToString(), AdressNummer = 76, Naam = "antilope345", password ="turtle3234", Plaats = "Groningen", PostCode = "5657PG", Straatnaam = "Bernhoflaan", telefoonnummer = "030-26672672", username = "Moose123", rol = RolesWerknemer.Roles.coördinator } },
                   //         new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}, PrijsArbeid = 150, PrijsProducten = 1200, Totaal = 1350, Omschrijving = "Collide lekt", onderdelen = new PartModel  { id = Guid.NewGuid().ToString(), Name ="Collide", numberofpartsavailable = 12, qualityofpart = "Medium" } , Klant = new ClientModel {  Id = Guid.NewGuid().ToString(), AdressNummer = 56, GebruikersNaam = "fox132", Naam = "Donatello", Plaats = "Amersfoort", PostCode = "5645KM", Straatnaam = "Amsterdamseestraatweg", telefoonnummer = "06-3656456", Wachtwoord ="kangaroo6897" }, Reparateur = new WerknemerModel { Id = Guid.NewGuid().ToString(), AdressNummer = 76, Naam = "antilope345", password ="turtle3234", Plaats = "Groningen", PostCode = "5657PG", Straatnaam = "Bernhoflaan", telefoonnummer = "030-26672672", username = "Moose123", rol = RolesWerknemer.Roles.coördinator } },
                   //             new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}, PrijsArbeid = 150, PrijsProducten = 1200, Totaal = 1350, Omschrijving = "Collide lekt", onderdelen = new PartModel  { id = Guid.NewGuid().ToString(), Name ="Collide", numberofpartsavailable = 12, qualityofpart = "Medium" } , Klant = new ClientModel {  Id = Guid.NewGuid().ToString(), AdressNummer = 56, GebruikersNaam = "fox132", Naam = "Donatello", Plaats = "Amersfoort", PostCode = "5645KM", Straatnaam = "Amsterdamseestraatweg", telefoonnummer = "06-3656456", Wachtwoord ="kangaroo6897" }, Reparateur = new WerknemerModel { Id = Guid.NewGuid().ToString(), AdressNummer = 76, Naam = "antilope345", password ="turtle3234", Plaats = "Groningen", PostCode = "5657PG", Straatnaam = "Bernhoflaan", telefoonnummer = "030-26672672", username = "Moose123", rol = RolesWerknemer.Roles.coördinator } },
                   //  new ModelReparatie { Id = Guid.NewGuid().ToString(), StartDatum = new DateTime(2020,9,25),EindDatum = new DateTime(2020,12,25), status = new SelectListItem { Text ="in afwachting", Value ="in afwachting"}, PrijsArbeid = 150, PrijsProducten = 1200, Totaal = 1350, Omschrijving = "Collide lekt", onderdelen = new PartModel  { id = Guid.NewGuid().ToString(), Name ="Collide", numberofpartsavailable = 12, qualityofpart = "Medium" } , Klant = new ClientModel {  Id = Guid.NewGuid().ToString(), AdressNummer = 56, GebruikersNaam = "fox132", Naam = "Donatello", Plaats = "Amersfoort", PostCode = "5645KM", Straatnaam = "Amsterdamseestraatweg", telefoonnummer = "06-3656456", Wachtwoord ="kangaroo6897" }, Reparateur = new WerknemerModel { Id = Guid.NewGuid().ToString(), AdressNummer = 76, Naam = "antilope345", password ="turtle3234", Plaats = "Groningen", PostCode = "5657PG", Straatnaam = "Bernhoflaan", telefoonnummer = "030-26672672", username = "Moose123", rol = RolesWerknemer.Roles.coördinator } }
            };
        }

        public bool AddBestelling(ModelBestelling bestelling)
        {
            _bestellingen.Add(bestelling);
            return true;
        }

        public bool AddKlant(ClientModel klant)
        {
            _klanten.Add(klant);
            return true;
        }

        public bool AddOnderdeel(PartModel onderdeel)
        {
            _parts.Add(onderdeel);
            return true;
        }

        public bool AddReparatie(ModelReparatie reparatie)
        {
            _reparaties.Add(reparatie);
            return true;
        }

        public bool AddWerknemer(WerknemerModel werknemer)
        {
            _werknemers.Add(werknemer);
            return true;
        }

        public bool DeleteBestelling(string id)
        {
            ModelBestelling bestelling = _bestellingen.FirstOrDefault(b => b.Id == id);
            _bestellingen.Remove(bestelling);
            return true;
        }

        public bool DeleteKlant(string id)
        {
            ClientModel klant = _klanten.FirstOrDefault(k => k.Id == id);
            _klanten.Remove(klant);
            return true;
        }

        public bool DeleteOnderdeel(string id)
        {
            PartModel onderdeel = _parts.FirstOrDefault(p => p.id == id);
            _parts.Remove(onderdeel);
            return true;
        }

        public bool DeleteReparatie(string id)
        {
            ModelReparatie reparatie = _reparaties.FirstOrDefault(r => r.Id == id);
            _reparaties.Remove(reparatie);
            return true;
        }

        public bool DeleteWerknemer(string id)
        {
            WerknemerModel werknemer = _werknemers.FirstOrDefault(w => w.Id == id);
            _werknemers.Remove(werknemer);
            return true;
        }

        public IEnumerable<ModelBestelling> GetAllBestellingen()
        {
            return _bestellingen;
        }

        public IEnumerable<ClientModel> GetAllKlanten()
        {
            return _klanten;
        }

        public IEnumerable<PartModel> GetAllOnderdeel()
        {
            return _parts;
        }

        public IEnumerable<ModelReparatie> GetAllReparaties()
        {
            return _reparaties;
        }

        public IEnumerable<WerknemerModel> GetAllWerknemers()
        {
            return _werknemers;
        }

        public ModelBestelling GetBestelling(string id)
        {
            return _bestellingen.FirstOrDefault(b => b.Id == id);
        }

        public ClientModel GetKlant(string id)
        {
            return _klanten.FirstOrDefault(k => k.Id == id);
        }

        public PartModel GetOnderdeel(string id)
        {
            return _parts.FirstOrDefault(p => p.id == id);
        }

        public ModelReparatie GetReparatie(string id)
        {
            return _reparaties.FirstOrDefault(r => r.Id == id);
        }

        public WerknemerModel GetWerknemer(string id)
        {
            return _werknemers.FirstOrDefault(w => w.Id == id);
        }

        public bool UpdateBestelling(ModelBestelling bestelling)
        {
            ModelBestelling updateBestelling = _bestellingen.FirstOrDefault(b => b.Id == bestelling.Id);
            updateBestelling.omschrijving = bestelling.omschrijving;
            updateBestelling.ophalen = bestelling.ophalen;
            updateBestelling.StoredImage = bestelling.StoredImage;
            updateBestelling.ClientLogin = bestelling.ClientLogin;
            updateBestelling.Datum = bestelling.Datum;
            updateBestelling.extrainformatie = bestelling.extrainformatie;
            return true;
        }

        public bool UpdateKlant(ClientModel klant)
        {
           var GetKlantTroughId = _klanten.Where(a => a.Id == klant.Id).FirstOrDefault();
           GetKlantTroughId = klant;
           return true;
        }

        public bool UpdateOnderdeel(PartModel part)
        {
           var GetOnderdeelTroughId = _parts.Where(a => a.id == part.id).FirstOrDefault();
           GetOnderdeelTroughId = part;
           return true;
        }

        public bool UpdateReparatie(ModelReparatie reparatie)
        {
           var GetReparatieTroughId = _reparaties.Where(a => a.Id == reparatie.Id).FirstOrDefault();
           GetReparatieTroughId = reparatie;
           return true;
        }

        public bool UpdateWerknemer(WerknemerModel werknemer)
        {
           var GetWerknemerTroughId = _werknemers.Where(a => a.Id == werknemer.Id).FirstOrDefault();
           GetWerknemerTroughId = werknemer;
           return true;
        }

        public int CountKlaar()
        {
            return _reparaties.Where(x => x.status == "klaar").Count();
        }

        public int CountInBehandeling()
        {
            return _reparaties.Where(x => x.status == "in behandeling" ).Count();
        }

        public int CountWachtenOpOnderdelen()
        {
            return _reparaties.Where(x => x.status == "wachten op onderdelen").Count();
        }
        public int CountInAfwachting()
        {
            return _reparaties.Where(x => x.status ==  "in afwachting").Count();
        }

        public bool LoginAdmin(string username, string password)
        {
            if (_admin.Where(s => s.username == username && s.password == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginKlant(string username, string password)
        {
        
            if (_klanten.Where(a => a.GebruikersNaam == username && a.Wachtwoord == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginWerknemer(string username, string password)
        {
        
           if (_werknemers.Where(a => a.Naam == username && a.password == password).FirstOrDefault() != null)
           {
               return true;
           }
           else
           {
               return false; 
           }

        }

        public bool IfGetWerknemerByPasswordAndUsernameAllowed(string username, string password)
        {
            if (_werknemers.Where(a => a.Naam == username && a.password == password).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public WerknemerModel GetWerknemerByPasswordAndUsername(string username, string password)
        {
            return _werknemers.Where(a => a.Naam == username && a.password == password).FirstOrDefault();      
        }



    }


   
}