using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using Projektarbeit_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            modelBuilder.Entity<OrderPosition>()
    .HasKey(op => new { op.OrderID, op.OrderPositionID });

            #region Beispiel
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 1, Rate = 7.7, Name = "Normalsatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 2, Rate = 3.7, Name = "Sondersatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 3, Rate = 2.5, Name = "Reduziertersatz" });
            modelBuilder.Entity<VAT>().HasData(new VAT() { VATID = 4, Rate = 0, Name = "Befreitersatz" });

            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 1, Name = "IT", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 2, Name = "Möbel", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 3, Name = "Laptop", ParentID = 1 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 4, Name = "Tisch", ParentID = 2, });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 5, Name = "Stuhl", ParentID = 2 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 7, Name = "Smartphone", ParentID = 1 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 8, Name = "Bett", ParentID = 2 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 10, Name = "Kamera", ParentID = 1 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 11, Name = "TV", ParentID = 1 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 13, Name = "Schreibtisch", ParentID = 2 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 14, Name = "Lampe", ParentID = 2 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 15, Name = "Kleider", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 16, Name = "Essen", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 17, Name = "Sport", ParentID = null });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 18, Name = "Herrenbekleidung", ParentID = 15 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 19, Name = "Damenbekleidung", ParentID = 15 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 20, Name = "Getränke", ParentID = 16 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 21, Name = "Teigwaren", ParentID = 16 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 22, Name = "Snacks", ParentID = 16 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 23, Name = "Laufen", ParentID = 17 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 24, Name = "Radsport", ParentID = 17 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 26, Name = "T-Shirts", ParentID = 18 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 27, Name = "Hosen", ParentID = 18 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 28, Name = "Jacken", ParentID = 18 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 29, Name = "Kleider", ParentID = 19 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 30, Name = "Blusen", ParentID = 19 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 31, Name = "Röcke", ParentID = 19 });
            modelBuilder.Entity<ItemGroup>().HasData(new ItemGroup() { ItemGroupID = 25, Name = "Fitness", ParentID = 17 });

            //Laptop
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 1, Title = "MacBook Pro", Price = 2300, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 2, Title = "MacBook Air", Price = 1340, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 3, Title = "Lenovo Legion", Price = 1300, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 4, Title = "HP Elitebook 830 G9", Price = 1400, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 5, Title = "Dell", Price = 300, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 6, Title = "Acer Aspire 5", Price = 500, VATID = 1, ItemGroupID = 3 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 7, Title = "MSI GE75 Raider", Price = 1700, VATID = 1, ItemGroupID = 3 });

            //Kamera
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 8, Title = "Kamera Pro", Price = 1400, VATID = 1, ItemGroupID = 10 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 9, Title = "Kamera Beginner", Price = 940, VATID = 1, ItemGroupID = 10 });

            //Smartphone
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 10, Title = "IPhone 13 Pro", Price = 1850, VATID = 1, ItemGroupID = 7 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 11, Title = "Samsung Galaxy", Price = 950, VATID = 1, ItemGroupID = 7 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 12, Title = "Blackberry", Price = 1350, VATID = 1, ItemGroupID = 7 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 13, Title = "Nokia 3310", Price = 45890, VATID = 1, ItemGroupID = 7 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 14, Title = "Huawii", Price = 850, VATID = 1, ItemGroupID = 7 });

            // TV
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 15, Title = "Samsung TV (55)", Price = 850, VATID = 1, ItemGroupID = 11 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 16, Title = "Samsung TV (65)", Price = 1150, VATID = 1, ItemGroupID = 11 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 17, Title = "Samsung TV (75)", Price = 1650, VATID = 1, ItemGroupID = 11 });

            //Tisch
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 18, Title = "Holztisch (klein)", Price = 250, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 19, Title = "Holztisch (gross)", Price = 450, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 20, Title = "Metalltisch (klein)", Price = 550, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 21, Title = "Metalltisch (gross)", Price = 850, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 108, Title = "Glastisch (klein)", Price = 850, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 22, Title = "Glastisch (gross)", Price = 1150, VATID = 1, ItemGroupID = 4 });


            // Stuhl
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 23, Title = "Holzstuhl", Price = 80, VATID = 1, ItemGroupID = 5 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 24, Title = "Sessel", Price = 1220, VATID = 1, ItemGroupID = 5 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 25, Title = "Plastikstuhl", Price = 50, VATID = 1, ItemGroupID = 5 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 26, Title = "Königlicher Thron", Price = 11450, VATID = 1, ItemGroupID = 5 });

            //Bett
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 27, Title = "Boxspringbett", Price = 4200, VATID = 1, ItemGroupID = 8 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 28, Title = "Kinderbett (Rakete)", Price = 1200, VATID = 1, ItemGroupID = 8 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 29, Title = "Babybett", Price = 400, VATID = 1, ItemGroupID = 8 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 30, Title = "Hochbett", Price = 1300, VATID = 1, ItemGroupID = 8 });

            //Schreibtisch
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 31, Title = "Schreibtisch (Home)", Price = 1200, VATID = 1, ItemGroupID = 13 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 32, Title = "Schreibtisch (Office)", Price = 1300, VATID = 1, ItemGroupID = 13 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 33, Title = "Antiker Schreibtisch", Price = 1900, VATID = 1, ItemGroupID = 13 }); 
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 34, Title = "Kinder Schreibtisch", Price = 920, VATID = 1, ItemGroupID = 13 });

            // Lampe
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 35, Title = "LED Spot", Price = 23, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 36, Title = "Deckenlampe", Price = 13, VATID = 1, ItemGroupID = 4 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 37, Title = "Stehlampe", Price = 130, VATID = 1, ItemGroupID = 4 });

            //Snacks
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 38, Title = "Gummibären", Price = 1.5, VATID = 1, ItemGroupID = 22 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 39, Title = "Zweifel Kartoffelchips", Price = 3.5, VATID = 1, ItemGroupID = 22 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 40, Title = "Lindt Schokolade", Price = 4, VATID = 1, ItemGroupID = 22 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 41, Title = "Vanilla Eis", Price = 4.0, VATID = 1, ItemGroupID = 22 });

            // Teigwaren
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 42, Title = "Spaghetti", Price = 2.60, VATID = 1, ItemGroupID = 21 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 43, Title = "Vollkorn Spaghetti", Price = 2.70, VATID = 1, ItemGroupID = 21 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 109, Title = "Hördli", Price = 1.30, VATID = 1, ItemGroupID = 21 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 44, Title = "Penne", Price = 3.10, VATID = 1, ItemGroupID = 21 });

            // Getränke
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 45, Title = "Fanta", Price = 1.30, VATID = 1, ItemGroupID = 20 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 46, Title = "Rivella", Price = 1.300, VATID = 1, ItemGroupID = 20 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 47, Title = "Coca Cola", Price = 1.30, VATID = 1, ItemGroupID = 20 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 48, Title = "Schanpps", Price = 11.30, VATID = 1, ItemGroupID = 20 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 49, Title = "Eistee", Price = 1.30, VATID = 1, ItemGroupID = 20 });

            // Laufen
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 50, Title = "Stirnband", Price = 19, VATID = 1, ItemGroupID = 23 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 51, Title = "Laufsensor", Price = 130, VATID = 1, ItemGroupID = 23 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 52, Title = "Läufer Cap", Price = 29.90, VATID = 1, ItemGroupID = 23 });

            //Radsport
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 53, Title = "Rennvelo Pro", Price = 11200, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 54, Title = "Rennvelo Medium", Price = 9200, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 55, Title = "Rennvelo Beginner", Price = 1200, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 56, Title = "Velohelm", Price = 11200, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 57, Title = "Fahrrad Licht", Price = 34, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 58, Title = "Fahrradhose", Price = 140, VATID = 1, ItemGroupID = 24 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 59, Title = "Fahrrad Shirt", Price = 120, VATID = 1, ItemGroupID = 24 });

            // Fitness
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 60, Title = "Hantel 30kg", Price = 11200, VATID = 1, ItemGroupID = 25 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 61, Title = "Hantelstange 120cm", Price = 3500, VATID = 1, ItemGroupID = 25 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 62, Title = "Kettlebell 16kg", Price = 8400, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 63, Title = "Langhantel-Set 60kg", Price = 23000, VATID = 1, ItemGroupID = 25 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 64, Title = "Hantelscheiben 25kg (x2)", Price = 8000, VATID = 1, ItemGroupID = 25 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 65, Title = "Yoga-Matte", Price = 5900, VATID = 1, ItemGroupID = 27 });

            // Herren Tshirt
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 66, Title = "Designer T-Shirt", Price = 100, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 67, Title = "Graues T-Shirt", Price = 60, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 68, Title = "Weißes T-Shirt", Price = 55, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 69, Title = "Schwarzes T-Shirt", Price = 70, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 70, Title = "Blaues T-Shirt", Price = 65, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 71, Title = "Grünes T-Shirt", Price = 75, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 72, Title = "Rotes T-Shirt", Price = 80, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 73, Title = "Gelbes T-Shirt", Price = 50, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 74, Title = "Orange T-Shirt", Price = 70, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 75, Title = "Lila T-Shirt", Price = 60, VATID = 1, ItemGroupID = 26 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 76, Title = "Rosa T-Shirt", Price = 65, VATID = 1, ItemGroupID = 26 });

            // Herren Hosen
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 77, Title = "Hose lang Baumwolle", Price = 120, VATID = 1, ItemGroupID = 27 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 78, Title = "Hose kurz Baumwolle", Price = 110, VATID = 1, ItemGroupID = 27 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 79, Title = "Jeanshose Slim Fit", Price = 140, VATID = 1, ItemGroupID = 27 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 80, Title = "Hose aus China-Stoff", Price = 16, VATID = 1, ItemGroupID = 27 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 81, Title = "Leinenhose", Price = 200, VATID = 1, ItemGroupID = 27 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 82, Title = "Jogginghose", Price = 90, VATID = 1, ItemGroupID = 27 });

            // Herren Jacke
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 83, Title = "Winterjacke", Price = 190, VATID = 1, ItemGroupID = 28 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 84, Title = "Daunenjacke", Price = 250, VATID = 1, ItemGroupID = 28 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 85, Title = "Parka", Price = 220, VATID = 1, ItemGroupID = 28 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 86, Title = "Steppjacke", Price = 180, VATID = 1, ItemGroupID = 28 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 87, Title = "Regenjacke", Price = 150, VATID = 1, ItemGroupID = 28 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 88, Title = "Wolljacke", Price = 200, VATID = 1, ItemGroupID = 28 });

            // Damen Kleider
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 89, Title = "Sommerkleid", Price = 190, VATID = 1, ItemGroupID = 29 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 90, Title = "Maxikleid", Price = 150, VATID = 1, ItemGroupID = 29 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 91, Title = "Empirekleid", Price = 170, VATID = 1, ItemGroupID = 29 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 92, Title = "Spitzenkleid", Price = 220, VATID = 1, ItemGroupID = 29 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 93, Title = "Abendkleid", Price = 300, VATID = 1, ItemGroupID = 29 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 94, Title = "Wickelkleid", Price = 160, VATID = 1, ItemGroupID = 29 });

            // Damen Bluse
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 95, Title = "Sommerbluse", Price = 190, VATID = 1, ItemGroupID = 30 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 96, Title = "Hemdbluse", Price = 130, VATID = 1, ItemGroupID = 30 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 97, Title = "Spitzenbluse", Price = 160, VATID = 1, ItemGroupID = 30 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 98, Title = "Chiffonbluse", Price = 140, VATID = 1, ItemGroupID = 30 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 99, Title = "Karobluse", Price = 170, VATID = 1, ItemGroupID = 30 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 100, Title = "Rüschenbluse", Price = 150, VATID = 1, ItemGroupID = 30 });
            // Damen Röcke
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 101, Title = "Ultra kurz Rock", Price = 190, VATID = 1, ItemGroupID = 31 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 102, Title = "Midi Rock", Price = 140, VATID = 1, ItemGroupID = 31 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 103, Title = "Bleistiftrock", Price = 170, VATID = 1, ItemGroupID = 31 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 104, Title = "A-Linie Rock", Price = 160, VATID = 1, ItemGroupID = 31 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 105, Title = "Plissee Rock", Price = 130, VATID = 1, ItemGroupID = 31 });
            modelBuilder.Entity<Item>().HasData(new Item() { ItemID = 106, Title = "Schleifenrock", Price = 150, VATID = 1, ItemGroupID = 31 });


            //Adressen
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 1, Postcode = 8595, City = "St. Gallen", Street = "Scherzingerstrasse 13" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 2, Postcode = 8500, City = "Frauenfeld", Street = "Bahnhofstrasse 1" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 3, Postcode = 8600, City = "Dübendorf", Street = "Hauptstrasse 2" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 4, Postcode = 8610, City = "Uster", Street = "Zentralstrasse 15" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 5, Postcode = 8700, City = "Küsnacht", Street = "Seestrasse 20" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 6, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 30" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 7, Postcode = 8500, City = "Winterthur", Street = "Stadtmitte 50" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 8, Postcode = 8000, City = "Zürich", Street = "Hauptstrasse 60" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 9, Postcode = 8600, City = "Zürich", Street = "Seestrasse 70" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 10, Postcode = 8700, City = "Küsnacht", Street = "Hauptstrasse 80" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 11, Postcode = 8600, City = "Zürich", Street = "Zentralstrasse 90" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 12, Postcode = 8500, City = "Winterthur", Street = "Bahnhofstrasse 100" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 13, Postcode = 8000, City = "Zürich", Street = "Seestrasse 110" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 14, Postcode = 8600, City = "Zürich", Street = "Hauptstrasse 120" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 15, Postcode = 8700, City = "Küsnacht", Street = "Zentralstrasse 130" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 16, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 140" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 17, Postcode = 8500, City = "Winterthur", Street = "Seestrasse 150" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 18, Postcode = 8000, City = "Zürich", Street = "Hauptstrasse 160" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 19, Postcode = 8600, City = "Zürich", Street = "Zentralstrasse 170" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 20, Postcode = 8700, City = "Küsnacht", Street = "Bahnhofstrasse 180" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 21, Postcode = 8600, City = "Zürich", Street = "Seestrasse 190" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 22, Postcode = 8500, City = "Winterthur", Street = "Hauptstrasse 200" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 23, Postcode = 8000, City = "Zürich", Street = "Zentralstrasse 210" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 24, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 220" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 25, Postcode = 8700, City = "Küsnacht", Street = "Seestrasse 230" }); 
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 26, Postcode = 8595, City = "St. Gallen", Street = "Scherzingerstrasse 14" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 27, Postcode = 8500, City = "Frauenfeld", Street = "Bahnhofstrasse 2" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 28, Postcode = 8600, City = "Dübendorf", Street = "Hauptstrasse 3" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 29, Postcode = 8610, City = "Uster", Street = "Zentralstrasse 16" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 30, Postcode = 8700, City = "Küsnacht", Street = "Seestrasse 21" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 31, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 31" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 32, Postcode = 8500, City = "Winterthur", Street = "Stadtmitte 51" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 33, Postcode = 8000, City = "Zürich", Street = "Hauptstrasse 61" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 34, Postcode = 8600, City = "Zürich", Street = "Seestrasse 71" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 35, Postcode = 8700, City = "Küsnacht", Street = "Hauptstrasse 81" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 36, Postcode = 8600, City = "Zürich", Street = "Zentralstrasse 91" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 37, Postcode = 8500, City = "Winterthur", Street = "Bahnhofstrasse 101" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 38, Postcode = 8000, City = "Zürich", Street = "Seestrasse 111" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 39, Postcode = 8600, City = "Zürich", Street = "Hauptstrasse 121" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 40, Postcode = 8700, City = "Küsnacht", Street = "Zentralstrasse 131" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 41, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 141" });
            modelBuilder.Entity<Address>().HasData(new Address() {AddressID = 42,Postcode = 8500, City = "Winterthur", Street = "Am Berg 2" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 43, Postcode = 8000, City = "Zürich", Street = "Seestrasse 14" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 44, Postcode = 8600, City = "Zürich", Street = "Hauptstrasse 24" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 45, Postcode = 8700, City = "Küsnacht", Street = "Zentralstrasse 34" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 46, Postcode = 8600, City = "Zürich", Street = "Bahnhofstrasse 44" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 47, Postcode = 8500, City = "Winterthur", Street = "Stadtmitte 54" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 48, Postcode = 8000, City = "Zürich", Street = "Seestrasse 64" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 49, Postcode = 8600, City = "Zürich", Street = "Hauptstrasse 74" });
            modelBuilder.Entity<Address>().HasData(new Address() { AddressID = 50, Postcode = 8700, City = "Küsnacht", Street = "Zentralstrasse 84" });



            //Customer
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 1, Firstname = "Sandro",Lastname = "Wuttke", AddressID = 1, Email = "sw@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 2, Firstname = "Säuli",Lastname = "Sau", AddressID = 1, Email = "saw@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 3, Firstname = "Müsli",Lastname = "Maus", AddressID = 2, Email = "sew@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 4, Firstname = "Peter",Lastname = "Parker", AddressID = 3, Email = "pp@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 5, Firstname = "Maria",Lastname = "Müller", AddressID = 4, Email = "mm@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 6, Firstname = "Max", Lastname= "Meier", AddressID = 5, Email = "max@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 7, Firstname = "Lisa", Lastname = "Lustig", AddressID = 6, Email = "lisa@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 9, Firstname = "Anna", Lastname = "Albrecht", AddressID = 8, Email = "anna@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 8, Firstname = "Tom", Lastname = "Turner", AddressID = 7, Email = "tom@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 10,Firstname = "Bert", Lastname = "Bär", AddressID = 9, Email = "bert@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 11,Firstname = "Claudia", Lastname = "Clerc", AddressID = 10, Email = "claudia@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 12,Firstname = "David", Lastname = "Dietrich", AddressID = 11, Email = "david@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 13,Firstname = "Eva", Lastname = "Eberhard", AddressID = 12, Email = "eva@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 14,Firstname = "Frank", Lastname = "Friedrich", AddressID = 13, Email = "frank@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 15,Firstname = "Gabi", Lastname = "Graf", AddressID = 14, Email = "gabi@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 16,Firstname = "Hans", Lastname = "Hertz", AddressID = 15, Email = "hans@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 17,Firstname = "Irina", Lastname = "Illinger", AddressID = 16, Email = "irina@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 18,Firstname = "Jan", Lastname = "Jung", AddressID = 17, Email = "jan@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 19,Firstname = "Klara", Lastname = "Kern", AddressID = 18, Email = "klara@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 20,Firstname = "Luca", Lastname = "Lenz", AddressID = 19, Email = "luca@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 21,Firstname = "Monika", Lastname = "Meyer", AddressID = 20, Email = "monika@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 22,Firstname = "Nina", Lastname = "Nussbaum", AddressID = 21, Email = "nina@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 23,Firstname = "Otto", Lastname = "Ochs", AddressID = 22, Email = "otto@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 24,Firstname = "Paul", Lastname = "Pfister", AddressID = 23, Email = "paul@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 25,Firstname = "Queena", Lastname = "Quast", AddressID = 24, Email = "queena@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 26,Firstname = "Roni", Lastname = "Rau", AddressID = 25, Email = "roni@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 27,Firstname = "Stefan", Lastname = "Schreiber", AddressID = 26, Email = "stefan@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 28,Firstname = "Tina", Lastname = "Tobler", AddressID = 27, Email = "tina@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 29,Firstname = "Urs", Lastname = "Uhlmann", AddressID = 28, Email = "urs@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 30,Firstname = "Verena", Lastname = "Vogel", AddressID = 29, Email = "verena@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 31,Firstname = "Werner", Lastname = "Weber", AddressID = 30, Email = "werner@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 32,Firstname = "Xenia", Lastname = "Xaver", AddressID = 31, Email = "xenia@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 33,Firstname = "Yves", Lastname = "Yannick", AddressID = 32, Email = "yves@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 34,Firstname = "Zora", Lastname = "Zimmermann", AddressID = 33, Email = "zora@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 35,Firstname = "Anna", Lastname = "Arnold", AddressID = 34, Email = "anna@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 36,Firstname = "Bert", Lastname = "Baumann", AddressID = 35, Email = "bert@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 37,Firstname = "Claudia", Lastname = "Clerc", AddressID = 36, Email = "claudia@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 38,Firstname = "Daniel", Lastname = "Dietrich", AddressID = 37, Email = "daniel@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 39,Firstname = "Emil", Lastname = "Egger",AddressID = 38,Email = "emil@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 40,Firstname = "Franz", Lastname = "Fuchs", AddressID = 39, Email = "franz@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 41,Firstname = "Gertrud", Lastname = "Gut", AddressID = 40, Email = "gertrud@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 42,Firstname = "Heinz", Lastname = "Huber", AddressID = 41, Email = "heinz@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 43,Firstname = "Ingrid", Lastname = "Isler", AddressID = 42, Email = "ingrid@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 44,Firstname = "Jürg", Lastname = "Jäger", AddressID = 43, Email = "juerg@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 45,Firstname = "Käthi", Lastname = "Kühn", AddressID = 44, Email = "kaethi@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 46,Firstname = "Luzia", Lastname = "Lang", AddressID = 45, Email = "luzia@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 47,Firstname = "Max", Lastname = "Meyer", AddressID = 46, Email = "max@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 48,Firstname = "Nina", Lastname = "Nussbaumer", AddressID = 47, Email = "nina@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 49,Firstname = "Otto", Lastname = "Odermatt", AddressID = 48, Email = "otto@gmx.ch", Password = "123" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 50,Firstname = "Paula", Lastname = "Peier", AddressID = 49, Email = "paula@gmx.ch", Password = "123" });


            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 1, CustomerID = 1, OrderDate = new DateTime(2022, 11, 25) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 2, CustomerID = 2, OrderDate = new DateTime(2022, 11, 26) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 3, CustomerID = 3, OrderDate = new DateTime(2022, 11, 27) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 4, CustomerID = 4, OrderDate = new DateTime(2022, 11, 28) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 5, CustomerID = 5, OrderDate = new DateTime(2022, 11, 29) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 6, CustomerID = 6, OrderDate = new DateTime(2022, 11, 30) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 7, CustomerID = 7, OrderDate = new DateTime(2022, 12, 1) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 8, CustomerID = 8, OrderDate = new DateTime(2022, 12, 2) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 9, CustomerID = 9, OrderDate = new DateTime(2022, 12, 3) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 10, CustomerID = 10, OrderDate = new DateTime(2022, 12, 4) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 11, CustomerID = 11, OrderDate = new DateTime(2022, 12, 5) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 12, CustomerID = 12, OrderDate = new DateTime(2022, 12, 6) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 13, CustomerID = 13, OrderDate = new DateTime(2022, 12, 7) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 14, CustomerID = 14, OrderDate = new DateTime(2022, 12, 8) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 15, CustomerID = 15, OrderDate = new DateTime(2022, 12, 9) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 16, CustomerID = 16, OrderDate = new DateTime(2022, 12, 10) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 17, CustomerID = 17, OrderDate = new DateTime(2022, 12, 11) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 18, CustomerID = 18, OrderDate = new DateTime(2022, 12, 12) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 19, CustomerID = 19, OrderDate = new DateTime(2022, 12, 13) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 20, CustomerID = 20, OrderDate = new DateTime(2022, 12, 14) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 21, CustomerID = 21, OrderDate = new DateTime(2022, 12, 15) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 22, CustomerID = 22, OrderDate = new DateTime(2022, 12, 16) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 23, CustomerID = 23, OrderDate = new DateTime(2022, 12, 17) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 24, CustomerID = 24, OrderDate = new DateTime(2022, 12, 18) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 25, CustomerID = 25, OrderDate = new DateTime(2022, 12, 19) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 26, CustomerID = 26, OrderDate = new DateTime(2022, 12, 20) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 27, CustomerID = 27, OrderDate = new DateTime(2022, 12, 21) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 28, CustomerID = 28, OrderDate = new DateTime(2022, 12, 22) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 29, CustomerID = 29, OrderDate = new DateTime(2022, 12, 23) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 30, CustomerID = 30, OrderDate = new DateTime(2022, 12, 24) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 31, CustomerID = 31, OrderDate = new DateTime(2022, 12, 25) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 32, CustomerID = 32, OrderDate = new DateTime(2022, 12, 26) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 33, CustomerID = 33, OrderDate = new DateTime(2022, 12, 27) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 34, CustomerID = 34, OrderDate = new DateTime(2022, 12, 28) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 35, CustomerID = 35, OrderDate = new DateTime(2022, 12, 29) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 36, CustomerID = 36, OrderDate = new DateTime(2022, 12, 30) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 37, CustomerID = 37, OrderDate = new DateTime(2022, 12, 31) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 38, CustomerID = 38, OrderDate = new DateTime(2023, 1, 1) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 39, CustomerID = 39, OrderDate = new DateTime(2023, 1, 2) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 40, CustomerID = 40, OrderDate = new DateTime(2023, 1, 3) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 41, CustomerID = 41, OrderDate = new DateTime(2023, 1, 4) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 42, CustomerID = 42, OrderDate = new DateTime(2023, 1, 5) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 43, CustomerID = 43, OrderDate = new DateTime(2023, 1, 6) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 44, CustomerID = 44, OrderDate = new DateTime(2023, 1, 7) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 45, CustomerID = 45, OrderDate = new DateTime(2023, 1, 8) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 46, CustomerID = 46, OrderDate = new DateTime(2023, 1, 9) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 47, CustomerID = 47, OrderDate = new DateTime(2023, 1, 10) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 48, CustomerID = 48, OrderDate = new DateTime(2023, 1, 11) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 49, CustomerID = 49, OrderDate = new DateTime(2023, 1, 12) });
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 50, CustomerID = 50, OrderDate = new DateTime(2023, 1, 13) });





            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 1, OrderPositionID = 1, ItemID = 41 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 1, OrderPositionID = 2, ItemID = 56 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 2, OrderPositionID = 1, ItemID = 89 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 3, OrderPositionID = 1, ItemID = 47 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 4, OrderPositionID = 1, ItemID = 81 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 5, OrderPositionID = 1, ItemID = 22 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 5, OrderPositionID = 2, ItemID = 70 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 6, OrderPositionID = 1, ItemID = 61 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 7, OrderPositionID = 1, ItemID = 93 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 7, OrderPositionID = 2, ItemID = 15 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 8, OrderPositionID = 1, ItemID = 76 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 9, OrderPositionID = 1, ItemID = 53 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 9, OrderPositionID = 2, ItemID = 38 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 9, OrderPositionID = 3, ItemID = 21 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 10, OrderPositionID = 1, ItemID = 34 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 11, OrderPositionID = 1, ItemID = 12 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 11, OrderPositionID = 2, ItemID = 59 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 12, OrderPositionID = 1, ItemID = 96 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 13, OrderPositionID = 1, ItemID = 82 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 14, OrderPositionID = 1, ItemID = 19 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 14, OrderPositionID = 2, ItemID = 80 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 15, OrderPositionID = 1, ItemID = 60 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 16, OrderPositionID = 1, ItemID = 49 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 17, OrderPositionID = 1, ItemID = 87 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 17, OrderPositionID = 2, ItemID = 24 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 17, OrderPositionID = 3, ItemID = 68 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 18, OrderPositionID = 1, ItemID = 31 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 19, OrderPositionID = 1, ItemID = 69 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 19, OrderPositionID = 2, ItemID = 16 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 20, OrderPositionID = 1, ItemID = 74 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 20, OrderPositionID = 2, ItemID = 47 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 21, OrderPositionID = 1, ItemID = 84 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 22, OrderPositionID = 1, ItemID = 42 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 22, OrderPositionID = 2, ItemID = 12 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 23, OrderPositionID = 1, ItemID = 99 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 23, OrderPositionID = 2, ItemID = 51 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 24, OrderPositionID = 1, ItemID = 61 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 25, OrderPositionID = 1, ItemID = 92 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 26, OrderPositionID = 1, ItemID = 65 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 26, OrderPositionID = 2, ItemID = 20 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 26, OrderPositionID = 3, ItemID = 33 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 27, OrderPositionID = 1, ItemID = 79 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 28, OrderPositionID = 1, ItemID = 2 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 28, OrderPositionID = 2, ItemID = 72 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 29, OrderPositionID = 1, ItemID = 95 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 30, OrderPositionID = 1, ItemID = 29 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 31, OrderPositionID = 1, ItemID = 23 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 31, OrderPositionID = 2, ItemID = 85 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 32, OrderPositionID = 1, ItemID = 50 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 33, OrderPositionID = 1, ItemID = 70 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 34, OrderPositionID = 1, ItemID = 100 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 34, OrderPositionID = 2, ItemID = 40 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 35, OrderPositionID = 1, ItemID = 56 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 36, OrderPositionID = 1, ItemID = 20 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 36, OrderPositionID = 2, ItemID = 80 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 36, OrderPositionID = 3, ItemID = 10 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 37, OrderPositionID = 1, ItemID = 95 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 37, OrderPositionID = 2, ItemID = 4 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 38, OrderPositionID = 1, ItemID = 1 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 39, OrderPositionID = 1, ItemID = 23 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 39, OrderPositionID = 2, ItemID = 45 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 39, OrderPositionID = 3, ItemID = 67 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 40, OrderPositionID = 1, ItemID = 89 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 40, OrderPositionID = 2, ItemID = 101 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 40, OrderPositionID = 3, ItemID = 34 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 41, OrderPositionID = 1, ItemID = 17 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 41, OrderPositionID = 2, ItemID = 20 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 41, OrderPositionID = 3, ItemID = 23 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 41, OrderPositionID = 4, ItemID = 78 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 42, OrderPositionID = 1, ItemID = 50 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 42, OrderPositionID = 2, ItemID = 68 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 42, OrderPositionID = 3, ItemID = 30 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 42, OrderPositionID = 4, ItemID = 96 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 42, OrderPositionID = 5, ItemID = 12 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 43, OrderPositionID = 1, ItemID = 65 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 43, OrderPositionID = 2, ItemID = 33 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 43, OrderPositionID = 3, ItemID = 92 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 43, OrderPositionID = 4, ItemID = 56 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 43, OrderPositionID = 5, ItemID = 89 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 44, OrderPositionID = 1, ItemID = 21 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 44, OrderPositionID = 2, ItemID = 10 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 44, OrderPositionID = 3, ItemID = 103 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 44, OrderPositionID = 4, ItemID = 74 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 44, OrderPositionID = 5, ItemID = 77 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 45, OrderPositionID = 1, ItemID = 67 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 45, OrderPositionID = 2, ItemID = 29 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 45, OrderPositionID = 3, ItemID = 71 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 45, OrderPositionID = 4, ItemID = 86 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 45, OrderPositionID = 5, ItemID = 100 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 46, OrderPositionID = 1, ItemID = 47 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 46, OrderPositionID = 2, ItemID = 26 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 46, OrderPositionID = 3, ItemID = 70 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 46, OrderPositionID = 4, ItemID = 71 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 46, OrderPositionID = 5, ItemID = 94 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 47, OrderPositionID = 1, ItemID = 12 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 47, OrderPositionID = 2, ItemID = 19 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 47, OrderPositionID = 3, ItemID = 59 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 47, OrderPositionID = 4, ItemID = 76 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 47, OrderPositionID = 5, ItemID = 92 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 48, OrderPositionID = 1, ItemID = 87 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 48, OrderPositionID = 2, ItemID = 29 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 48, OrderPositionID = 3, ItemID = 46 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 48, OrderPositionID = 4, ItemID = 72 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 48, OrderPositionID = 5, ItemID = 101 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 49, OrderPositionID = 1, ItemID = 42 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 49, OrderPositionID = 2, ItemID = 70 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 49, OrderPositionID = 3, ItemID = 86 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 49, OrderPositionID = 4, ItemID = 104 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 49, OrderPositionID = 5, ItemID = 59 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 50, OrderPositionID = 1, ItemID = 53 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 50, OrderPositionID = 2, ItemID = 27 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 50, OrderPositionID = 3, ItemID = 59 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 50, OrderPositionID = 4, ItemID = 98 });
            modelBuilder.Entity<OrderPosition>().HasData(new OrderPosition() { OrderID = 50, OrderPositionID = 5, ItemID = 16 });




            #endregion


        }

    }
}
