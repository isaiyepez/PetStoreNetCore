using PetStoreNetCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Data
{
    public class SqlPetStoreData : IPetStoreData
    {
        private readonly PetStoreDbContext _db;

        public SqlPetStoreData(PetStoreDbContext db)
        {
            _db = db;
        }
        public Store Add(Store newStore)
        {
            _db.Add(newStore);
            return newStore;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Store Delete(int id)
        {
            var store = GetStoreById(id);
            if (store != null)
            {
                _db.Stores.Remove(store);
            }
            return store;
        }

        public IEnumerable<Store> GetPetStores()
        {
            return _db.Stores;
        }

        public Store GetStoreById(int id)
        {
            return _db.Stores.Find(id);
        }

        public IEnumerable<Store> GetStoresByName(string name)
        {
            var query = from store in _db.Stores
                        where store.StoreName.Contains(name, StringComparison.CurrentCultureIgnoreCase)
                        || string.IsNullOrEmpty(name)
                        orderby store.StoreName
                        select store;

            return query;
        }

        public Store Update(Store updatedStore)
        {
            var entity = _db.Stores.Attach(updatedStore);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedStore;
        }
    }

}
