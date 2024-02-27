using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class VendorPayments
    {
        //public int VendorPaymentId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public string TypeOfTransaction { get; set; }
      
        public int AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

    }
}
