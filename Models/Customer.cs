using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public virtual List<Invoice> Invoice { get; set; }
    }
}
