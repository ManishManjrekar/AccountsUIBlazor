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
       
        public VendorRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<Vendor>> GetAllAsync()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Vendor>(VendorQueries.AllVendor);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<Vendor> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Vendor>(VendorQueries.VendorById, new { CustomerId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Vendor entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            entity.Address = "Address";
            entity.City = "some city";
            entity.State = "some state";
            entity.CreatedBy = "System";
            entity.ModifiedBy = "system";
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(VendorQueries.AddVendor, entity);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<string> UpdateAsync(Vendor entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorQueries.UpdateVendor, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(VendorQueries.DeleteVendor, new { CustomerId = id }); // CustomerId
                return result.ToString();
            }
        }

        public async Task<bool> GetDuplicateOrNot(string firstName, string lastName)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(VendorQueries.CheckDuplicateVendorName, new { firstName, lastName });
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
