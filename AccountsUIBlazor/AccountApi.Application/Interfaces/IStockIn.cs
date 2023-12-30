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
    public interface IStockInRepository : IRepository<StockIn>
    {
        Task<int> GetVendorLoadCount(int vendorid, string createdDate);
        Task<IReadOnlyList<StockIn>> GetStockInDataAsperDates(string fromDate, string toDate, int VendorId);
        Task<IReadOnlyList<StockIn>> GetStockInAsperDates(string fromDate, string toDate);
    }
}
