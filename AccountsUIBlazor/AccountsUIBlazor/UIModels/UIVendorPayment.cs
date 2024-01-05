namespace AccountsUIBlazor.UIModels
{
    public class UIVendorPayment
    {
        public UIVendorPayment()
        {
            VendorList = new List<VendorList>();
            StockInList = new List<StockInList>();
            UICalenderModel = new UIVendorCalenderModel();

        }
        public List<VendorList> VendorList { get; set; }
        public List<StockInList> StockInList { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }
        public UIVendorCalenderModel UICalenderModel { get; set; }
        public TypeOfTransaction TypeOfTransaction { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Comments { get; set; }
    }
    
    public class VendorList
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
    }
    public class StockInList
    {
        public int StockInId { get; set; }
        public string LoadName { get; set; }
    }

    public class UIVendorCalenderModel
    {
        //[Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int VendorId { get; set; }

    }
}
