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
    public class SalesRepository : ISalesRepository
    {

        private readonly IConfiguration configuration;
       
        public SalesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<Sales>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                
                connection.Open();
                var result = await connection.QueryAsync<Sales>(SalesQueries.AllSales);
                return result.ToList();
            }
        }

        public async Task<Sales> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Sales>(SalesQueries.SalesById, new { SalesId = id });
                return result;
            }
        }

        

        public async Task<string> AddAsync(Sales entity)
        {
            //entity.Type = "";
            entity.CreatedBy = "System";
            entity.LoggedInUser = "System";
            //entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    //Sales obj = new Sales();
                    connection.Open();
                    var result = await connection.ExecuteAsync(SalesQueries.AddSales, entity);
                    // var result1 = await connection.Add<Sales>(entity);

                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<string> UpdateAsync(Sales entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(SalesQueries.UpdateSales, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(SalesQueries.DeleteSales, new { CustomerId = id });
                return result.ToString();
            }
        }
        
        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerStockInId(int stockInId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<SalesDetails>(SalesQueries.GetSalesDataAsPerStockInId, new { stockInId });
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerCustomerId(int customerId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<SalesDetails>(SalesQueries.GetSalesDataAsPerCustomerId, new { customerId });
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsperDate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<SalesDetails>(SalesQueries.GetSalesDataAsPerDate, new { CreatedDate = selectedDate });
                return result.ToList();
            }
        }


    }
}
