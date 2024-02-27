namespace AccountApi.Core
{
    public class StockIn
    {
       
        public int StockInId { get; set; }
        public string LoadName { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public bool isActive { get; set; }
        public bool IsPaymentDone { get; set; }
        public string VendorName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
