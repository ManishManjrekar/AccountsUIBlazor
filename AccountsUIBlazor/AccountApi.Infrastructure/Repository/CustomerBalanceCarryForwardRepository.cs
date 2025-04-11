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
                var result = await connection.QueryAsync<CustomerBalanceCarryForward>(Constants.AllCustomerBalanceCarryForward);
                return result.ToList();
            }
        }

        public async Task<CustomerBalanceCarryForward> GetByIdAsync(long id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@CustomerId", id);

                    // If using stored procedure:
                    var result = await connection.QuerySingleOrDefaultAsync<CustomerBalanceCarryForward>("GetBalanceCarryForwardBy_CustomerId", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching customer balance: {ex.Message}");
                throw;
            }
        }


        //public async Task<CustomerBalanceCarryForward> GetByIdAsync(long id)
        //{
        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.QuerySingleOrDefaultAsync<CustomerBalanceCarryForward>(Constants.GetBalanceCarryForwardBy_CustomerId, new { CustomerId = id });
        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }

        //}

        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCarrryForwardDataByCustomerId(long id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CustomerId",id);
                    var result = await connection.QueryAsync<CustomerBalanceCarryForward>("GetBalanceCarryForwardBy_CustomerId", parameters, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving balance carry forward: {ex.Message}");
                throw;
            }
        

        }
        //public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCarrryForwardDataByCustomerId(long id)
        //{
        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.QueryAsync<CustomerBalanceCarryForward>(Constants.GetBalanceCarryForwardBy_CustomerId, new { CustomerId = id });
        //            return result.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }

        //}

        public async Task<string> AddAsync(CustomerBalanceCarryForward entity)
        {
            {
                try
                {
                    entity.CreatedBy = "System";
                    entity.LoggedInUser = "System";
                    entity.ModifiedDate = DateTime.Now;
                    entity.IsActive = true;

                    var parameters = new DynamicParameters();
                    parameters.Add("@CustomerId", entity.CustomerId);
                    parameters.Add("@CustomerName", entity.CustomerName);
                    parameters.Add("@Amount", entity.Amount);
                    parameters.Add("@CreatedDate", DateTime.Now); 
                    parameters.Add("@ModifiedDate", entity.ModifiedDate);
                    parameters.Add("@IsActive", entity.IsActive);
                    parameters.Add("@CreatedBy", entity.CreatedBy);
                    parameters.Add("@ModifiedBy", entity.ModifiedDate); 
                    parameters.Add("@LoggedInUser", entity.LoggedInUser);
                    parameters.Add("@Comments", entity.Comments);

                    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync("AddCustomerBalanceCarryForward", parameters, commandType: CommandType.StoredProcedure);
                        return result.ToString();
                        //return result > 0 ? "Success" : "Failed";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in AddAsync: {ex.Message}");
                    throw;
                }
            }

        }
        //public async Task<string> AddAsync(CustomerBalanceCarryForward entity)
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
        //            var result = await connection.ExecuteAsync(Constants.AddCustomerBalanceCarryForward, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        public async Task<string> UpdateAsync(CustomerBalanceCarryForward entity)
        {
          
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerBalanceCarryForwardId", entity.CustomerBalanceCarryForwardId);
                parameters.Add("@CustomerId", entity.CustomerId);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@Amount", entity.Amount);
                parameters.Add("@CreatedDate", entity.CreatedDate);
                parameters.Add("@ModifiedDate", DateTime.Now);
                parameters.Add("@IsActive", entity.IsActive);
                parameters.Add("@CreatedBy", entity.CreatedBy);
                parameters.Add("@ModifiedBy", entity.ModifiedBy); 
                parameters.Add("@LoggedInUser", entity.LoggedInUser);
                parameters.Add("@Comments", entity.Comments);

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync("UpdateCustomerBalanceCarryForward",parameters,commandType: CommandType.StoredProcedure);
                    return result.ToString();                    
                }
            }
            catch (Exception ex)
            { 
                   
                Console.WriteLine($"Update failed: {ex.Message}");
                throw;
            }
        }

        //public async Task<string> UpdateAsync(CustomerBalanceCarryForward entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateCustomerBalanceCarryForward, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerBalanceCarryForwardId", id);

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var result = await connection.ExecuteAsync("DeleteCustomerBalanceCarryForward", parameters, commandType: CommandType.StoredProcedure);
                    return result > 0 ? "Deleted Successfully (Soft Delete)" : "No Record Found";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteCustomerBalanceCarryForward, new { CustomerId = id });
        //        return result.ToString();
        //    }
        //}

        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCommisionEarnedForADate(string selectedDate)
        {
            try
            {
           
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate", selectedDate);

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var result = await connection.QueryAsync<CustomerBalanceCarryForward>("GetCustomerBalanceCarry_ByDate",parameters,commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
        //public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCommisionEarnedForADate(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CustomerBalanceCarryForward>(Constants.GetCustomerBalanceCarry_ByDate, new { CreatedDate = selectedDate });
        //        return result.ToList();
        //    }
        //}

    }
}
