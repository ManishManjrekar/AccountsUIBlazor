using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IVendorRepository Vendor { get; }
        ISalesRepository Sales { get; }
        ICommissionAgentExpensesRepository CommissionAgentExpenses { get; }
        ICommissionAgentPercentageRepository CommissionAgentPercentage { get; }
        ICustomerPaymentReceivedRepository CustomerPaymentReceived { get; }
        IExpensesTypesRepository ExpensesTypes { get; }
        IStockInRepository StockIn { get; }
        IVendorExpensesRepository VendorExpenses { get; }
        IVendorPaymentRepository VendorPayment { get; }

        ICustomerBalanceCarryForwardRepository CustomerBalanceCarryForward { get; }
        ICommissionEarnedRepository CommissionEarned { get; }

    }
}
