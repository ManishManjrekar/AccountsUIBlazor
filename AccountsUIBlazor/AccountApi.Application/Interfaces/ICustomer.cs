using AccontApi.Core;
using AccountApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> GetDuplicateOrNot(string firstName, string lastName);
    }
}
