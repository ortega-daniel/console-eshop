using DataInterface.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataInterface
{
    public class EshopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public EshopContext(DbContextOptions<EshopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
