using System.Numerics;

namespace AccountsUIBlazor.UIModels
{
    public class UICommissionExpenses
    {
        public UICommissionExpenses()
        {

        }
        public  int CommissionAgentExpensesId { get; set; }
        public int  ExpenseId { get; set; }
        public int Amount { get; set; }
        public string CreatedBy { get; set; }
        public List<UIStockInItem> UIStockInList { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CommissionPercentage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StockInId { get; set; }
        public string ExpensesName { get; set; }
        public int VendorId { get; set; }
        public int ElectronicPaymentId { get; set; }
        public int AmountPaid { get; set; }
        public string  LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool  IsActive { get; set; }
        public CommissionExpensesTyps CommissionExpensesTyps { get; set; }
    }

    public enum CommissionExpensesTyps
    {
        ElectricityBill,
        Water,
        WorkerSalary,
        MiscellaneousExpenses
    }

    public class UICommissionExpenses_CommissionPercentage
    {
        public int Sales_Sum { get; set; }
        public int CommissionPercentage { get; set; }

        public int CommissionValue { get; set; }
    }
}
