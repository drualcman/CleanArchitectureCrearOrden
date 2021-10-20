using CrearOrden.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Repositories.EFCore.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Por no ensuciar las entidades se configuran aqui las entidades
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configurar customer
            modelBuilder.Entity<Customer>().Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            //configurar product
            modelBuilder.Entity<Product>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);
            //configurar order
            modelBuilder.Entity<Order>().Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Order>().Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(o => o.ShipCountry).HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(o => o.ShipPostalCode).HasMaxLength(10);
            //configurar orderdetail
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            //configurar relaciones
            modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>().HasOne<Product>().WithMany().HasForeignKey(o => o.ProductId);

            //datos de prueba
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chai" },
                new Product { Id = 2, Name = "Chang" },
                new Product { Id = 3, Name = "Aniseed Syrup" }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = "ALFKI", Name = "Alfreds. F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );
        }
    }
}
