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
    public class VendorExpensesPaymentRepository : IVendorExpensesPaymentRepository
    {

        private readonly IConfiguration configuration;
       
        public VendorExpensesPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorExpensesPayment>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorExpensesPayment>(VendorExpensesPaymentQueries.GetAllVendorExpensesPayment);
                return result.ToList();
            }
        }

        public async Task<VendorExpensesPayment> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<VendorExpensesPayment>(VendorExpensesPaymentQueries.GetAllVendorExpensesPayment_ByStockInId, new { StockInId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(VendorExpensesPayment entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorExpensesPaymentQueries.AddVendorExpensesPayment, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(VendorExpensesPayment entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorExpensesPaymentQueries.UpdateVendorExpensesPayment, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorExpensesPaymentQueries.DeleteVendorExpensesPayment, new { CustomerId = id });
                return result.ToString();
            }
        }

       

    }
}
