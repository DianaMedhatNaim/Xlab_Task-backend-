using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Item_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Item_Name);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoice_no = table.Column<int>(type: "int", nullable: false),
                    Invoice_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoice_TotalQty = table.Column<int>(type: "int", nullable: false),
                    Invoice_TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Invoice_no);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetails_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    Item_Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Invoice_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetails_ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_Invoice_no",
                        column: x => x.Invoice_no,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Items_Item_Name",
                        column: x => x.Item_Name,
                        principalTable: "Items",
                        principalColumn: "Item_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer_ID", "Customer_Name" },
                values: new object[,]
                {
                    { 1, "diana" },
                    { 2, "silvia" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Item_Name", "Item_Price" },
                values: new object[,]
                {
                    { "item1", 10 },
                    { "item2", 20 },
                    { "item3", 30 },
                    { "item4", 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_Invoice_no",
                table: "InvoiceDetails",
                column: "Invoice_no");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_Item_Name",
                table: "InvoiceDetails",
                column: "Item_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Customer_ID",
                table: "Invoices",
                column: "Customer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
