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
    public class StockInRepository : IStockInRepository
    {

        private readonly IConfiguration configuration;
       
        public StockInRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IReadOnlyList<StockIn>> GetAllAsync()
        {
           using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.AllStockIn);
                return result.ToList();
            }
        }


        public async Task<int> GetVendorId(long vendorId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", vendorId, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<int>(Constants.GetVendorId_ByStockInId,parameters,commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        //public async Task<int> GetVendorId(long vendorId)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<int>(Constants.GetVendorId_ByStockInId, new { StockInId = vendorId });
        //        return result;
        //    }
        //}


        public async Task<StockIn> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id, DbType.Int64);
                connection.Open();
                return connection.QuerySingleOrDefault<StockIn>(Constants.StockInById,parameters,commandType: CommandType.StoredProcedure);
                //return result;
            }
        }

        //public async Task<StockIn> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<StockIn>(Constants.StockInById, new { CustomerId = id });
        //        return result;
        //    }
        //}


        public async Task<string> AddAsync(StockIn entity)
        {
           // entity.CreatedDate = DateTime.Now;
           // entity.ModifiedDate = DateTime.Now;

            var parameters = new DynamicParameters();
            parameters.Add("@LoadName", entity.LoadName);
            parameters.Add("@VendorId", entity.VendorId);
            parameters.Add("@Quantity", entity.Quantity);
            parameters.Add("@isActive", true);
            parameters.Add("@IsPaymentDone", false);
            parameters.Add("@VendorName", entity.VendorName);
            parameters.Add("@CreatedBy", "System");
            parameters.Add("@ModifiedDate", DateTime.Now);
            parameters.Add("@CreatedDate",  DateTime.Now); 
            //parameters.Add("@CreatedDate", entity.CreatedDate); 

            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open();
                    var result = connection.Execute(Constants.AddStockIn, parameters, commandType: CommandType.StoredProcedure);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public async Task<string> AddAsync(StockIn entity)
        //{
        //    entity.isActive = true;
        //    entity.CreatedBy = "System";
        //    //entity.CreatedDate = DateTime.Now;
        //    entity.ModifiedDate = DateTime.Now;
        //    entity.IsPaymentDone = false;
        //    try
        //    {
        //        using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //        {
        //            connection.Open();
        //            var result = await connection.ExecuteAsync(Constants.AddStockIn, entity);
        //            return result.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        public async Task<string> UpdateAsync(StockIn entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", entity.StockInId);
                parameters.Add("@Quantity", entity.Quantity);
                parameters.Add("@VendorId", entity.VendorId);
                parameters.Add("@LoadName", entity.LoadName);
                parameters.Add("@IsPaymentDone", entity.IsPaymentDone);
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.UpdateStockIn, parameters, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }

        //public async Task<string> UpdateAsync(StockIn entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateStockIn, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id);
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.DeleteStockIn,parameters,commandType:CommandType.StoredProcedure);
                return result.ToString();
            }
        }

        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteStockIn, new { CustomerId = id });
        //        return result.ToString();
        //    }
        //}


        public async Task<int> GetVendorLoadCount(int VendorId, string createdDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", VendorId);
                parameters.Add("@createdDate", createdDate);

                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetVendorLoadCount,parameters,commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        //public async Task<int> GetVendorLoadCount(int VendorId, string createdDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.GetVendorLoadCount, new { VendorId, createdDate });
        //        return result;
        //    }
        //}


        public async Task<IReadOnlyList<StockIn>> GetStockInDataAsperDates(string fromDate, string toDate, int VendorId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VendorId", VendorId);
            parameters.Add("@fromDate", fromDate);
            parameters.Add("@toDate", toDate);
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerVendorId, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<StockIn>> GetStockInDataAsperDates(string fromDate, string toDate, int VendorId)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerVendorId, new { VendorId, fromDate, toDate, });
        //        return result.ToList();
        //    }
        //}

        public async Task<IReadOnlyList<StockIn>> GetStockInAsperDates(string fromDate, string toDate)
        {

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@fromDate",fromDate);
                Parameters.Add("@toDate", toDate);
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerDates,Parameters,commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<StockIn>> GetStockInAsperDates(string fromDate, string toDate)
        //{

        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerDates, new { fromDate, toDate, });
        //        return result.ToList();
        //    }
        //}


        public async Task<IReadOnlyList<StockIn>> GetStockInAsPerPaymentNotCompleted()
        {

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInWhereIn_PaymentNotCompleted,commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<StockIn>> GetStockInAsPerPaymentNotCompleted()
        //{

        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<StockIn>(Constants.GetStockInWhereIn_PaymentNotCompleted);
        //        return result.ToList();
        //    }
        //}

        public async Task<IReadOnlyList<StockIn>> GetStockInAsperDate(string selectedDate)
        {

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate",selectedDate);
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsperDate,parameters,commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<int> GetstockQuantity_ByStockInId(int stockInId)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId",stockInId);
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByStockInId,parameters,commandType:CommandType.StoredProcedure);
                return result;
            }
        }

        //public async Task<int> GetstockQuantity_ByStockInId(int stockInId)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByStockInId, new { StockInId = stockInId });
        //        return result;
        //    }
        //}

        public async Task<int> GetstockQuantity_ByDate(string selectedDate)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate",selectedDate);
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByDate,parameters,commandType:CommandType.StoredProcedure);
                return result;
            }
        }

        //public async Task<int> GetstockQuantity_ByDate(string selectedDate)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByDate, new { CreatedDate = selectedDate });
        //        return result;
        //    }
        //}

        public async Task<bool> GetDuplicateOrNot(int VendorId, string createdDate, string LoadName)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId",VendorId);
                parameters.Add("@createdDate",createdDate);
                parameters.Add("@LoadName",LoadName);
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateLoadName,parameters,commandType:CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
        //public async Task<bool> GetDuplicateOrNot(int VendorId, string createdDate,string LoadName)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateLoadName, new { VendorId, createdDate, LoadName });
        //        if (result>0)
        //        {
        //            return true;
        //        }
        //        return false ;
        //    }
        //}

    }
}
