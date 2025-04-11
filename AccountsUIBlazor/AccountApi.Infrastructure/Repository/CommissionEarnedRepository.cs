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
       
        public CommissionEarnedRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CommissionEarned>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionEarned>(Constants.GetAllCommissionEarned);
                return result.ToList();
            }
        }

        public async Task<CommissionEarned> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<CommissionEarned>(Constants.GetAllCommissionEarned_ByStockInId, parameters,commandType: CommandType.StoredProcedure );
                return result;
            }
        }

        //public async Task<CommissionEarned> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<CommissionEarned>(Constants.GetAllCommissionEarned_ByStockInId, new { StockInId = id });
        //        return result;
        //    }
        //}

        public async Task<string> AddAsync(CommissionEarned entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
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
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        //public async Task<string> AddAsync(CommissionEarned entity)
        //{
        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(Constants.AddCommissionEarned, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }

        //}



        public async Task<string> UpdateAsync(CommissionEarned entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
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
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public async Task<string> UpdateAsync(CommissionEarned entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateCommissionEarned, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CommissionEarnedId", id, DbType.Int64);

                    var result = await connection.ExecuteAsync(Constants.DeleteCommissionEarned, parameters, commandType: CommandType.StoredProcedure);                                      
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteCommissionEarned, new { CommissionAgentExpensesId = id });
        //        return result.ToString();
        //    }
        //}
        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_ForA_Date(string selectedDate)
        {
                try
                {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                        var parameters = new DynamicParameters();
                        parameters.Add("@CreatedDate", selectedDate.ToString(), DbType.Date);

                    var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_BySelectedDate, parameters, commandType: CommandType.StoredProcedure);                                                     
                        return result.ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }



        //public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_ForA_Date(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_BySelectedDate, new { CreatedDate = selectedDate });
        //        return result.ToList();
        //    }
        //}


        public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_Between_Dates(string fromDate, string toDate)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@fromDate", fromDate.ToString(), DbType.Date);
                    parameters.Add("@toDate", toDate.ToString(), DbType.Date);

                   // var result = await connection.QueryAsync<CommissionEarned>("GetCommissionEarned_Between_Dates", parameters, commandType: CommandType.StoredProcedure);
                    var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_Between_Dates, parameters, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        //public async Task<IReadOnlyList<CommissionEarned>> GetCommisionEarnedList_Between_Dates(string fromDate, string toDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CommissionEarned>(Constants.GetCommissionEarned_Between_Dates, new { fromDate, toDate });
        //        return result.ToList();
        //    }
        //}


        public async Task<int> GetCommisionEarnedSum_ForA_Date(string selectedDate)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@CreatedDate", selectedDate.ToString(), DbType.Date);
                    // var result = await connection.ExecuteScalarAsync<int>("GetCommissionEarnedSum_BySelectedDate", parameters, commandType: CommandType.StoredProcedure);
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_BySelectedDate, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        //public async Task<int> GetCommisionEarnedSum_ForA_Date(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_BySelectedDate, new { CreatedDate = selectedDate });
        //        return result;
        //    }
        //}


        public async Task<int> GetCommisionEarnedSum_Between_Dates(string fromDate, string toDate)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@fromDate", fromDate.ToString(), DbType.Date);
                    parameters.Add("@fromDate", toDate.ToString(), DbType.Date);

                   // var result = await connection.ExecuteScalarAsync<int>("GetCommissionEarnedSum_Between_Dates", parameters, commandType: CommandType.StoredProcedure);
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_Between_Dates, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public async Task<int> GetCommisionEarnedSum_Between_Dates(string fromDate, string toDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionEarnedSum_Between_Dates, new { fromDate, toDate });
        //        return result;
        //    }
        //}
    }
}
