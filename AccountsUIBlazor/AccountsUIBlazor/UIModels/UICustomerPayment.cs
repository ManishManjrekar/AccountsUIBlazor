namespace AccountsUIBlazor.UIModels
{
    public class UICustomerPayment
    {
        public List<UICustomerNames> CustomerList { get; set; }
        public int CustomerId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public TypeOfTransaction TypeOfTransaction { get; set; }
        public string Comments { get; set; }
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
}
