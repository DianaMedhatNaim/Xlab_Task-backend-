
using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class InvoiceDetailsDb : IOperations<InvoiceDetails>
    {
        private SalesContext _db;

        public InvoiceDetailsDb(SalesContext db)
        {
            _db = db;
        }
        InvoiceDetails IOperations<InvoiceDetails>.Add(InvoiceDetails std)
        {
            throw new NotImplementedException();
        }

        bool IOperations<InvoiceDetails>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        InvoiceDetails IOperations<InvoiceDetails>.Edit(InvoiceDetails std)
        {
            throw new NotImplementedException();
        }

        List<InvoiceDetails> IOperations<InvoiceDetails>.GetALL()
        {
           return _db.InvoiceDetails.Include(d => d.ItemDetails).ToList();
        }

        InvoiceDetails IOperations<InvoiceDetails>.Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
