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
    public class CustomerPaymentReceivedRepository : ICustomerPaymentReceivedRepository
    {

        private readonly IConfiguration configuration;
       
        public CustomerPaymentReceivedRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CustomerPaymentReceived>(CustomerPaymentQueries.AllCustomerPaymentReceived);
                return result.ToList();
            }
        }

        public async Task<CustomerPaymentReceived> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<CustomerPaymentReceived>(CustomerPaymentQueries.GetCPRByCustomerPaymentId, new { GetCPRByCustomerPaymentId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CustomerPaymentReceived entity)
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
                    var result = await connection.ExecuteAsync(CustomerPaymentQueries.AddCustomerPayment, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<string> UpdateAsync(CustomerPaymentReceived entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerPaymentQueries.UpdateCustomerPayment, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerPaymentQueries.DeleteCustomerPaymentReceived, new { CustomerId = id });
                return result.ToString();
            }
        }

        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByCustomerId(int customerId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CustomerPaymentReceived>(CustomerPaymentQueries.GetCustomerPaymentReceivedByCustomerId, new { CustomerId = customerId });
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByDate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CustomerPaymentReceived>(CustomerPaymentQueries.GetCustomerPaymentReceivedByDate, new { PaymentDate = selectedDate });
                return result.ToList();
            }
        }

    }
}
