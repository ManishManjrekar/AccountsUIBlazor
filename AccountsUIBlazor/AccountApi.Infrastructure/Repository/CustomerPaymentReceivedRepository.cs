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
                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.AllCustomerPaymentReceived);
                return result.ToList();
            }
        }
        public async Task<CustomerPaymentReceived> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerPaymentId", id);

                var result = await connection.QueryFirstOrDefaultAsync<CustomerPaymentReceived>(Constants.GetCPRByCustomerPaymentId, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        //public async Task<CustomerPaymentReceived> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryFirstOrDefaultAsync<CustomerPaymentReceived>(Constants.GetCPRByCustomerPaymentId, new { GetCPRByCustomerPaymentId = id });
        //        return result;
        //    }
        //}
        public async Task<string> AddAsync(CustomerPaymentReceived entity)
        {
            try
            {
                entity.CreatedBy = "System";
                entity.LoggedInUser = "System";
                entity.ModifiedDate = DateTime.Now;
                entity.IsActive = true;

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
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
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<string> AddAsync(CustomerPaymentReceived entity)
        //{
        //    try
        //    {
        //        entity.CreatedBy = "System";
        //        entity.LoggedInUser = "System";
        //        //entity.PaymentDate = DateTime.Now;
        //        entity.ModifiedDate = DateTime.Now;
        //        entity.IsActive = true;
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(Constants.AddCustomerPayment, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        public async Task<string> UpdateAsync(CustomerPaymentReceived entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
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

                return result.ToString(); 
            }
        }

        //public async Task<string> UpdateAsync(CustomerPaymentReceived entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateCustomerPayment, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerPaymentId", id);

                var result = await connection.ExecuteAsync(Constants.DeleteCustomerPaymentReceived, parameters, commandType: CommandType.StoredProcedure);
                return result.ToString(); 
            }
        }


        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteCustomerPaymentReceived, new { CustomerId = id });
        //        return result.ToString();
        //    }
        //}

        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByCustomerId(int customerId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customerId);

                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByCustomerId, parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }


        //public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByCustomerId(int customerId)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByCustomerId, new { CustomerId = customerId });
        //        return result.ToList();
        //    }
        //}


        public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByDate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@PaymentDate", Convert.ToDateTime(selectedDate));

                var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByDate, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<CustomerPaymentReceived>> GetCustomerPaymentReceivedByDate(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CustomerPaymentReceived>(Constants.GetCustomerPaymentReceivedByDate, new { PaymentDate = selectedDate });
        //        return result.ToList();
        //    }
        //}

    }
}
