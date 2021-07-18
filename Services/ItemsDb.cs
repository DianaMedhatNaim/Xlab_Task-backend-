using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public  class ItemsDb : IOperations<Items>
    {
        private SalesContext _db;

        public ItemsDb(SalesContext db)
        {
            _db = db;
        }

        Items IOperations<Items>.Add(Items std)
        {
            throw new NotImplementedException();
        }

        bool IOperations<Items>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Items IOperations<Items>.Edit(Items std)
        {
            throw new NotImplementedException();
        }

        List<Items> IOperations<Items>.GetALL()
        {
            return _db.Items.ToList();
        }

        Items IOperations<Items>.Getbyid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
