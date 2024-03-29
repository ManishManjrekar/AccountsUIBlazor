﻿using AccontApi.Core;
using AccountApi.Core;
using AccountApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface ICustomerBalanceCarryForwardRepository : IRepository<CustomerBalanceCarryForward>
    {
        Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCarrryForwardDataByCustomerId(long id);


    }
}
