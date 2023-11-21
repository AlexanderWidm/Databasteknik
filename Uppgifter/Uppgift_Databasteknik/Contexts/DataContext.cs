using Microsoft.EntityFrameworkCore;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet <ProductEntity> Products { get; set; }
    public DbSet <ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet <PricingUnitEntity> PricingUnits { get; set; }
    public DbSet <OrderEntity> Orders { get; set; }
    public DbSet <OrderRowEntity> OrderRows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderRowEntity>().HasKey(x => new { x.OrderId, x.ProductId });
    }
}
