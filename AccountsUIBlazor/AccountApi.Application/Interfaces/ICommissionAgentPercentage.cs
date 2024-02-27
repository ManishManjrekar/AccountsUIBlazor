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
    public interface ICommissionAgentPercentageRepository : IRepository<CommissionAgentPercentage>
    {
        Task<IReadOnlyList<CommissionAgentPercentage>> GetAllCommissionPercentage();
        Task<int> GetCommissionPercentage_Active();
    }
}
