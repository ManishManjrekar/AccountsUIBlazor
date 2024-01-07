using AccontApi.Core;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountApi.Sql.Queries;
using AccountApi.Application.Interfaces;
using AccountApi.Core;
using AccountApi.Core.Entities;

namespace AccountApi.Infrastructure.Repository
{
    public class CommissionAgentExpensesRepository : ICommissionAgentExpensesRepository
    {

        private readonly IConfiguration configuration;
       
        public CommissionAgentExpensesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CommissionAgentExpenses>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentExpenses>(CommissionAgentExpensesQueries.GetAllCommissionAgentExpenses);
                return result.ToList();
            }
        }

        public async Task<CommissionAgentExpenses> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentExpenses>(CommissionAgentExpensesQueries.GetAllCommissionAgentExpenses_ByStockInId, new { StockInId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CommissionAgentExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionAgentExpensesQueries.AddCommissionAgentExpenses, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(CommissionAgentExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionAgentExpensesQueries.UpdateCommissionAgentExpenses, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionAgentExpensesQueries.DeleteCommissionAgentExpenses, new { CommissionAgentExpensesId = id });
                return result.ToString();
            }
        }

       

    }
}
