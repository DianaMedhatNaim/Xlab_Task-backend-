using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Invoice_no { get; set; }
        public DateTime Invoice_Date { get; set; }
        public int Invoice_TotalQty { get; set; }
        public int Invoice_TotalPrice { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }
        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
