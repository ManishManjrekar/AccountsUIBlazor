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
using System.Reflection.Metadata;
using AutoMapper;
using static Dapper.SqlMapper;




namespace AccountApi.Infrastructure.Repository
{
    public class CustomerRepository: ICustomerRepository
    {

        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly SqlConnection connection;
        
        public CustomerRepository(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {          
                connection.Open();
                var result = await connection.QueryAsync<Customer>(Constants.GetAllCustomers);
                connection.Close();
                return result.ToList();
        }     
        public async Task<Customer> GetByIdAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId",id, DbType.Int32);                
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(Constants.CustomerById,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result;         
        }
        public async Task<string> AddAsync(Customer entity )
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
                parameters.Add("@ReferredBy",entity.ReferredBy, DbType.String);        
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedBy", entity.ModifiedBy, DbType.Int32);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);                    
                var result = await connection.ExecuteAsync(Constants.AddCustomer, parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(Customer entity)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", entity.CustomerId,DbType.Int32);
            parameters.Add("@FirstName", entity.FirstName,DbType.String);
            parameters.Add("@LastName", entity.LastName,DbType.String);
            //parameters.Add("@Email", entity.Email);
            parameters.Add("@PhoneNumber", entity.Mobile,DbType.Int32);                
            var result = await connection.ExecuteAsync(Constants.UpdateCustomer, parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToString(); 
            
        }
        public async Task<string> DeleteAsync(long id)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", id);

            var result = await connection.ExecuteAsync(Constants.DeleteCustomer, new { CustomerId = id }, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result.ToString();
            
        }
        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {

            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", firstName, DbType.String);
            parameters.Add("@LastName", lastName, DbType.String);
            
            var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateCustomerName, new { firstName, lastName },commandType: CommandType.StoredProcedure);
            if (result > 0)
            {
               return true;
            }
              return false;
            //connection.Close();
        }
        
    }
}
