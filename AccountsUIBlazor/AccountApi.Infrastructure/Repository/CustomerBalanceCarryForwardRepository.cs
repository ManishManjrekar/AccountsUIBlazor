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
    public class CustomerBalanceCarryForwardRepository : ICustomerBalanceCarryForwardRepository
    {

        private readonly IConfiguration configuration;
       
        public CustomerBalanceCarryForwardRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CustomerBalanceCarryForward>(CustomerBalanceCarryForwardQueries.AllCustomerBalanceCarryForward);
                return result.ToList();
            }
        }

        public async Task<CustomerBalanceCarryForward> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<CustomerBalanceCarryForward>(CustomerBalanceCarryForwardQueries.GetBalanceCarryForwardBy_CustomerId, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CustomerBalanceCarryForward entity)
        {
            try
            {
                entity.CreatedBy = "System";
                entity.LoggedInUser = "System";
                //entity.PaymentDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                entity.IsActive = true;
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(CustomerBalanceCarryForwardQueries.AddCustomerBalanceCarryForward, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<string> UpdateAsync(CustomerBalanceCarryForward entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerBalanceCarryForwardQueries.UpdateCustomerBalanceCarryForward, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerBalanceCarryForwardQueries.DeleteCustomerBalanceCarryForward, new { CustomerId = id });
                return result.ToString();
            }
        }

       

    }
}
