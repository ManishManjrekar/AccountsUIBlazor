using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class CustomerPaymentReceived
    {
        public int CustomerPaymentId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string TypeOfTransaction { get; set; }

        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }

    }
}
