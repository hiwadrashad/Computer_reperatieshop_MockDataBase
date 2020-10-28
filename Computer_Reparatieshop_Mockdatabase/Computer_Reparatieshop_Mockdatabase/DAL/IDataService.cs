using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{
    public interface IDataService
    {
        WerknemerModel GetWerknemer(string id);
        bool AddWerknemer(WerknemerModel werknemer);
        bool UpdateWerknemer(WerknemerModel werknemer);
        bool DeleteWerknemer(string id);
        bool LoginWerknemer(string username, string password);
        IEnumerable<WerknemerModel> GetAllWerknemers();

        ClientModel GetKlant(string id);
        bool AddKlant(ClientModel klant);
        bool UpdateKlant(ClientModel klant);
        bool DeleteKlant(string id);
        bool LoginKlant(string username, string password);
        IEnumerable<ClientModel> GetAllKlanten();

        ModelReparatie GetReparatie(string id);
        bool AddReparatie(ModelReparatie klant);
        bool UpdateReparatie(ModelReparatie klant);
        bool DeleteReparatie(string id);
        IEnumerable<ModelReparatie> GetAllReparaties();

        ModelBestelling GetBestelling(string id);
        bool AddBestelling(ModelBestelling klant);
        bool UpdateBestelling(ModelBestelling klant);
        bool DeleteBestelling(string id);
        IEnumerable<ModelBestelling> GetAllBestellingen();

        PartModel GetOnderdeel(string id);
        bool AddOnderdeel(PartModel klant);
        bool UpdateOnderdeel(PartModel klant);
        bool DeleteOnderdeel(string id);
        IEnumerable<PartModel> GetAllOnderdeel();

        bool LoginAdmin(string username, string password);

        int CountKlaar();
        int CountInBehandeling();
        int CountWachtenOpOnderdelen();
        int CountInAfwachting();

    }
}
