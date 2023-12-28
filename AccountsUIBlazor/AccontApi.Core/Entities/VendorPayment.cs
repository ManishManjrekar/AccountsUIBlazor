using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class VendorPayment
    {
        public int VendorPaymentId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public string TypeOfTransaction { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Comments { get; set; }

    }
}
