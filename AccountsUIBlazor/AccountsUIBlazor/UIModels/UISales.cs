﻿using System.ComponentModel.DataAnnotations;

namespace AccountsUIBlazor.UIModels
{
    public class UISales
    {
        public UISales()
        {
            UICalenderModel = new UICalenderModel();
            UIStockInList = new List<UIStockInItem>();
            UISalesPostDataModel = new UISalesPostDataModel();
        }
        public List<UIStockInItem> UIStockInList { get; set; }
        public UISalesPostDataModel UISalesPostDataModel { get; set; }
        //[Required]
        public UIStockIn StockIn { get; set; }
        public UICalenderModel UICalenderModel { get; set; }
        public UISalesStockInData UISalesStockInData { get; set; }


    }

    public class UISalesStockInData
    {
        public string LoadName { get; set; }
        public int StockInId { get; set; }
        public int VendorId { get; set; }

        public int Quantity { get; set; }
    }

    public class UISalesPostDataModel
    {
        public string LoadName { get; set; }
        public int StockInId { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
       
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
        public int Total { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }
        public string VendorName { get; set; }
        public string LoadName { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
