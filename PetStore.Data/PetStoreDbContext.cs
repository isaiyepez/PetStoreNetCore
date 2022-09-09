using Microsoft.EntityFrameworkCore;
using PetStoreNetCore.Core;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Store> Stores { get; set; }
    }
}
