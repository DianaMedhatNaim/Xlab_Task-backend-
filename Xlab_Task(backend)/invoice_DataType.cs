using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xlab_Task_backend_
{
    public class invoice_DataType
    {
        public int invoice_no;
        public string customer_Name;
        public DateTime invoice_Date;
        public string item_Name;
        public int item_Price;
        public int quantity;
        public int invoice_TotalQty;
        public int invoice_TotalPrice;
        public int totalPrice;
    }
}
