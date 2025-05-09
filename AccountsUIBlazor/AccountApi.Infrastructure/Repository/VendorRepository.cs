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
    public class VendorRepository : IVendorRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public VendorRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));

        }

        public async Task<IReadOnlyList<Vendor>> GetAllAsync()
        {
            try
            {
                connection.Open();
                var result = await connection.QueryAsync<Vendor>(Constants.GetActiveVendors);
                connection.Close();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Vendor> GetByIdAsync(long id)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", id, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<Vendor>("VendorById", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        public async Task<string> AddAsync(Vendor entity)
        {
            try
            {
                // Set default values
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                entity.IsActive = true;
                entity.Address = "Address";
                entity.City = "some city";
                entity.State = "some state";
                entity.CreatedBy = "System";
                entity.ModifiedBy = "System";
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@FirstName", entity.FirstName, DbType.String);
                    parameters.Add("@MiddleName", entity.MiddleName, DbType.String);
                    parameters.Add("@LastName", entity.LastName, DbType.String);
                    parameters.Add("@Mobile", entity.Mobile, DbType.String);
                    parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                    parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                    parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String);
                    parameters.Add("@ModifiedBy", entity.ModifiedBy, DbType.String);
                    parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                    parameters.Add("@ElectronicPaymentId", entity.ElectronicPaymentId, DbType.String);
                    parameters.Add("@ReferredBy", entity.ReferredBy, DbType.String);
                    parameters.Add("@Address", entity.Address, DbType.String);
                    parameters.Add("@City", entity.City, DbType.String);
                    parameters.Add("@State", entity.State, DbType.String);
                    var result = await connection.ExecuteAsync("AddVendor", parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(Vendor entity)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@FirstName", entity.FirstName, DbType.String);
                parameters.Add("@LastName", entity.LastName, DbType.String);
                parameters.Add("@Mobile", entity.Mobile, DbType.String);
                parameters.Add("@ElectronicPaymentId", entity.ElectronicPaymentId, DbType.String);
                var result = await connection.ExecuteAsync("UpdateVendor", parameters, commandType: CommandType.StoredProcedure);
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
                parameters.Add("@VendorId", id, DbType.Int32);
                var result = await connection.ExecuteAsync("DeleteVendor", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", firstName, DbType.String);
                parameters.Add("@LastName", lastName, DbType.String);
                var result = await connection.ExecuteScalarAsync<int>("CheckDuplicateVendorName", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
