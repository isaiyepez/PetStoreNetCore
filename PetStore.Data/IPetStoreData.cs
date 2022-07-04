using System;
using System.Collections.Generic;
using System.Text;
using PetStoreNetCore.Core;
using System.Linq;

namespace PetStore.Data
{
    public interface IPetStoreData
    {
        IEnumerable<Store> GetPetStores();
    }

    public class InMemoryPetStoreData : IPetStoreData
    {
        readonly List<Store> _stores;
        public InMemoryPetStoreData()
        {
            _stores = new List<Store>()
            { new Store { Id = 1, StoreName = "La Gatita Elegante, Sucursal Norte", StreetName = "Duraznos #321", City = "Aguascalientes", PostalCode = 20124, Country = "México", CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 2, StoreName = "D'Artacán, Todo para tu perro", StreetName = "Encinos #5521", City = "Aguascalientes", PostalCode = 20124, Country = "México", CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 3, StoreName = "El Tlacuache", StreetName = "Blvd. Lázaro Cárdenas #221", City = "San Luís Potosí", PostalCode = 45508, Country = "México", CreatedBy = 1, DateCreated = DateTime.Now},
              new Store { Id = 4, StoreName = "Mi Michi, Cat Boutique", StreetName = "Av. Independencia # 2001", City = "CDMX", PostalCode = 20124, Country = "México", CreatedBy = 1, DateCreated = DateTime.Now}
            };
        }

        public IEnumerable<Store> GetPetStores()
        {
            return from petStore in _stores
                   orderby petStore.StoreName
                select petStore;
        }
    }
}
