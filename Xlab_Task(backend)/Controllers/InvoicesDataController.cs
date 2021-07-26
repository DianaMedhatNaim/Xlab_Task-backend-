using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Context;
using Models;

namespace Xlab_Task_backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesDataController : ControllerBase
    {
        private readonly SalesContext _context;

        public InvoicesDataController(SalesContext context)
        {
            _context = context;
        }
        Invoice inv;
        InvoiceDetails inv_Details;
        Invoice invoiceData;
        int inv_no;
        // GET: api/InvoicesData
        [HttpGet]
        public IQueryable<object> GetInvoices(int invoiceId)
        {
            var data = from I in _context.Invoices
                       join D in _context.InvoiceDetails on I.Invoice_no equals D.Invoice_no
                       join C in _context.Customers on new
                       {
                           k1 = I.Customer_ID,
                          
                       }
                       equals new
                       {
                           k1 = C.Customer_ID,
                           
                       }
                       join M in _context.Items on new
                       {
                           k2 = D.Item_Name,

                       }
                       equals new
                       {
                           k2 =M.Item_Name,

                       }
                       where I.Invoice_no== invoiceId
                       select new
                       {
                           Invoice_no = I.Invoice_no,
                           Customer_Name = C.Customer_Name,
                           Invoice_Date = I.Invoice_Date,
                           Item_Name = M.Item_Name,
                           Item_Price=M.Item_Price,
                           Quantity=D.Quantity,
                           Invoice_TotalQty=I.Invoice_TotalQty,
                           Invoice_TotalPrice=I.Invoice_TotalPrice,
                           totalPrice=D.totalPrice

                       };
            return data;
        }

        //// GET: api/InvoicesData/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Invoice>> GetInvoice(int id)
        //{
        //    var invoice = await _context.Invoices.FindAsync(id);

        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    return invoice;
        //}

        // PUT: api/InvoicesData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<string> PutInvoice(invoice_DataType[] data)
        { 
            
            
            foreach (var item in data)
            {
                inv_no = item.invoice_no;
                 invoiceData = _context.Invoices.Where(d => d.Invoice_no == item.invoice_no).FirstOrDefault();
                invoiceData.Customer_ID = _context.Customers.Where(d => d.Customer_Name == item.customer_Name).Select(d => d.Customer_ID).FirstOrDefault();
                invoiceData.Invoice_Date = item.invoice_Date;
                invoiceData.Invoice_TotalPrice = item.invoice_TotalPrice;
                invoiceData.Invoice_TotalQty = item.invoice_TotalQty;
                
            }
            if (invoiceData != null )
            {
                _context.Invoices.Update(invoiceData);
                _context.SaveChanges();



                var oldData = _context.InvoiceDetails.Where(d => d.Invoice_no == inv_no).ToList();
                foreach (var item in oldData)
                {
                    _context.InvoiceDetails.Remove(item);
                    _context.SaveChanges();
                }
                foreach (var item in data)
                {
                    inv_Details = new InvoiceDetails()
                    {
                        Quantity = item.quantity,
                        totalPrice = item.totalPrice,
                        Item_Name = item.item_Name,
                        Invoice_no = inv_no
                    };
                    if (inv_Details != null)
                    {
                        _context.InvoiceDetails.Add(inv_Details);
                        _context.SaveChanges();
                    }
                }
                return "true";
            }
            else
            {
                return "false";
            }

            //foreach (var item in data)
            //{
            //    InvoiceDetails invoiceDetails;
            //    invoiceDetails = _context.InvoiceDetails.Where(d => d.Invoice_no == item.invoice_no).FirstOrDefault();
            //    invoiceDetails.Item_Name = item.item_Name;
            //    invoiceDetails.Quantity = item.quantity;
            //    _context.InvoiceDetails.Update(invoiceDetails);

            //}
            //_context.SaveChanges();

           
        }

        //POST: api/InvoicesData
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPost]
        public async Task<ActionResult<string>> PostInvoice(invoice_DataType[] data)
        {
            string result = "true";
            

            foreach (var item in data)
            {
                int cust_id = _context.Customers.Where(d => d.Customer_Name == item.customer_Name).Select(d => d.Customer_ID).FirstOrDefault();
                inv = new Invoice()
                {
                    Invoice_no= item.invoice_no,
                    Invoice_Date = item.invoice_Date,
                    Invoice_TotalQty = item.invoice_TotalQty,
                    Invoice_TotalPrice = item.invoice_TotalPrice,
                    Customer_ID = cust_id
                };
                //inv_Details = new InvoiceDetails()
                //{
                //    Quantity = item.quantity,
                //    totalPrice = item.totalPrice,
                //    Item_Name = item.item_Name,
                //    Invoice_no = item.invoice_no
                //};
                //_context.Invoices.Add(inv);
                //_context.InvoiceDetails.Add(inv_Details);
                //_context.SaveChanges();
            }
            if (inv != null && inv.Customer_ID!=0  )
            {
                _context.Invoices.Add(inv);
                _context.SaveChanges();
                foreach (var item in data)
                {
                    inv_Details = new InvoiceDetails()
                    {
                        Quantity = item.quantity,
                        totalPrice = item.totalPrice,
                        Item_Name = item.item_Name,
                        Invoice_no = inv.Invoice_no
                    };
                    if (inv_Details != null)
                    {
                        _context.InvoiceDetails.Add(inv_Details);
                        _context.SaveChanges();
                    }
                }
            }
            else {
                result = "false";
            }
            //inv = new Invoice()
            //{

            //    Invoice_Date = DateTime.Now,
            //    Invoice_TotalQty = 50,
            //    Invoice_TotalPrice = 100,
            //    Customer_ID = 2
            //};

            return result;
        }

        // DELETE: api/InvoicesData/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return "false";
            }

            _context.Invoices.Remove(invoice);
             _context.SaveChanges();
            var invoiceDetails = _context.InvoiceDetails.Where(d => d.Invoice_no == id).ToList();
            foreach (var item in invoiceDetails)
            {
                _context.InvoiceDetails.Remove(item);
                _context.SaveChanges();
            }
            return "true";
        }

        //private bool InvoiceExists(int id)
        //{
        //    return _context.Invoices.Any(e => e.Invoice_no == id);
        //}
    }
}
