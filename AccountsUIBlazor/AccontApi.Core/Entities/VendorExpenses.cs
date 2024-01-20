using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class VendorExpenses
    {
        public int VendorExpensesId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public string ExpensesName { get; set; }
        public string LoadName { get; set; }
        public string VendorName { get; set; }

        public int AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }


    }
}
