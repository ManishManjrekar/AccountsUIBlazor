using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public string LoggedInUser { get; set; }

    }
}
