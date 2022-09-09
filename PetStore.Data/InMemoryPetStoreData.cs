using System;
using System.Collections.Generic;
using PetStoreNetCore.Core;
using System.Linq;

namespace PetStore.Data
{
    public class InMemoryPetStoreData : IPetStoreData
    {
        readonly List<Store> _stores;
        public InMemoryPetStoreData()
        {
            _stores = new List<Store>()
            { new Store { Id = 1, StoreName = "La Gatita Elegante, Sucursal Norte", StreetName = "Duraznos #321", City = "Aguascalientes", PostalCode = 20124, Country = Store.Countries.Mexico, CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 2, StoreName = "D'Artacán, Todo para tu perro", StreetName = "Encinos #5521", City = "Aguascalientes", PostalCode = 20124, Country = Store.Countries.Brazil, CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 3, StoreName = "El Tlacuache", StreetName = "Blvd. Lázaro Cárdenas #221", City = "San Luís Potosí", PostalCode = 45508, Country = Store.Countries.UnitedStates, CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 4, StoreName = "Mi Michi, Cat Boutique", StreetName = "Av. Independencia # 2001", City = "CDMX", PostalCode = 20124, Country = Store.Countries.Italy, CreatedBy = 1, DateCreated = DateTime.Now}
            };
        }        

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Store> GetPetStores()
        {
            return from petStore in _stores
                   orderby petStore.StoreName
                select petStore;
        }

        public Store GetStoreById(int id)
        {
            return _stores.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Store> GetStoresByName(string name)
        {
            return from petStore in _stores
                   where string.IsNullOrEmpty(name) || petStore.StoreName.Contains(name, StringComparison.CurrentCultureIgnoreCase)
            orderby petStore.StoreName
                   select petStore;
        }

        public Store Add(Store newStore)
        {
            newStore.Id = _stores.Max(x => x.Id) + 1;
            _stores.Add(newStore);
            return newStore;
        }
        public Store Update(Store store)
        {
            var storeUpdated = _stores.SingleOrDefault(x => x.Id == store.Id);
            if (storeUpdated != null)
            {
                storeUpdated.StoreName = store.StoreName;
                storeUpdated.StreetName = store.StreetName;
                storeUpdated.City = store.City;
                storeUpdated.Country = store.Country;

            }

            return storeUpdated;
        }

        public Store Delete(int id)
        {
            var store = _stores.SingleOrDefault(x => x.Id == id);
            if (store != null)
            {
                    _stores.Remove(store);
            }

            return store;
        }
    }
}
