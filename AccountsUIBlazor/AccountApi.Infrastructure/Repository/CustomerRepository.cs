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



namespace AccountApi.Infrastructure.Repository
{
    public class CustomerRepository: ICustomerRepository
    {

        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        
        public CustomerRepository(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }
        
        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                //    var result = await connection.QueryAsync<Customer>(CustomerQueries.AllCustomer);
                //    return result.ToList();
                
                var result = await connection.QueryAsync<Customer>(Constants.GetAllCustomers);
                return result.ToList();
            }
            
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(Constants.CustomerById, new { CustomerId = id });
                return result;
            }
        }


        public async Task<string> AddAsync(Customer entity )
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            try
            {
                
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

                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
              {
                    connection.Open();
                    //var result = await connection.ExecuteAsync("AddCustomer",parameters, commandType: CommandType.StoredProcedure);
                    var result = await connection.ExecuteAsync(Constants.AddCustomer, parameters,commandType:CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
                    catch (Exception ex)
            {

                           throw;
            }

        }



        //public async Task<string> AddAsync(Customer entity)
        //{
        //    try
        //    {
        //        entity.CreatedDate = DateTime.Now;
        //        entity.ModifiedDate = DateTime.Now;

        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(CustomerQueries.AddCustomer, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}



        public async Task<string> UpdateAsync(Customer entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
           

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", entity.CustomerId,DbType.Int32);
            parameters.Add("@FirstName", entity.FirstName,DbType.String);
            parameters.Add("@LastName", entity.LastName,DbType.String);
            //parameters.Add("@Email", entity.Email);
            parameters.Add("@PhoneNumber", entity.Mobile,DbType.Int32);           
            connection.Open();
            //var result = await connection.ExecuteAsync("UpdateCustomer", parameters, commandType: CommandType.StoredProcedure);
              var result = await connection.ExecuteAsync(Constants.UpdateCustomer, parameters, commandType: CommandType.StoredProcedure);
                return result.ToString(); 
            }
        }

        //public async Task<string> UpdateAsync(Customer entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(CustomerQueries.UpdateCustomer, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", id);
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                //var result = await connection.ExecuteAsync("DeleteCustomer", parameters, commandType: CommandType.StoredProcedure);
                var result = await connection.ExecuteAsync(Constants.DeleteCustomer, new { CustomerId = id }, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }




        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(CustomerQueries.DeleteCustomer, new { CustomerId = id });
        //        return result.ToString();
        //    }
        //}

        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", firstName, DbType.String);
                parameters.Add("@LastName", lastName, DbType.String);

                //var result = await connection.ExecuteScalarAsync<int>("CheckDuplicateVendorName",parameters, commandType: CommandType.StoredProcedure);
                var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateCustomerName, new { firstName, lastName },commandType: CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        
        //public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateCustomerName, new { firstName, lastName });
        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}

        
    }
}
