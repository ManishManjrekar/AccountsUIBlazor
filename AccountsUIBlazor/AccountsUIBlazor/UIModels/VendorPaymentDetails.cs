using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsUIBlazor.UIModels
{
    public class UIVendorPaymentDto
    {
        public int VendorPaymentId { get; set; }
        public string VendorName { get; set; }
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

    public class VendorPaymentMaster
    {
        public List<SalesDetailsDto> SalesDetailsList { get; set; }
        public List<UIVendorPaymentDto> VendorPaymentList { get; set; }

        public List<UIVendorPaymentDto> VendorPaymentExpensesList { get; set; }

        public int TotalSalesAmount { get; set; }

        public int TotalVendorPaymentPaid { get; set; }

        public int BalanceAmount { get; set; }

    }

}
