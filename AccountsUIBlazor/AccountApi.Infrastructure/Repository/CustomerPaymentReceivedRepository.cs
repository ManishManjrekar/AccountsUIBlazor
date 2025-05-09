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
        private readonly SqlConnection connection;
       
        public CustomerPaymentReceivedRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));

        }

        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetAllAsync()
        {           
                connection.Open();
                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.AllCustomerPaymentReceived);
                connection.Close();
                return result.ToList();            
        }
        public async Task<CustomerPaymentReceived> GetByIdAsync(long id)
        {          
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerPaymentId", id);
                var result = await connection.QueryFirstOrDefaultAsync<CustomerPaymentReceived>(Constants.GetCPRByCustomerPaymentId, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
            
        }
        public async Task<string> AddAsync(CustomerPaymentReceived entity)
        {
            try
            {
                entity.CreatedBy = "System";
                entity.LoggedInUser = "System";
                entity.ModifiedDate = DateTime.Now;
                entity.IsActive = true;
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CustomerId", entity.CustomerId);
                    parameters.Add("@CustomerName", entity.CustomerName);
                    parameters.Add("@TypeOfTransaction", entity.TypeOfTransaction);
                    parameters.Add("@AmountPaid", entity.AmountPaid);
                    parameters.Add("@PaymentDate", entity.PaymentDate);
                    parameters.Add("@ModifiedDate", entity.ModifiedDate);
                    parameters.Add("@IsActive", entity.IsActive);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    parameters.Add("@ModifiedBy", entity.ModifiedBy);
                    parameters.Add("@LoggedInUser", entity.LoggedInUser);
                    parameters.Add("@Comments", entity.Comments);
                    var result = await connection.ExecuteAsync(Constants.AddCustomerPayment, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(CustomerPaymentReceived entity)
        {            
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerPaymentId", entity.CustomerPaymentId);
                parameters.Add("@CustomerId", entity.CustomerId);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@AmountPaid", entity.AmountPaid);
                parameters.Add("@PaymentDate", entity.PaymentDate);
                parameters.Add("@ModifiedDate", entity.ModifiedDate);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@LoggedInUser", entity.LoggedInUser);
                parameters.Add("@TypeOfTransaction", entity.TypeOfTransaction);
                parameters.Add("@Comments", entity.Comments);
                var result = await connection.ExecuteAsync(Constants.UpdateCustomerPayment, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString(); 
            
        }
        public async Task<string> DeleteAsync(long id)
        {          
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerPaymentId", id);
                var result = await connection.ExecuteAsync(Constants.DeleteCustomerPaymentReceived, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }
        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByCustomerId(int customerId)
        {          
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customerId);
                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByCustomerId, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();          
        }
        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByDate(string selectedDate)
        {       
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@PaymentDate", Convert.ToDateTime(selectedDate));
                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByDate, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();            
        }
    }
}
