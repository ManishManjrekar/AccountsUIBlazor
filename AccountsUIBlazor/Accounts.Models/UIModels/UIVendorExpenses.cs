namespace Accounts.Models.UIModels
{
    public class UIVendorExpenses
    {
        public UIVendorExpenses()
        {
            //UIVendorExpenses_CommissionPercentage = new UIVendorExpenses_CommissionPercentage();
        }
        public int VendorExpensesId { get; set; }
        public List<UIStockInItem> UIStockInList { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }

        public int AmountPaid { get; set; }
        public int CommissionPercentage { get; set; }


        public string LoadName { get; set; }

        public string VendorName { get; set; }
       
        public DateTime CreatedDate { get; set; }
        public VendorExpensesTypes VendorExpensesTypes { get; set; }

       // public UIVendorExpenses_CommissionPercentage UIVendorExpenses_CommissionPercentage { get; set; }


    }

    public enum VendorExpensesTypes
    {
        CommissionAmount,
        Boonsa,
        Chara,
        Motor,
        Dharam
    }

    public class UIVendorExpenses_CommissionPercentage
    {
        public int Sales_Sum { get; set; }
        public int CommissionPercentage { get; set; }

        public int CommissionValue { get; set; }
    }
}
