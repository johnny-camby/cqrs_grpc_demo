using Data.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class XmlImporterDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<FullAddressEntity> FullAddress { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ShipInfoEntity> ShipInfo { get; set; }

        public XmlImporterDbContext(DbContextOptions<XmlImporterDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}