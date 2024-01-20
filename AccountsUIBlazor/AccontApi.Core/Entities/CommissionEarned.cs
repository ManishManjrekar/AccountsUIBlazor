using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Core
{
    public class CommissionEarned
    {
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int CommissionPercentageId { get; set; }

        public string LoadName { get; set; }
        public string VendorName { get; set; }

        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

    }
}
