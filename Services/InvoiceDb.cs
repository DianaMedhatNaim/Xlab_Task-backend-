using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InvoiceDb : IOperations<Invoice>
    {
        private SalesContext _db;

        public InvoiceDb(SalesContext db)
        {
            _db = db;
        }

        Invoice IOperations<Invoice>.Add(Invoice std)
        {
            throw new NotImplementedException();
        }

        bool IOperations<Invoice>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Invoice IOperations<Invoice>.Edit(Invoice std)
        {
            throw new NotImplementedException();
        }

        List<Invoice> IOperations<Invoice>.GetALL()
        {
            return _db.Invoices.Include(d => d.Customer).ToList();
        }

        Invoice IOperations<Invoice>.Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
