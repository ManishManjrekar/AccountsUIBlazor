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
using static Dapper.SqlMapper;
using System.Security.Cryptography;

namespace AccountApi.Infrastructure.Repository
{
    public class VendorExpensesRepository : IVendorExpensesRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;

        public VendorExpensesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<VendorExpenses>> GetAllAsync()
        {
            connection.Open();
            var result = await connection.QueryAsync<VendorExpenses>(Constants.GetAllVendorExpenses);
            connection.Close();
            return result.ToList();
        }
        public async Task<VendorExpenses> GetByIdAsync(long id)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@StockInId", id, DbType.Int64);
            var result = await connection.QuerySingleOrDefaultAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId, parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }

        public async Task<string> AddAsync(VendorExpenses entity)
        {
            try
            {
                connection.Open();
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
                var result = await connection.ExecuteAsync(Constants.AddVendorExpenses, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(VendorExpenses entity)
        {
            connection.Open();
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
            var result = await connection.ExecuteAsync(Constants.UpdateVendorExpenses, parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToString();
        }
        public async Task<string> DeleteAsync(long id)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("VendorExpensesId", id, DbType.Int64);
            var result = await connection.ExecuteAsync(Constants.DeleteVendorExpenses, parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToString();
        }

        public async Task<IReadOnlyList<VendorPayments>> GetCommissionAgentExpensesForADate(DateTime selectedDate)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@CreatedDate", selectedDate, DbType.Date);
            //parameters.Add("@CreatedDate", DateTime.Parse(selectedDate), DbType.Date); 
            var result = await connection.QueryAsync<VendorPayments>(Constants.GetVendorPayments_ByDate, parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToList();
        }
        public async Task<IReadOnlyList<VendorExpenses>> GetVendorExpensesByStockInId(long id)
        {
            connection.Open();
            var parameter = new DynamicParameters();
            parameter.Add("@StockInId", id, DbType.Int64);
            var result = await connection.QueryAsync<VendorExpenses>(Constants.GetAllVendorExpenses_ByStockInId, parameter, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToList();
        }

        
    }
}
