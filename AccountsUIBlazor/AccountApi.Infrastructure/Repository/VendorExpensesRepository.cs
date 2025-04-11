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
using System.Reflection.Metadata;

namespace AccountApi.Infrastructure.Repository
{
    public class VendorExpensesRepository : IVendorExpensesRepository
    {

        private readonly IConfiguration configuration;
       
        public VendorExpensesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorExpenses>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorExpenses>(Constants.GetAllVendorExpenses);
                return result.ToList();
            }
        }


        public async Task<VendorExpenses> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId,new { StockInId = id },commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        //public async Task<VendorExpenses> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId, new { StockInId = id });
        //        return result;
        //    }
        //}

        public async Task<string> AddAsync(VendorExpenses entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@VendorId", entity.VendorId);
                    parameters.Add("@StockInId", entity.StockInId);
                    parameters.Add("@ExpensesName", entity.ExpensesName);
                    parameters.Add("@VendorName", entity.VendorName);
                    parameters.Add("@LoadName", entity.LoadName);
                    parameters.Add("@AmountPaid", entity.AmountPaid);
                    parameters.Add("@CreatedDate", entity.CreatedDate);
                    parameters.Add("@ModifiedDate", entity.ModifiedDate);
                    parameters.Add("@LoggedInUser", entity.LoggedInUser);
                    parameters.Add("@Comments", entity.Comments);
                    parameters.Add("@IsActive", entity.IsActive);

                    connection.Open();
                    var result = await connection.ExecuteAsync(Constants.AddVendorExpenses,parameters, commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //public async Task<string> AddAsync(VendorExpenses entity)
        //{
        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(Constants.AddVendorExpenses, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}


        public async Task<string> UpdateAsync(VendorExpenses entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@VendorExpensesId", entity.VendorExpensesId);
                parameters.Add("@VendorId", entity.VendorId);
                parameters.Add("@StockInId", entity.StockInId);
                parameters.Add("@ExpensesName", entity.ExpensesName);
                parameters.Add("@VendorName", entity.VendorName);
                parameters.Add("@LoadName", entity.LoadName);
                parameters.Add("@AmountPaid", entity.AmountPaid);
                parameters.Add("@CreatedDate", entity.CreatedDate);
                parameters.Add("@ModifiedDate", entity.ModifiedDate);
                parameters.Add("@LoggedInUser", entity.LoggedInUser);
                parameters.Add("@Comments", entity.Comments);
                parameters.Add("@IsActive", entity.IsActive);

                connection.Open();
                var result = await connection.ExecuteAsync(Constants.UpdateVendorExpenses,parameters,commandType: CommandType.StoredProcedure);

                return result.ToString();
            }
        }



        //public async Task<string> UpdateAsync(VendorExpenses entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateVendorExpenses, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.DeleteVendorExpenses, new { VendorExpensesId = id }, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }


        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteVendorExpenses, new { CustomerId = id });
        //        return result.ToString();
        //    }
        //}


        public async Task<IReadOnlyList<VendorPayments>> GetCommissionAgentExpensesForADate(DateTime selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPayments>(Constants.GetVendorPayments_ByDate, new { CreatedDate = selectedDate }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


        //public async Task<IReadOnlyList<VendorExpenses>> GetCommissionAgentExpensesForADate(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<VendorExpenses>(Constants.GetVendorExpenses_ByDate, new { CreatedDate = selectedDate });
        //        return result.ToList();
        //    }
        //}

        public async Task<IReadOnlyList<VendorExpenses>> GetVendorExpensesByStockInId(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var result = await connection.QueryAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId, new { StockInId = id }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<VendorExpenses>> GetVendorExpensesByStockInId(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId, new { StockInId = id });
        //        return result.ToList();
        //    }
        //}
    }
}
