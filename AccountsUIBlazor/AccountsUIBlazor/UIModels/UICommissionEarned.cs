namespace AccountsUIBlazor.UIModels
{
    public class UICommissionEarned
    {
        public UICalenderModel UICalenderModel { get; set; }
        public List<UICommissionEarnedGridDetails> UICommissionEarnedList { get; set; }

        public int CommissionEarned_Sum { get; set; }

        public UICommissionEarned() {
            UICalenderModel = new UICalenderModel();
            UICommissionEarnedList = new List<UICommissionEarnedGridDetails>();
        }


    }
    public class UICommissionEarnedMaster
    {
        public List<UICommissionEarnedGridDetails> UICommissionEarnedList { get; set; }

        public int CommissionEarned_Sum { get; set; }
    }
    public class UICommissionEarnedGridDetails
    {
        public int CommissionEarnedId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int CommissionPercentage { get; set; }

        public string LoadName { get; set; }
        public string VendorName { get; set; }

        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LoggedInUser { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }

    }
}
