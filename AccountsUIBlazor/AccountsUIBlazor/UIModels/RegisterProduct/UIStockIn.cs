using AccountApi.Core;

namespace AccountsUIBlazor.UIModels
{
    public class UIStockIn
    {
        public int StockInId { get; set; }

        public UIStockIn()
        {
            VendorNames = new List<VendorNames>();
        }
        public List<VendorNames> VendorNames { get; set; }
        public int VendorId { get; set; }
        public string  LoadName { get; set; }

        public string VendorName { get; set; }


        public int Quantity { get; set; }
       // public List<Vendor> VendorList { get; set; }
        // public DateTime FromDate { get; set; }
         public DateTime CreatedDate { get; set; }
    }
}
