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
                var result = await connection.QueryAsync<CommissionAgentExpenses>(Constants.GetAllCommissionAgentExpenses);
                return result.ToList();
            }
        }

        public async Task<CommissionAgentExpenses> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentExpenses>(Constants.GetAllCommissionAgentExpenses_ByStockInId, new { StockInId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CommissionAgentExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.AddCommissionAgentExpenses, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(CommissionAgentExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.UpdateCommissionAgentExpenses, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.DeleteCommissionAgentExpenses, new { CommissionAgentExpensesId = id });
                return result.ToString();
            }
        }


        public async Task<IReadOnlyList<CommissionAgentExpenses>> GetCommissionAgentExpensesForADate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentExpenses>(Constants.GetCommissionAgentExpenses_ByDate, new { CreatedDate = selectedDate });
                return result.ToList();
            }
        }
    }
}
