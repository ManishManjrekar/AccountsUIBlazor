namespace Accounts.Models.UIModels
{
    public class UICustomerPaymentMaster
    {
        public List<SalesDetailsDto> CustomerPurchases { get; set; }
        public List<UICustomerPayment> CustomerPaymentsDone { get; set; }

        public long BalanceAmountDue { get; set; }
        
    }

   

    public class UICustomerPayment
    {
        // Added
        public UICustomerPayment()
        { 
            CustomerCalenderModel = new UICustomerCalenderModel();
        }
        public List<UICustomerNames> CustomerList { get; set; }
        public int CustomerId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public TypeOfTransaction TypeOfTransaction { get; set; }
        public string Comments { get; set; }

        // Added
        public UICustomerCalenderModel CustomerCalenderModel { get; set; }


    }
    public enum TypeOfTransaction
    {
        Cash,
        Electronic
    }
    public class CustomerList
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

    public class UICustomerPaymentReceived{
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string TypeOfTransaction { get; set; }

        public int AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }

    public class UICustomerCalenderModel
    {
        //[Required]
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int CustomerId { get; set; }

    }
}
