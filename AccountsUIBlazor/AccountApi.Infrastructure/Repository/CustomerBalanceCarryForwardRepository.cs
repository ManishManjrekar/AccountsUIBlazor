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
        private readonly SqlConnection connection;
       
        public CustomerBalanceCarryForwardRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetAllAsync()
        {          
            connection.Open();
            var result = await connection.QueryAsync<CustomerBalanceCarryForward>(Constants.AllCustomerBalanceCarryForward);
            connection.Close();
            return result.ToList();           
        }

        public async Task<CustomerBalanceCarryForward> GetByIdAsync(long id)
        {
            try
            {              
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", id);                  
                var result = await connection.QuerySingleOrDefaultAsync<CustomerBalanceCarryForward>(Constants.GetBalanceCarryForwardBy_CustomerId, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                    throw;
            }
        }
        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCarrryForwardDataByCustomerId(long id)
        {
            try
            {              
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CustomerId",id);
                    var result = await connection.QueryAsync<CustomerBalanceCarryForward>("GetBalanceCarryForwardBy_CustomerId", parameters, commandType: CommandType.StoredProcedure);
                    return result.ToList();               
            }
            catch (Exception )
            {                    
                    throw;
            }
        }        
        public async Task<string> AddAsync(CustomerBalanceCarryForward entity)
        {
             try
                {
                    entity.CreatedBy = "System";
                    entity.LoggedInUser = "System";
                    entity.ModifiedDate = DateTime.Now;
                    entity.IsActive = true;
                    connection.Open();
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
                    var result = await connection.ExecuteAsync("AddCustomerBalanceCarryForward", parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToString();                   
             }
             catch (Exception ex)
             {
                    Console.WriteLine($"Error in AddAsync: {ex.Message}");
                    throw;
             }
        }
        public async Task<string> UpdateAsync(CustomerBalanceCarryForward entity)
        {       
            try
            {
                connection.Open();
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
                var result = await connection.ExecuteAsync("UpdateCustomerBalanceCarryForward",parameters,commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();                                   
            }
            catch (Exception ex)
            {                  
                Console.WriteLine($"Update failed: {ex.Message}");
                throw;
            }
        }
        public async Task<string> DeleteAsync(long id)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerBalanceCarryForwardId", id);
                var result = await connection.ExecuteAsync("DeleteCustomerBalanceCarryForward", parameters, commandType: CommandType.StoredProcedure);
                connection.Open();
                return result > 0 ? "Deleted Successfully (Soft Delete)" : "No Record Found";                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IReadOnlyList<CustomerBalanceCarryForward>> GetCommisionEarnedForADate(string selectedDate)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate", selectedDate);
                var result = await connection.QueryAsync<CustomerBalanceCarryForward>("GetCustomerBalanceCarry_ByDate", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
