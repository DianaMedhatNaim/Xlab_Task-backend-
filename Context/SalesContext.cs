using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Context
{
    public class SalesContext: DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Customer_ID = 1,
                    Customer_Name = "diana"
                }
                ) ;
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Customer_ID = 2,
                    Customer_Name = "silvia"
                }
                );
            builder.Entity<Items>().HasData(
                new Items
                {
                    Item_Name = "item1",
                    Item_Price=10
                    
                }
                );
            builder.Entity<Items>().HasData(
                new Items
                {
                    Item_Name = "item2",
                    Item_Price = 20

                }
                );

            builder.Entity<Items>().HasData(
              new Items
              {
                  Item_Name = "item3",
                  Item_Price = 30

              }
              );
            builder.Entity<Items>().HasData(
              new Items
              {
                  Item_Name = "item4",
                  Item_Price = 40

              }
              );

            //builder.Entity<Invoice>().HasData(
            //   new Invoice
            //   {
            //       Invoice_no = 1,
            //       Invoice_Date = DateTime.Now,
            //       Invoice_TotalQty = 1,
            //       Invoice_TotalPrice = 20,
            //       Customer_ID = 1


            //   }
            //   );
            //builder.Entity<InvoiceDetails>().HasData(
            //  new InvoiceDetails
            //  {
            //      InvoiceDetails_ID = 1,
            //      Invoice_no = 1,
            //      Quantity = 2,
            //      totalPrice = 20,
            //      Item_Name = "item1"



            //  }
            //  );

        }

    }
}
