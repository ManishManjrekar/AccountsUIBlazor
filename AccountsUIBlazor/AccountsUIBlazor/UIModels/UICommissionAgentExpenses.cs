namespace AccountsUIBlazor.UIModels
{
    public class UICommissionAgentExpenses
    {
       
        public UICommissionAgentExpenses()
        {
            CommissionAgentExpensesTypes = new CommissionAgentExpensesTypes();
            

        }
            public int CommissionAgentExpensesId { get; set; }
            //public int StockInId { get; set; }
            public decimal AmountPaid { get; set; }
            public DateTime CreatedDate { get; set; }
            public CommissionAgentExpensesTypes CommissionAgentExpensesTypes { get; set; }
           // public List<UICommissionAgentExpenses> CommissionAgentExpensesList { get; set; }


    }

   
    public enum CommissionAgentExpensesTypes
    {
        Electricity,
        Water,
        WorkerSalary,
        MiscellaneousExpenses

    }
       
   
    public class CommissionExpensesDetailsGrid
    {
        public decimal AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public CommissionAgentExpensesTypes CommissionAgentExpensesTypes { get; set; }
    }
}
