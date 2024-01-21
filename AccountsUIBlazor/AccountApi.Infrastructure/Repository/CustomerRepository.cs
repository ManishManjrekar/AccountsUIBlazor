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

namespace AccountApi.Infrastructure.Repository
{
    public class CustomerRepository: ICustomerRepository
    {

        private readonly IConfiguration configuration;
       
        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Customer>(CustomerQueries.AllCustomer);
                return result.ToList();
            }
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(CustomerQueries.CustomerById, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Customer entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(CustomerQueries.AddCustomer, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<string> UpdateAsync(Customer entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.UpdateCustomer, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.DeleteCustomer, new { CustomerId = id });
                return result.ToString();
            }
        }

        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(CustomerQueries.CheckDuplicateCustomerName, new { firstName, lastName });
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }



    }
}
