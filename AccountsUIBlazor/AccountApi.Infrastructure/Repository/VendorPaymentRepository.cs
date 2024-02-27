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
    public class VendorPaymentRepository : IVendorPaymentRepository
    {

        private readonly IConfiguration configuration;
       
        public VendorPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorPayments>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPayments>(VendorPaymentQueries.AllVendorPayment);
                return result.ToList();
            }
        }

        public async Task<VendorPayments> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<VendorPayments>(VendorPaymentQueries.VendorPaymentById, new { VendorPaymentId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(VendorPayments entity)
        {
            entity.IsActive = true;
            entity.ModifiedDate = DateTime.Now;
            
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(VendorPaymentQueries.AddVendorPayment, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<string> UpdateAsync(VendorPayments entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorPaymentQueries.UpdateVendorPayment, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorPaymentQueries.DeleteVendorPayment, new { VendorPaymentId = id });
                return result.ToString();
            }
        }

        public async Task<IReadOnlyList<VendorPaymentDetails>> GetVendorPaymentAsPerStockInId(long stockInId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPaymentDetails>(VendorPaymentQueries.GetVendorPaymentAsPerStockInId, new { StockInId = stockInId });
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<VendorPayments>> GetVendorPaymentsForADate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPayments>(VendorPaymentQueries.GetVendorPayments_ByDate, new { CreatedDate = selectedDate });
                return result.ToList();
            }
        }

    }
}
