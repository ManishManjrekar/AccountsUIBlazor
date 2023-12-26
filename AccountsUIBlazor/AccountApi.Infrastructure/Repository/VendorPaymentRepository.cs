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
using AccountApi.Core.Entities;

namespace AccountApi.Infrastructure.Repository
{
    public class VendorPaymentRepository : IVendorPaymentRepository
    {

        private readonly IConfiguration configuration;
       
        public VendorPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorPayment>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPayment>(CustomerQueries.AllCustomer);
                return result.ToList();
            }
        }

        public async Task<VendorPayment> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<VendorPayment>(CustomerQueries.CustomerById, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(VendorPayment entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CustomerQueries.AddCustomer, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(VendorPayment entity)
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

       

    }
}
