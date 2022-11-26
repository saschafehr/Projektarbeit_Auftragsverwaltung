 using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektarbeitAuftragsverwaltung.Migrations
{
    /// <inheritdoc />
    public partial class IntitalCreate : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
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
                    OrderPositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => x.OrderPositionID);
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
                    { 2, "Frauenfeld", 8500, "Bahnhofstrasse 1" }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "ItemGroupID", "Name", "ParentID" },
                values: new object[,]
                {
                    { 1, "IT", null },
                    { 2, "Möbel", null }
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
                columns: new[] { "CustomerID", "AddressID", "Email", "Name", "Password", "Vorname", "Website" },
                values: new object[,]
                {
                    { 1, 1, "sw@gmx.ch", "Wuttke", "123", "Sandro", null },
                    { 2, 1, "saw@gmx.ch", "Sau", "123", "Säuli", null },
                    { 3, 2, "sew@gmx.ch", "Maus", "123", "Müsli", null }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "ItemGroupID", "Name", "ParentID" },
                values: new object[,]
                {
                    { 3, "Laptop", 1 },
                    { 4, "Tisch", 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemGroupID", "Price", "Title", "VATID" },
                values: new object[,]
                {
                    { 1, 1, 1300m, "MacBook Pro", 1 },
                    { 2, 2, 100m, "Gaming Stuhl", 1 },
                    { 3, 1, 11300m, "Visual Studio 2022", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "OrderPositionID", "ItemID", "OrderID" },
                values: new object[] { 1, 1, 1 });

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
                name: "IX_OrderPositions_OrderID",
                table: "OrderPositions",
                column: "OrderID");

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
