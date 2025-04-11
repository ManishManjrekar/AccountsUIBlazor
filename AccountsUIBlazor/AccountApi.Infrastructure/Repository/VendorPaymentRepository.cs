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
       
        public VendorPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<VendorPayments>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<VendorPayments>(Constants.AllVendorPayment);
                return result.ToList();
            }
        }
        //public async Task<IReadOnlyList<VendorPayments>> GetAllAsync()
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<VendorPayments>(Constants.AllVendorPayment);
        //        return result.ToList();
        //    }
        //}

        public async Task<VendorPayments> GetByIdAsync(long id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@VendorPaymentId", id, DbType.Int64);

                    var result = await connection.QuerySingleOrDefaultAsync<VendorPayments>("VendorPaymentById", parameters,commandType: CommandType.StoredProcedure
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                // Optional: log or handle exception
                throw;
            }
        }
        //public async Task<VendorPayments> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<VendorPayments>(Constants.VendorPaymentById, new { VendorPaymentId = id });
        //        return result;
        //    }
        //}

        public async Task<string> AddAsync(VendorPayments entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
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

                    var result = await connection.ExecuteAsync(Constants.AddVendorPayment,parameters,commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {        
                throw;
            }
        }

        //public async Task<string> AddAsync(VendorPayments entity)
        //{
        //    entity.IsActive = true;
        //    entity.ModifiedDate = DateTime.Now;

        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(Constants.AddVendorPayment, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
        public async Task<string> UpdateAsync(VendorPayments entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
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
                   

                    var result = await connection.ExecuteAsync(Constants.UpdateVendorPayment,parameters,commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //public async Task<string> UpdateAsync(VendorPayments entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateVendorPayment, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@VendorPaymentId", id, DbType.Int64);

                    var result = await connection.ExecuteAsync(Constants.DeleteVendorPayment,parameters,commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteVendorPayment, new { VendorPaymentId = id });
        //        return result.ToString();
        //    }
        //}

        public async Task<IReadOnlyList<VendorPaymentDetails>> GetVendorPaymentAsPerStockInId(long stockInId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@StockInId", stockInId, DbType.Int64);
                    //parameters.Add("@VendorId", vendorId,DbType.Int64);

                    var result = await connection.QueryAsync<VendorPaymentDetails>(Constants.GetVendorPaymentAsPerStockInId,parameters,commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //public async Task<IReadOnlyList<VendorPaymentDetails>> GetVendorPaymentAsPerStockInId(long stockInId)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<VendorPaymentDetails>(Constants.GetVendorPaymentAsPerStockInId, new { StockInId = stockInId });
        //        return result.ToList();
        //    }
        //}
        public async Task<IReadOnlyList<VendorPayments>> GetVendorPaymentsForADate(string selectedDate)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@CreatedDate", DateTime.Parse(selectedDate), DbType.Date);

                    var result = await connection.QueryAsync<VendorPayments>(Constants.GetVendorPayments_ByDate,parameters,commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                // Optional logging
                throw;
            }
        }


        //public async Task<IReadOnlyList<VendorPayments>> GetVendorPaymentsForADate(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<VendorPayments>(Constants.GetVendorPayments_ByDate, new { CreatedDate = selectedDate });
        //        return result.ToList();
        //    }
        //}



    }
}
