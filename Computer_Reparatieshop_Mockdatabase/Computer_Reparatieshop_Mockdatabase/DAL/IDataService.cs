using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{
    public interface IDataService<T>
    {
        bool AddItem(T item);
        bool UpdateItem(T item);

        bool DeleteItem(string id);

        T GetItem(string id);

        List<T> ReturnList();


    }
}
