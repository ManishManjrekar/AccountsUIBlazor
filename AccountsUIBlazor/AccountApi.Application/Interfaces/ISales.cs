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
        public Task<List<SalesDetails>> GetSalesDataAsPerStockInId(int stockInId);
        public Task<List<SalesDetails>> GetSalesDataAsPerSalesInId(int customerId);
    }
}
