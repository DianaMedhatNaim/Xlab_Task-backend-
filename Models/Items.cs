using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Items
    {
        [Key]
        public string Item_Name { get; set; }
        public int Item_Price { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
