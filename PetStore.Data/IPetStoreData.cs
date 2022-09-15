using System.Collections.Generic;
using System.Text;
using PetStoreNetCore.Core;

namespace PetStore.Data
{
    public interface IPetStoreData
    {
        IEnumerable<Store> GetPetStores();

        Store GetStoreById(int id);

        IEnumerable<Store> GetStoresByName(string name);

        Store Add(Store newStore);
        Store Update(Store store);
        Store Delete(int id);
        int GetCountOfStores();
        int Commit();
    }

}
