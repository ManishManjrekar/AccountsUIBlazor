using AccontApi.Core;
using AccountApi.Core;
using AccountApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface ISalesRepository : IRepository<Sales>
    {
        public Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerStockInId(int stockInId);
        public Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerCustomerId(int customerId);

        public Task<IReadOnlyList<SalesDetails>> GetSalesDataAsperDate(string selectedDate);
        Task<int> GetSales_Sum_Per_StockInId(int stockInId);
        Task<int> GetSales_Sum_Per_Date(string selectedDate);

        Task<int> GetSales_Sum_Between_Dates(string fromDate, string toDate);
        Task<int> GetCommission_for_Sales_AsPer_PercentageValue(int PercentageCommission, int stockInId);

    }
}
