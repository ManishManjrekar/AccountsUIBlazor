namespace AccountAPIGateway.UIModels
{
    public class MasterCustomerBalanceCarryForwardGridData
    {
        public List<UICustomerBalanceCarryForwardGridData> CarryForwardAmountList { get; set; }
    }
    public class UICustomerBalanceCarryForwardGridData
    {
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
    }


    public class UICustomerBalanceCarryForward
    {
        public List<UICustomerNames> CustomerList { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
    }
}
