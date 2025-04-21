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
    public class ExpensesTypesRepository : IExpensesTypesRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public ExpensesTypesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<ExpensesTypes>> GetAllAsync()
        {
                connection.Open();                
                var result = await connection.QueryAsync<ExpensesTypes>(Constants.ExpensesAllCustomer);
                connection.Close();
                return result.ToList();           
        }

        public async Task<ExpensesTypes> GetByIdAsync(long id)
        {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", id, DbType.Int32);
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<ExpensesTypes>(Constants.ExpensesCusotmerById, parameters,commandType:CommandType.StoredProcedure);
                return result;           
        }
        public async Task<string> AddAsync(ExpensesTypes entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", entity.FirstName, DbType.String);
                parameters.Add("@MiddleName", entity.MiddleName, DbType.String);
                parameters.Add("@NickName", entity.NickName, DbType.String);
                parameters.Add("@LastName", entity.LastName, DbType.String);
                parameters.Add("@Mobile", entity.Mobile, DbType.String);
                parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String);
                parameters.Add("@ReferredBy", entity.ReferredBy, DbType.String);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedBy", entity.ModifiedBy, DbType.Int32);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);                
                var result = await connection.ExecuteAsync(Constants.ExpensesAddCustomer, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();                
            }
            catch (Exception )
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(ExpensesTypes entity)
        {      
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", entity.CustomerId, DbType.Int32);
                parameters.Add("@FirstName", entity.FirstName, DbType.String);
                parameters.Add("@LastName", entity.LastName, DbType.String);
                parameters.Add("@Email", entity,DbType.String);
                parameters.Add("@PhoneNumber", entity.Mobile, DbType.Int32);
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.ExpensesUpdateCustomer, parameters,commandType:CommandType.StoredProcedure);
                return result.ToString();          
        }
        public async Task<string> DeleteAsync(long id)
        {        
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", id);
                var result = await connection.ExecuteAsync(Constants.ExpensesDeleteCustomer, parameters,commandType:CommandType.StoredProcedure);
                connection.Open();
                return result.ToString();       
        }

    }
}
