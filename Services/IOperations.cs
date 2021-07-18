using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOperations<T>
    {
        T Add(T std);
        List<T> GetALL();
        bool Delete(int id);
        T Edit(T std);
        T Getbyid(int id);
    }
}
