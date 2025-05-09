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
    public class VendorPaymentRepository : IVendorPaymentRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public VendorPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<VendorPayments>> GetAllAsync()
        {
            connection.Open();
            var result = await connection.QueryAsync<VendorPayments>(Constants.AllVendorPayment);
            connection.Close();
            return result.ToList();
        }     
        public async Task<VendorPayments> GetByIdAsync(long id)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorPaymentId", id, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<VendorPayments>("VendorPaymentById", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
            catch (Exception)
            {               
                throw;
            }
        }    
        public async Task<string> AddAsync(VendorPayments entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@TypeOfTransaction", entity.TypeOfTransaction, DbType.String);
                parameters.Add("@AmountPaid", entity.AmountPaid, DbType.Int64);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);
                parameters.Add("@Comments", entity.Comments, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                var result = await connection.ExecuteAsync(Constants.AddVendorPayment, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            {        
                throw;
            }
        }
        public async Task<string> UpdateAsync(VendorPayments entity)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@TypeOfTransaction", entity.TypeOfTransaction, DbType.String);
                parameters.Add("@AmountPaid", entity.AmountPaid, DbType.Int64);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", DateTime.Now, DbType.DateTime);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);
                parameters.Add("@Comments", entity.Comments, DbType.String);
                parameters.Add("@VendorPaymentId", entity.VendorPaymentId, DbType.Int32);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                var result = await connection.ExecuteAsync(Constants.UpdateVendorPayment, parameters, commandType: CommandType.StoredProcedure);
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
                parameters.Add("@VendorPaymentId", id, DbType.Int64);
                var result = await connection.ExecuteAsync(Constants.DeleteVendorPayment, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IReadOnlyList<VendorPaymentDetails>> GetVendorPaymentAsPerStockInId(long stockInId)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                //parameters.Add("@VendorId", VendorId, DbType.Int64);
                parameters.Add("@StockInId", stockInId, DbType.Int64);
                var result = await connection.QueryAsync<VendorPaymentDetails>(Constants.GetVendorPaymentAsPerStockInId, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IReadOnlyList<VendorPayments>> GetVendorPaymentsForADate(string selectedDate)
        {
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate", DateTime.Parse(selectedDate), DbType.Date);
                var result = await connection.QueryAsync<VendorPayments>(Constants.GetVendorPayments_ByDate, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
