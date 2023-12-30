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
    public class StockInRepository : IStockInRepository
    {

        private readonly IConfiguration configuration;
       
        public StockInRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<StockIn>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(StockInQueries.AllStockIn);
                return result.ToList();
            }
        }

        public async Task<StockIn> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<StockIn>(StockInQueries.StockInById, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(StockIn entity)
        {
            entity.isActive = true;
            entity.CreatedBy = "System";
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsPaymentDone = false;
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(StockInQueries.AddStockIn, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<string> UpdateAsync(StockIn entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(StockInQueries.UpdateStockIn, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(StockInQueries.DeleteStockIn, new { CustomerId = id });
                return result.ToString();
            }
        }


        public async Task<int> GetVendorLoadCount(int VendorId, string createdDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(StockInQueries.GetVendorLoadCount, new { VendorId, createdDate });
                return result;
            }
        }

        public async Task<IReadOnlyList<StockIn>> GetStockInDataAsperDates(string fromDate, string toDate, int VendorId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(StockInQueries.GetStockInAsPerVendorId, new { VendorId, fromDate, toDate, });
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<StockIn>> GetStockInAsperDates(string fromDate, string toDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(StockInQueries.GetStockInAsPerDates, new { fromDate, toDate, });
                return result.ToList();
            }
        }


    }
}
