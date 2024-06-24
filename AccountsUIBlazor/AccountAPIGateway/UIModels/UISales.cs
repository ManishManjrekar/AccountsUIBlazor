using System.ComponentModel.DataAnnotations;

namespace AccountAPIGateway.UIModels
{
    public class UISales
    {
        public UISales()
        {
            UICalenderModel = new UICalenderModel();
            UIStockInList = new List<UIStockInItem>();
            UISalesPostDataModel = new UISalesPostDataModel();
            UICustomerNamesList = new List<UICustomerNames>();
        }

        public List<UIStockInItem> UIStockInList { get; set; }
        public List<UICustomerNames> UICustomerNamesList { get; set; }

        public UISalesPostDataModel UISalesPostDataModel { get; set; }
        //[Required]
        public UIStockIn StockIn { get; set; }
        public UICalenderModel UICalenderModel { get; set; }
        public UISalesStockInData UISalesStockInData { get; set; }

      

    }

    public class UISalesStockInData
    {
        public string VendorName { get; set; }

        public string LoadName { get; set; }
        public int StockInId { get; set; }
        public int CustomerId { get; set; }

        public int VendorId { get; set; }

        public int Quantity { get; set; }
    }
    public enum SaleType
    {
        OnPrice,
        Tol
    }
    public class UISalesPostDataModel
    {
        public string LoadName { get; set; }
        public int StockInId { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
        public SaleType Type { get; set; }

        public DateTime CreatedDate { get; set; }

    }

    public class UIStockInItem
    {
        public string LoadName { get; set; }
        public int StockInId { get; set; }
    }

    public class SalesDetailsDto
    {
        public int SalesId { get; set; }
        public int VendorId { get; set; }
        public int StockInId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalAmount { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public string VendorName { get; set; }
        public string LoadName { get; set; }
        public DateTime CreatedDate { get; set; }


    }

    public class UISalesDto
    {
        public List<SalesDetailsDto> salesDetailsList { get; set; }

        public int TotalStock { get; set; }
        public int TotalSalesDone { get; set; }
        public int TotalStockLeft { get; set; }
    }
}
