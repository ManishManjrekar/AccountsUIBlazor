﻿using AccontApi.Core;
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

namespace AccountApi.Infrastructure.Repository
{
    public class CustomerRepository: ICustomerRepository
    {

        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        #region ===[ Constructor ]=================================================================

        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region ===[ ICustomerRepository Methods ]==================================================

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Customer>(CustomerQueries.AllCustomer);
                return result.ToList();
            }
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(CustomerQueries.CustomerById, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Customer entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.AddCustomer, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Customer entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.UpdateCustomer, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.DeleteCustomer, new { CustomerId = id });
                return result.ToString();
            }
        }

        #endregion

    }
}
