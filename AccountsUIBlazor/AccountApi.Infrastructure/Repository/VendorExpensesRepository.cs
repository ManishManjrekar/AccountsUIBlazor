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
    public class VendorExpensesRepository : IVendorExpensesRepository
    {

        private readonly IConfiguration configuration;
       
        public VendorExpensesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorExpenses>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorExpenses>(VendorExpensesQueries.GetAllVendorExpenses);
                return result.ToList();
            }
        }

        public async Task<VendorExpenses> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<VendorExpenses>(VendorExpensesQueries.GetAllVendorExpenses_ByStockInId, new { StockInId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(VendorExpenses entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(VendorExpensesQueries.AddVendorExpenses, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<string> UpdateAsync(VendorExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorExpensesQueries.UpdateVendorExpenses, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorExpensesQueries.DeleteVendorExpenses, new { CustomerId = id });
                return result.ToString();
            }
        }

        public async Task<IReadOnlyList<VendorExpenses>> GetCommissionAgentExpensesForADate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorExpenses>(VendorExpensesQueries.GetVendorExpenses_ByDate, new { CreatedDate = selectedDate });
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<VendorExpenses>> GetVendorExpensesByStockInId(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorExpenses>(VendorExpensesQueries.GetAllVendorExpenses_ByStockInId, new { StockInId = id });
                return result.ToList();
            }
        }
    }
}
