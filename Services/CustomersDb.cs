using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomersDb : IOperations<Customer>
    {
        private SalesContext _db;

        public CustomersDb(SalesContext db)
        {
            _db = db;
        }

        Customer IOperations<Customer>.Add(Customer std)
        {
            throw new NotImplementedException();
        }

        bool IOperations<Customer>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Customer IOperations<Customer>.Edit(Customer std)
        {
            throw new NotImplementedException();
        }

        List<Customer> IOperations<Customer>.GetALL()
        {
            return _db.Customers.ToList();
        }

        Customer IOperations<Customer>.Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
