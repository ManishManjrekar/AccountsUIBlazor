using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Core.Entities
{
    public class SalesDetails
    {
        public int SalesId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalAmount { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public string VendorName { get; set; }
        public string LoadName { get; set; }
        public DateTime CreatedDate { get; set; }
       

    }
}
