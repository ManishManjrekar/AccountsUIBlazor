using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class CustomerBalanceCarryForward
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }

    }
}
