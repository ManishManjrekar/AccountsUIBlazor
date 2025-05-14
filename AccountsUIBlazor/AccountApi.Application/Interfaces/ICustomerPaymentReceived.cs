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
    public interface ICustomerPaymentReceivedRepository : IRepository<CustomerPaymentReceived>
    {
        Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByCustomerId(int customerId);
        Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByDate(string selectedDate);

        Task<IReadOnlyList<CustomerPaymentReceived>> GetAllCustomerPaymentByDates(int customerId, DateTime fromDate, DateTime toDate);
    }
}
