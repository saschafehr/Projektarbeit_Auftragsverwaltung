using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using Projektarbeit_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung
{
    public class OrderContext : DbContext
    {

        
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LENOVOLEGION5\\SWU;Database=Auftragsverwaltung;Trusted_Connection = True;encrypt=false;");

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemGroup>()

                .HasKey(i => i.ItemGroupID);


            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");
      
            });

            #region Beispiel
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 1, Rate = 7.7, Name = "Normalsatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 2, Rate = 3.7, Name = "Sondersatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 3, Rate = 2.5, Name = "Reduziertersatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 4, Rate = 0, Name = "Befreitersatz" });

            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 1, Name = "IT", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 2, Name = "Möbel", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 3, Name = "Laptop", ParentID = 1 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 4, Name = "Tisch", ParentID = 2, });

            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 1, Title = "MacBook Pro", Price = 1300, VATID = 1, ItemGroupID = 1 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 2, Title = "Gaming Stuhl", Price = 100, VATID = 1, ItemGroupID = 2 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 3, Title = "Visual Studio 2022", Price = 11300, VATID = 1, ItemGroupID = 1 });

            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 1, Postcode = 8595, City = "St. Gallen", Street = "Scherzingerstrasse 13" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 2, Postcode = 8500, City = "Frauenfeld", Street = "Bahnhofstrasse 1" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 1, Vorname = "Sandro", Name = "Wuttke", AddressID = 1, Email = "sw@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 2, Vorname = "Säuli", Name = "Sau", AddressID = 1, Email = "saw@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 3, Vorname = "Müsli", Name = "Maus", AddressID = 2, Email = "sew@gmx.ch", Password = "123" });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 1, CustomerID = 1, OrderDate = new DateTime(2022, 11, 25) });

            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 1, OrderPositionID = 1, ItemID = 1 });





            #endregion


        }
       
    }
}
