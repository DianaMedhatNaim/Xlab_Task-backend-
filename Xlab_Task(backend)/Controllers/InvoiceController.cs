using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xlab_Task_backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IOperations<Invoice> _context;

        public InvoiceController(IOperations<Invoice> context)
        {
            _context = context;
        }
        [HttpPost]
        public  ActionResult<Invoice> PostDepartment(Invoice cust)
        {
            var data = _context.Add(cust);
            return data;
        }
        [HttpGet()]
        public ActionResult<List<Invoice>> GetInvoice()
        {
            
            var data = _context.GetALL();
            return data;
        }

    }
}
