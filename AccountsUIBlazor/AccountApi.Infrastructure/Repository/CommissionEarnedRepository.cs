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
using static Dapper.SqlMapper;

namespace AccountApi.Infrastructure.Repository
{
    public class CommissionEarnedRepository : ICommissionEarnedRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public CommissionEarnedRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<CommissionEarned>> GetAllAsync()
        {
           // using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionEarned>(Constants.GetAllCommissionEarned);
                return result.ToList();
            }
        }

        public async Task<CommissionEarned> GetByIdAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<CommissionEarned>(Constants.GetAllCommissionEarned_ByStockInId, parameters,commandType: CommandType.StoredProcedure );
                connection.Close();
                return result;            
        }
        public async Task<string> AddAsync(CommissionEarned entity)
        {
            try
            {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@VendorId", entity.VendorId);
                    parameters.Add("@StockInId", entity.StockInId);
                    parameters.Add("@CommissionPercentage", entity.CommissionPercentage);
                    parameters.Add("@LoadName", entity.LoadName);
                    parameters.Add("@VendorName", entity.VendorName);
                    parameters.Add("@Amount", entity.Amount);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@ModifiedDate", entity.ModifiedDate);
                    parameters.Add("@LoggedInUser", entity.LoggedInUser);
                    parameters.Add("@Comments", entity.Comments);
                    parameters.Add("@IsActive", entity.IsActive);
                    var result = await connection.ExecuteAsync(Constants.AddCommissionEarned, parameters, commandType: CommandType.StoredProcedure);
                    connection.Open();
                    return result.ToString();                
            }
                    catch (Exception)
            {
                    throw;
            }
        }

        public async Task<string> UpdateAsync(CommissionEarned entity)
        {
            try
            {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CommissionEarnedId", entity.CommissionEarnedId);
                    parameters.Add("@VendorId", entity.VendorId);
                    parameters.Add("@StockInId", entity.StockInId);
                    parameters.Add("@CommissionPercentage", entity.CommissionPercentage);
                    parameters.Add("@LoadName", entity.LoadName);
                    parameters.Add("@VendorName", entity.VendorName);
                    parameters.Add("@Amount", entity.Amount);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@ModifiedDate", entity.ModifiedDate);
                    parameters.Add("@LoggedInUser", entity.LoggedInUser);
                    parameters.Add("@Comments", entity.Comments);
                    parameters.Add("@IsActive", entity.IsActive);
                    var result = await connection.ExecuteAsync(Constants.UpdateCommissionEarned, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToString();
            }
            catch (Exception)
            {
                    throw;
            }
        }
        public async Task<string> DeleteAsync(long id)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionEarnedId", id, DbType.Int64);
                var result = await connection.ExecuteAsync(Constants.DeleteCommissionEarned, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            { 
                    throw;
            }
        }
        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_ForA_Date(string selectedDate)
        {
                try
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CreatedDate", selectedDate.ToString(), DbType.Date);
                    var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_BySelectedDate, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToList();
                }
                catch (Exception ex)
                {
                        Console.WriteLine(ex.Message);
                        throw;
                }
            }
        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_Between_Dates(string fromDate, string toDate)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@fromDate", fromDate.ToString(), DbType.Date);
                parameters.Add("@toDate", toDate.ToString(), DbType.Date);
                var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_Between_Dates, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<int> GetCommisionEarnedSum_ForA_Date(string selectedDate)
        {
            try
            {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CreatedDate", selectedDate.ToString(), DbType.Date);
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_BySelectedDate, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<int> GetCommisionEarnedSum_Between_Dates(string fromDate, string toDate)
        {
            try
            {
                    connection.Close();
                    var parameters = new DynamicParameters();
                    parameters.Add("@fromDate", fromDate.ToString(), DbType.Date);
                    parameters.Add("@fromDate", toDate.ToString(), DbType.Date);
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_Between_Dates, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result;                
            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
                    throw;
            }
        }
    }
}
