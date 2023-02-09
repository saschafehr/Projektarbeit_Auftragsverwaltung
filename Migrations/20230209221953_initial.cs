using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektarbeitAuftragsverwaltung.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    ItemGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.ItemGroupID);
                    table.ForeignKey(
                        name: "FK_ItemGroups_ItemGroups_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupID");
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                columns: table => new
                {
                    VATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAT", x => x.VATID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ItemGroupID = table.Column<int>(type: "int", nullable: false),
                    VATID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupID",
                        column: x => x.ItemGroupID,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_VAT_VATID",
                        column: x => x.VATID,
                        principalTable: "VAT",
                        principalColumn: "VATID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositions",
                columns: table => new
                {
                    OrderPositionID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => new { x.OrderID, x.OrderPositionID });
                    table.ForeignKey(
                        name: "FK_OrderPositions_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "Postcode", "Street" },
                values: new object[,]
                {
                    { 1, "St. Gallen", 8595, "Scherzingerstrasse 13" },
                    { 2, "Frauenfeld", 8500, "Bahnhofstrasse 1" },
                    { 3, "Dübendorf", 8600, "Hauptstrasse 2" },
                    { 4, "Uster", 8610, "Zentralstrasse 15" },
                    { 5, "Küsnacht", 8700, "Seestrasse 20" },
                    { 6, "Zürich", 8600, "Bahnhofstrasse 30" },
                    { 7, "Winterthur", 8500, "Stadtmitte 50" },
                    { 8, "Zürich", 8000, "Hauptstrasse 60" },
                    { 9, "Zürich", 8600, "Seestrasse 70" },
                    { 10, "Küsnacht", 8700, "Hauptstrasse 80" },
                    { 11, "Zürich", 8600, "Zentralstrasse 90" },
                    { 12, "Winterthur", 8500, "Bahnhofstrasse 100" },
                    { 13, "Zürich", 8000, "Seestrasse 110" },
                    { 14, "Zürich", 8600, "Hauptstrasse 120" },
                    { 15, "Küsnacht", 8700, "Zentralstrasse 130" },
                    { 16, "Zürich", 8600, "Bahnhofstrasse 140" },
                    { 17, "Winterthur", 8500, "Seestrasse 150" },
                    { 18, "Zürich", 8000, "Hauptstrasse 160" },
                    { 19, "Zürich", 8600, "Zentralstrasse 170" },
                    { 20, "Küsnacht", 8700, "Bahnhofstrasse 180" },
                    { 21, "Zürich", 8600, "Seestrasse 190" },
                    { 22, "Winterthur", 8500, "Hauptstrasse 200" },
                    { 23, "Zürich", 8000, "Zentralstrasse 210" },
                    { 24, "Zürich", 8600, "Bahnhofstrasse 220" },
                    { 25, "Küsnacht", 8700, "Seestrasse 230" },
                    { 26, "St. Gallen", 8595, "Scherzingerstrasse 14" },
                    { 27, "Frauenfeld", 8500, "Bahnhofstrasse 2" },
                    { 28, "Dübendorf", 8600, "Hauptstrasse 3" },
                    { 29, "Uster", 8610, "Zentralstrasse 16" },
                    { 30, "Küsnacht", 8700, "Seestrasse 21" },
                    { 31, "Zürich", 8600, "Bahnhofstrasse 31" },
                    { 32, "Winterthur", 8500, "Stadtmitte 51" },
                    { 33, "Zürich", 8000, "Hauptstrasse 61" },
                    { 34, "Zürich", 8600, "Seestrasse 71" },
                    { 35, "Küsnacht", 8700, "Hauptstrasse 81" },
                    { 36, "Zürich", 8600, "Zentralstrasse 91" },
                    { 37, "Winterthur", 8500, "Bahnhofstrasse 101" },
                    { 38, "Zürich", 8000, "Seestrasse 111" },
                    { 39, "Zürich", 8600, "Hauptstrasse 121" },
                    { 40, "Küsnacht", 8700, "Zentralstrasse 131" },
                    { 41, "Zürich", 8600, "Bahnhofstrasse 141" },
                    { 42, "Winterthur", 8500, "Am Berg 2" },
                    { 43, "Zürich", 8000, "Seestrasse 14" },
                    { 44, "Zürich", 8600, "Hauptstrasse 24" },
                    { 45, "Küsnacht", 8700, "Zentralstrasse 34" },
                    { 46, "Zürich", 8600, "Bahnhofstrasse 44" },
                    { 47, "Winterthur", 8500, "Stadtmitte 54" },
                    { 48, "Zürich", 8000, "Seestrasse 64" },
                    { 49, "Zürich", 8600, "Hauptstrasse 74" },
                    { 50, "Küsnacht", 8700, "Zentralstrasse 84" }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "ItemGroupID", "Name", "ParentID" },
                values: new object[,]
                {
                    { 1, "IT", null },
                    { 2, "Möbel", null },
                    { 15, "Kleider", null },
                    { 16, "Essen", null },
                    { 17, "Sport", null }
                });

            migrationBuilder.InsertData(
                table: "VAT",
                columns: new[] { "VATID", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Normalsatz", 7.7000000000000002 },
                    { 2, "Sondersatz", 3.7000000000000002 },
                    { 3, "Reduziertersatz", 2.5 },
                    { 4, "Befreitersatz", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "AddressID", "Email", "Firstname", "Lastname", "Password", "Website" },
                values: new object[,]
                {
                    { 1, 1, "sw@gmx.ch", "Sandro", "Wuttke", "123", null },
                    { 2, 1, "saw@gmx.ch", "Säuli", "Sau", "123", null },
                    { 3, 2, "sew@gmx.ch", "Müsli", "Maus", "123", null },
                    { 4, 3, "pp@gmx.ch", "Peter", "Parker", "123", null },
                    { 5, 4, "mm@gmx.ch", "Maria", "Müller", "123", null },
                    { 6, 5, "max@gmx.ch", "Max", "Meier", "123", null },
                    { 7, 6, "lisa@gmx.ch", "Lisa", "Lustig", "123", null },
                    { 8, 7, "tom@gmx.ch", "Tom", "Turner", "123", null },
                    { 9, 8, "anna@gmx.ch", "Anna", "Albrecht", "123", null },
                    { 10, 9, "bert@gmx.ch", "Bert", "Bär", "123", null },
                    { 11, 10, "claudia@gmx.ch", "Claudia", "Clerc", "123", null },
                    { 12, 11, "david@gmx.ch", "David", "Dietrich", "123", null },
                    { 13, 12, "eva@gmx.ch", "Eva", "Eberhard", "123", null },
                    { 14, 13, "frank@gmx.ch", "Frank", "Friedrich", "123", null },
                    { 15, 14, "gabi@gmx.ch", "Gabi", "Graf", "123", null },
                    { 16, 15, "hans@gmx.ch", "Hans", "Hertz", "123", null },
                    { 17, 16, "irina@gmx.ch", "Irina", "Illinger", "123", null },
                    { 18, 17, "jan@gmx.ch", "Jan", "Jung", "123", null },
                    { 19, 18, "klara@gmx.ch", "Klara", "Kern", "123", null },
                    { 20, 19, "luca@gmx.ch", "Luca", "Lenz", "123", null },
                    { 21, 20, "monika@gmx.ch", "Monika", "Meyer", "123", null },
                    { 22, 21, "nina@gmx.ch", "Nina", "Nussbaum", "123", null },
                    { 23, 22, "otto@gmx.ch", "Otto", "Ochs", "123", null },
                    { 24, 23, "paul@gmx.ch", "Paul", "Pfister", "123", null },
                    { 25, 24, "queena@gmx.ch", "Queena", "Quast", "123", null },
                    { 26, 25, "roni@gmx.ch", "Roni", "Rau", "123", null },
                    { 27, 26, "stefan@gmx.ch", "Stefan", "Schreiber", "123", null },
                    { 28, 27, "tina@gmx.ch", "Tina", "Tobler", "123", null },
                    { 29, 28, "urs@gmx.ch", "Urs", "Uhlmann", "123", null },
                    { 30, 29, "verena@gmx.ch", "Verena", "Vogel", "123", null },
                    { 31, 30, "werner@gmx.ch", "Werner", "Weber", "123", null },
                    { 32, 31, "xenia@gmx.ch", "Xenia", "Xaver", "123", null },
                    { 33, 32, "yves@gmx.ch", "Yves", "Yannick", "123", null },
                    { 34, 33, "zora@gmx.ch", "Zora", "Zimmermann", "123", null },
                    { 35, 34, "anna@gmx.ch", "Anna", "Arnold", "123", null },
                    { 36, 35, "bert@gmx.ch", "Bert", "Baumann", "123", null },
                    { 37, 36, "claudia@gmx.ch", "Claudia", "Clerc", "123", null },
                    { 38, 37, "daniel@gmx.ch", "Daniel", "Dietrich", "123", null },
                    { 39, 38, "emil@gmx.ch", "Emil", "Egger", "123", null },
                    { 40, 39, "franz@gmx.ch", "Franz", "Fuchs", "123", null },
                    { 41, 40, "gertrud@gmx.ch", "Gertrud", "Gut", "123", null },
                    { 42, 41, "heinz@gmx.ch", "Heinz", "Huber", "123", null },
                    { 43, 42, "ingrid@gmx.ch", "Ingrid", "Isler", "123", null },
                    { 44, 43, "juerg@gmx.ch", "Jürg", "Jäger", "123", null },
                    { 45, 44, "kaethi@gmx.ch", "Käthi", "Kühn", "123", null },
                    { 46, 45, "luzia@gmx.ch", "Luzia", "Lang", "123", null },
                    { 47, 46, "max@gmx.ch", "Max", "Meyer", "123", null },
                    { 48, 47, "nina@gmx.ch", "Nina", "Nussbaumer", "123", null },
                    { 49, 48, "otto@gmx.ch", "Otto", "Odermatt", "123", null },
                    { 50, 49, "paula@gmx.ch", "Paula", "Peier", "123", null }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "ItemGroupID", "Name", "ParentID" },
                values: new object[,]
                {
                    { 3, "Laptop", 1 },
                    { 4, "Tisch", 2 },
                    { 5, "Stuhl", 2 },
                    { 7, "Smartphone", 1 },
                    { 8, "Bett", 2 },
                    { 10, "Kamera", 1 },
                    { 11, "TV", 1 },
                    { 13, "Schreibtisch", 2 },
                    { 14, "Lampe", 2 },
                    { 18, "Herrenbekleidung", 15 },
                    { 19, "Damenbekleidung", 15 },
                    { 20, "Getränke", 16 },
                    { 21, "Teigwaren", 16 },
                    { 22, "Snacks", 16 },
                    { 23, "Laufen", 17 },
                    { 24, "Radsport", 17 },
                    { 25, "Fitness", 17 },
                    { 26, "T-Shirts", 18 },
                    { 27, "Hosen", 18 },
                    { 28, "Jacken", 18 },
                    { 29, "Kleider", 19 },
                    { 30, "Blusen", 19 },
                    { 31, "Röcke", 19 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemGroupID", "Price", "Title", "VATID" },
                values: new object[,]
                {
                    { 1, 3, 2300.0, "MacBook Pro", 1 },
                    { 2, 3, 1340.0, "MacBook Air", 1 },
                    { 3, 3, 1300.0, "Lenovo Legion", 1 },
                    { 4, 3, 1400.0, "HP Elitebook 830 G9", 1 },
                    { 5, 3, 300.0, "Dell", 1 },
                    { 6, 3, 500.0, "Acer Aspire 5", 1 },
                    { 7, 3, 1700.0, "MSI GE75 Raider", 1 },
                    { 8, 10, 1400.0, "Kamera Pro", 1 },
                    { 9, 10, 940.0, "Kamera Beginner", 1 },
                    { 10, 7, 1850.0, "IPhone 13 Pro", 1 },
                    { 11, 7, 950.0, "Samsung Galaxy", 1 },
                    { 12, 7, 1350.0, "Blackberry", 1 },
                    { 13, 7, 45890.0, "Nokia 3310", 1 },
                    { 14, 7, 850.0, "Huawii", 1 },
                    { 15, 11, 850.0, "Samsung TV (55)", 1 },
                    { 16, 11, 1150.0, "Samsung TV (65)", 1 },
                    { 17, 11, 1650.0, "Samsung TV (75)", 1 },
                    { 18, 4, 250.0, "Holztisch (klein)", 1 },
                    { 19, 4, 450.0, "Holztisch (gross)", 1 },
                    { 20, 4, 550.0, "Metalltisch (klein)", 1 },
                    { 21, 4, 850.0, "Metalltisch (gross)", 1 },
                    { 22, 4, 1150.0, "Glastisch (gross)", 1 },
                    { 23, 5, 80.0, "Holzstuhl", 1 },
                    { 24, 5, 1220.0, "Sessel", 1 },
                    { 25, 5, 50.0, "Plastikstuhl", 1 },
                    { 26, 5, 11450.0, "Königlicher Thron", 1 },
                    { 27, 8, 4200.0, "Boxspringbett", 1 },
                    { 28, 8, 1200.0, "Kinderbett (Rakete)", 1 },
                    { 29, 8, 400.0, "Babybett", 1 },
                    { 30, 8, 1300.0, "Hochbett", 1 },
                    { 31, 13, 1200.0, "Schreibtisch (Home)", 1 },
                    { 32, 13, 1300.0, "Schreibtisch (Office)", 1 },
                    { 33, 13, 1900.0, "Antiker Schreibtisch", 1 },
                    { 34, 13, 920.0, "Kinder Schreibtisch", 1 },
                    { 35, 4, 23.0, "LED Spot", 1 },
                    { 36, 4, 13.0, "Deckenlampe", 1 },
                    { 37, 4, 130.0, "Stehlampe", 1 },
                    { 38, 22, 1.5, "Gummibären", 1 },
                    { 39, 22, 3.5, "Zweifel Kartoffelchips", 1 },
                    { 40, 22, 4.0, "Lindt Schokolade", 1 },
                    { 41, 22, 4.0, "Vanilla Eis", 1 },
                    { 42, 21, 2.6000000000000001, "Spaghetti", 1 },
                    { 43, 21, 2.7000000000000002, "Vollkorn Spaghetti", 1 },
                    { 44, 21, 3.1000000000000001, "Penne", 1 },
                    { 45, 20, 1.3, "Fanta", 1 },
                    { 46, 20, 1.3, "Rivella", 1 },
                    { 47, 20, 1.3, "Coca Cola", 1 },
                    { 48, 20, 11.300000000000001, "Schanpps", 1 },
                    { 49, 20, 1.3, "Eistee", 1 },
                    { 50, 23, 19.0, "Stirnband", 1 },
                    { 51, 23, 130.0, "Laufsensor", 1 },
                    { 52, 23, 29.899999999999999, "Läufer Cap", 1 },
                    { 53, 24, 11200.0, "Rennvelo Pro", 1 },
                    { 54, 24, 9200.0, "Rennvelo Medium", 1 },
                    { 55, 24, 1200.0, "Rennvelo Beginner", 1 },
                    { 56, 24, 11200.0, "Velohelm", 1 },
                    { 57, 24, 34.0, "Fahrrad Licht", 1 },
                    { 58, 24, 140.0, "Fahrradhose", 1 },
                    { 59, 24, 120.0, "Fahrrad Shirt", 1 },
                    { 60, 25, 11200.0, "Hantel 30kg", 1 },
                    { 61, 25, 3500.0, "Hantelstange 120cm", 1 },
                    { 63, 25, 23000.0, "Langhantel-Set 60kg", 1 },
                    { 64, 25, 8000.0, "Hantelscheiben 25kg (x2)", 1 },
                    { 108, 4, 850.0, "Glastisch (klein)", 1 },
                    { 109, 21, 1.3, "Hördli", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 13, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 14, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 15, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 16, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 17, new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 18, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 19, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 20, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 21, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 22, new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 23, new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 24, new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 25, new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 26, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 27, new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 28, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 29, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 30, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 31, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 32, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 33, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 34, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 35, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 36, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 37, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 38, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 39, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 40, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 41, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 42, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 43, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 44, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 45, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 46, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 47, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 48, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 49, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 50, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemGroupID", "Price", "Title", "VATID" },
                values: new object[,]
                {
                    { 62, 26, 8400.0, "Kettlebell 16kg", 1 },
                    { 65, 27, 5900.0, "Yoga-Matte", 1 },
                    { 66, 26, 100.0, "Designer T-Shirt", 1 },
                    { 67, 26, 60.0, "Graues T-Shirt", 1 },
                    { 68, 26, 55.0, "Weißes T-Shirt", 1 },
                    { 69, 26, 70.0, "Schwarzes T-Shirt", 1 },
                    { 70, 26, 65.0, "Blaues T-Shirt", 1 },
                    { 71, 26, 75.0, "Grünes T-Shirt", 1 },
                    { 72, 26, 80.0, "Rotes T-Shirt", 1 },
                    { 73, 26, 50.0, "Gelbes T-Shirt", 1 },
                    { 74, 26, 70.0, "Orange T-Shirt", 1 },
                    { 75, 26, 60.0, "Lila T-Shirt", 1 },
                    { 76, 26, 65.0, "Rosa T-Shirt", 1 },
                    { 77, 27, 120.0, "Hose lang Baumwolle", 1 },
                    { 78, 27, 110.0, "Hose kurz Baumwolle", 1 },
                    { 79, 27, 140.0, "Jeanshose Slim Fit", 1 },
                    { 80, 27, 16.0, "Hose aus China-Stoff", 1 },
                    { 81, 27, 200.0, "Leinenhose", 1 },
                    { 82, 27, 90.0, "Jogginghose", 1 },
                    { 83, 28, 190.0, "Winterjacke", 1 },
                    { 84, 28, 250.0, "Daunenjacke", 1 },
                    { 85, 28, 220.0, "Parka", 1 },
                    { 86, 28, 180.0, "Steppjacke", 1 },
                    { 87, 28, 150.0, "Regenjacke", 1 },
                    { 88, 28, 200.0, "Wolljacke", 1 },
                    { 89, 29, 190.0, "Sommerkleid", 1 },
                    { 90, 29, 150.0, "Maxikleid", 1 },
                    { 91, 29, 170.0, "Empirekleid", 1 },
                    { 92, 29, 220.0, "Spitzenkleid", 1 },
                    { 93, 29, 300.0, "Abendkleid", 1 },
                    { 94, 29, 160.0, "Wickelkleid", 1 },
                    { 95, 30, 190.0, "Sommerbluse", 1 },
                    { 96, 30, 130.0, "Hemdbluse", 1 },
                    { 97, 30, 160.0, "Spitzenbluse", 1 },
                    { 98, 30, 140.0, "Chiffonbluse", 1 },
                    { 99, 30, 170.0, "Karobluse", 1 },
                    { 100, 30, 150.0, "Rüschenbluse", 1 },
                    { 101, 31, 190.0, "Ultra kurz Rock", 1 },
                    { 102, 31, 140.0, "Midi Rock", 1 },
                    { 103, 31, 170.0, "Bleistiftrock", 1 },
                    { 104, 31, 160.0, "A-Linie Rock", 1 },
                    { 105, 31, 130.0, "Plissee Rock", 1 },
                    { 106, 31, 150.0, "Schleifenrock", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "OrderID", "OrderPositionID", "ItemID" },
                values: new object[,]
                {
                    { 1, 1, 41 },
                    { 1, 2, 56 },
                    { 3, 1, 47 },
                    { 5, 1, 22 },
                    { 6, 1, 61 },
                    { 7, 2, 15 },
                    { 9, 1, 53 },
                    { 9, 2, 38 },
                    { 9, 3, 21 },
                    { 10, 1, 34 },
                    { 11, 1, 12 },
                    { 11, 2, 59 },
                    { 14, 1, 19 },
                    { 15, 1, 60 },
                    { 16, 1, 49 },
                    { 17, 2, 24 },
                    { 18, 1, 31 },
                    { 19, 2, 16 },
                    { 20, 2, 47 },
                    { 22, 1, 42 },
                    { 22, 2, 12 },
                    { 23, 2, 51 },
                    { 24, 1, 61 },
                    { 26, 2, 20 },
                    { 26, 3, 33 },
                    { 28, 1, 2 },
                    { 30, 1, 29 },
                    { 31, 1, 23 },
                    { 32, 1, 50 },
                    { 34, 2, 40 },
                    { 35, 1, 56 },
                    { 36, 1, 20 },
                    { 36, 3, 10 },
                    { 37, 2, 4 },
                    { 38, 1, 1 },
                    { 39, 1, 23 },
                    { 39, 2, 45 },
                    { 40, 3, 34 },
                    { 41, 1, 17 },
                    { 41, 2, 20 },
                    { 41, 3, 23 },
                    { 42, 1, 50 },
                    { 42, 3, 30 },
                    { 42, 5, 12 },
                    { 43, 2, 33 },
                    { 43, 4, 56 },
                    { 44, 1, 21 },
                    { 44, 2, 10 },
                    { 45, 2, 29 },
                    { 46, 1, 47 },
                    { 46, 2, 26 },
                    { 47, 1, 12 },
                    { 47, 2, 19 },
                    { 47, 3, 59 },
                    { 48, 2, 29 },
                    { 48, 3, 46 },
                    { 49, 1, 42 },
                    { 49, 5, 59 },
                    { 50, 1, 53 },
                    { 50, 2, 27 },
                    { 50, 3, 59 },
                    { 50, 5, 16 },
                    { 2, 1, 89 },
                    { 4, 1, 81 },
                    { 5, 2, 70 },
                    { 7, 1, 93 },
                    { 8, 1, 76 },
                    { 12, 1, 96 },
                    { 13, 1, 82 },
                    { 14, 2, 80 },
                    { 17, 1, 87 },
                    { 17, 3, 68 },
                    { 19, 1, 69 },
                    { 20, 1, 74 },
                    { 21, 1, 84 },
                    { 23, 1, 99 },
                    { 25, 1, 92 },
                    { 26, 1, 65 },
                    { 27, 1, 79 },
                    { 28, 2, 72 },
                    { 29, 1, 95 },
                    { 31, 2, 85 },
                    { 33, 1, 70 },
                    { 34, 1, 100 },
                    { 36, 2, 80 },
                    { 37, 1, 95 },
                    { 39, 3, 67 },
                    { 40, 1, 89 },
                    { 40, 2, 101 },
                    { 41, 4, 78 },
                    { 42, 2, 68 },
                    { 42, 4, 96 },
                    { 43, 1, 65 },
                    { 43, 3, 92 },
                    { 43, 5, 89 },
                    { 44, 3, 103 },
                    { 44, 4, 74 },
                    { 44, 5, 77 },
                    { 45, 1, 67 },
                    { 45, 3, 71 },
                    { 45, 4, 86 },
                    { 45, 5, 100 },
                    { 46, 3, 70 },
                    { 46, 4, 71 },
                    { 46, 5, 94 },
                    { 47, 4, 76 },
                    { 47, 5, 92 },
                    { 48, 1, 87 },
                    { 48, 4, 72 },
                    { 48, 5, 101 },
                    { 49, 2, 70 },
                    { 49, 3, 86 },
                    { 49, 4, 104 },
                    { 50, 4, 98 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressID",
                table: "Customers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentID",
                table: "ItemGroups",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupID",
                table: "Items",
                column: "ItemGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_VATID",
                table: "Items",
                column: "VATID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_ItemID",
                table: "OrderPositions",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPositions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "VAT");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
