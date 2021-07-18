using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceDetails_ID { get; set; }
        public int Quantity { get; set; }
        public int totalPrice { get; set; }
        [ForeignKey("ItemDetails")]
        public string Item_Name { get; set; }
        public virtual Items ItemDetails { get; set; }
        [ForeignKey("Invoice")]
        public int Invoice_no { get; set; }
        public virtual Invoice Invoice { get; set; }
        
    }
}
