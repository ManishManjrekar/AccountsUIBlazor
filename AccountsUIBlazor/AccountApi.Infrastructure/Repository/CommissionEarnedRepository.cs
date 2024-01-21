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
    public class CommissionEarnedRepository : ICommissionEarnedRepository
    {

        private readonly IConfiguration configuration;
       
        public CommissionEarnedRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CommissionEarned>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionEarned>(CommissionEarnedQueries.GetAllCommissionEarned);
                return result.ToList();
            }
        }

        public async Task<CommissionEarned> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CommissionEarned>(CommissionEarnedQueries.GetAllCommissionEarned_ByStockInId, new { StockInId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CommissionEarned entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(CommissionEarnedQueries.AddCommissionEarned, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }

        public async Task<string> UpdateAsync(CommissionEarned entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionEarnedQueries.UpdateCommissionEarned, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionEarnedQueries.DeleteCommissionEarned, new { CommissionAgentExpensesId = id });
                return result.ToString();
            }
        }

        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_ForA_Date(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionEarned>(CommissionEarnedQueries.GetCommissionEarned_BySelectedDate, new { CreatedDate = selectedDate });
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_Between_Dates(string fromDate, string toDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionEarned>(CommissionEarnedQueries.GetCommissionEarned_Between_Dates, new { fromDate, toDate });
                return result.ToList();
            }
        }

        public async Task<int> GetCommisionEarnedSum_ForA_Date(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(CommissionEarnedQueries.GetCommissionEarnedSum_BySelectedDate, new { CreatedDate = selectedDate });
                return result;
            }
        }
        public async Task<int> GetCommisionEarnedSum_Between_Dates(string fromDate, string toDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(CommissionEarnedQueries.GetCommissionEarnedSum_Between_Dates, new { fromDate, toDate });
                return result;
            }
        }
    }
}
