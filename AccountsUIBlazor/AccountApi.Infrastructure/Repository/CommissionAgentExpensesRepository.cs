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
    public class CommissionAgentExpensesRepository : ICommissionAgentExpensesRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public CommissionAgentExpensesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));

        }

        public async Task<IReadOnlyList<CommissionAgentExpenses>> GetAllAsync()
        {          
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentExpenses>(Constants.GetAllCommissionAgentExpenses);
                connection.Close();
                return result.ToList();          
        }


        public async Task<CommissionAgentExpenses> GetByIdAsync(long id)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@StockInId",id, DbType.Int64);
                
            var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentExpenses>(Constants.GetAllCommissionAgentExpenses_ByStockInId,parameters,commandType:CommandType.StoredProcedure);
            connection.Close();
            return result;           
        }       
        public async Task<string> AddAsync(CommissionAgentExpenses entity)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@ExpensesName", entity.ExpensesName, DbType.String);
                parameters.Add("@ElectronicPaymentId", entity.ElectronicPaymentId, DbType.Int32);
                parameters.Add("@AmountPaid", entity.AmountPaid, DbType.Decimal);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);
                parameters.Add("@Comments", entity.Comments, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);                
                var result = await connection.ExecuteAsync(Constants.AddCommissionAgentExpenses,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }
        public async Task<string> UpdateAsync(CommissionAgentExpenses entity)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionAgentExpensesId", entity.CommissionAgentExpensesId, DbType.Int32);
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@ExpensesName", entity.ExpensesName, DbType.String);
                parameters.Add("@ElectronicPaymentId", entity.ElectronicPaymentId, DbType.Int32);
                parameters.Add("@AmountPaid", entity.AmountPaid, DbType.Decimal);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);
                parameters.Add("@Comments", entity.Comments, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean); 
                var result = await connection.ExecuteAsync(Constants.UpdateCommissionAgentExpenses,parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }
        public async Task<string> DeleteAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionAgentExpensesId", id, DbType.Int64);               
                var result = await connection.ExecuteAsync(Constants.DeleteCommissionAgentExpenses,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }        
        public async Task<IReadOnlyList<CommissionAgentExpenses>> GetCommissionAgentExpensesForADate(string selectedDate)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate",selectedDate.ToString());               
                var result = await connection.QueryAsync<CommissionAgentExpenses>(Constants.GetCommissionAgentExpenses_ByDate, new { CreatedDate = selectedDate });
                connection.Close();
                return result.ToList();
            
        }

    }
}
