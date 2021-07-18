﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Context.Migrations
{
    [DbContext(typeof(SalesContext))]
    [Migration("20210718200357_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("Customer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_ID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Customer_ID = 1,
                            Customer_Name = "diana"
                        });
                });

            modelBuilder.Entity("Models.Invoice", b =>
                {
                    b.Property<int>("Invoice_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Invoice_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Invoice_TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("Invoice_TotalQty")
                        .HasColumnType("int");

                    b.HasKey("Invoice_no");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Invoice_no = 1,
                            Customer_ID = 1,
                            Invoice_Date = new DateTime(2021, 7, 18, 22, 3, 56, 607, DateTimeKind.Local).AddTicks(6934),
                            Invoice_TotalPrice = 20,
                            Invoice_TotalQty = 1
                        });
                });

            modelBuilder.Entity("Models.InvoiceDetails", b =>
                {
                    b.Property<int>("InvoiceDetails_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Invoice_no")
                        .HasColumnType("int");

                    b.Property<string>("Item_Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.HasKey("InvoiceDetails_ID");

                    b.HasIndex("Invoice_no");

                    b.HasIndex("Item_Name");

                    b.ToTable("InvoiceDetails");

                    b.HasData(
                        new
                        {
                            InvoiceDetails_ID = 1,
                            Invoice_no = 1,
                            Item_Name = "item1",
                            Quantity = 2,
                            totalPrice = 20
                        });
                });

            modelBuilder.Entity("Models.Items", b =>
                {
                    b.Property<string>("Item_Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Item_Price")
                        .HasColumnType("int");

                    b.HasKey("Item_Name");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Item_Name = "item1",
                            Item_Price = 10
                        },
                        new
                        {
                            Item_Name = "item2",
                            Item_Price = 20
                        });
                });

            modelBuilder.Entity("Models.Invoice", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Invoice")
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Models.InvoiceDetails", b =>
                {
                    b.HasOne("Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("Invoice_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Items", "ItemDetails")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("Item_Name");

                    b.Navigation("Invoice");

                    b.Navigation("ItemDetails");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("Models.Items", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
