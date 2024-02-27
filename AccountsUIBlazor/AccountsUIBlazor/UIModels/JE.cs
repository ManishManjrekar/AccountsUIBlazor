namespace AccountsUIBlazor.UIModels
{
    public class UIJEModel
    {
        public DateTime SelectedDate { get; set; }
        public UIJEMasterDto UIJEMasterDto { get; set; }
    }





    public class UIJEMasterDto
    {
        public List<SalesDetailsDto> JESalesList { get; set; }
        public List<UICustomerPayment> JECustomerPaymentList { get; set; }

        public int TotalStock { get; set; }
        public int TotalSalesCompleted { get; set; }
        public int TotalStockLeft { get; set; }
        public int TotalCustomerPaymentReceived { get; set; }


    }
}
