using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Core.Entities
{
    public class CommissionAgentExpenses
    {
        public int CommissionAgentExpensesId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public string ElectronicPaymentId { get; set; }
        public string ExpensesName { get; set; }

        //if customer made that payment for convient sake
        public int AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

    }
}
