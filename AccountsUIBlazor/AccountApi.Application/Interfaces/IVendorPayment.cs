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
    public interface IVendorPaymentRepository : IRepository<VendorPayments>
    {
        public Task<IReadOnlyList<VendorPaymentDetails>> GetVendorPaymentAsPerStockInId(long stockInId);
    }
}
