using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountApi.Core.Entities;

namespace AccountsUIBlazor.Data
{
    public class AccountsUIBlazorContext : DbContext
    {
        public AccountsUIBlazorContext (DbContextOptions<AccountsUIBlazorContext> options)
            : base(options)
        {
        }

        public DbSet<AccountApi.Core.Entities.CommissionAgentExpenses> CommissionAgentExpenses { get; set; } = default!;
    }
}
