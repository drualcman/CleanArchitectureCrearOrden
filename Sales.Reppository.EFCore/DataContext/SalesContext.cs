using Microsoft.EntityFrameworkCore;
using Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Reppository.EFCore.DataContext
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<SaleOrder> Orders { get; set; }
        public DbSet<SaleDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(p => p.Id).HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<SaleOrder>().Property(p => p.CustomerId).IsRequired().HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<SaleOrder>().Property(p => p.ShipAddress).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<SaleOrder>().Property(p => p.ShipCity).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<SaleOrder>().Property(p => p.ShipCountry).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<SaleOrder>().Property(p => p.ShipPostalcode).HasMaxLength(10);
            modelBuilder.Entity<SaleDetail>().HasKey(sd => new { sd.OrderId, sd.ProdcutId });

            modelBuilder.Entity<SaleOrder>().HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<SaleDetail>().HasOne<Product>().WithMany().HasForeignKey(d => d.ProdcutId);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chai" },
                new Product { Id = 2, Name = "Chang" },
                new Product { Id = 3, Name = "Anissed Syrup" },
                new Product { Id = 4, Name = "Chef Anton's" });
            modelBuilder.Entity<Customer>().HasData(
                new Customer {  Id = "ALFKI", Name = "Alfred F."},
                new Customer {  Id = "ANATR", Name = "Ana Trijillo"},
                new Customer {  Id = "ANTON", Name = "Antonio Moreno"});
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
