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
    public interface ICommissionEarnedRepository : IRepository<CommissionEarned>
    {
        Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_ForA_Date(string selectedDate);
        Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_Between_Dates(string fromDate, string toDate);
        Task<int> GetCommisionEarnedSum_ForA_Date(string selectedDate);
        Task<int> GetCommisionEarnedSum_Between_Dates(string fromDate, string toDate);

    }
}
