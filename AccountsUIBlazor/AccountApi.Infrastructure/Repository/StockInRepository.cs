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
        private readonly SqlConnection connection;
       
        public StockInRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }
        public async Task<IReadOnlyList<StockIn>> GetAllAsync()
        {         
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.AllStockIn);
                connection.Close();
                return result.ToList();        
        }


        public async Task<int> GetVendorId(long vendorId)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", vendorId, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<int>(Constants.GetVendorId_ByStockInId,parameters,commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;         
        }
        public async Task<StockIn> GetByIdAsync(long id)
        {
               connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id, DbType.Int64);
                parameters.Add("@CustomerId",id,DbType.Int32);                
                var result = await connection.QuerySingleOrDefaultAsync<StockIn>(Constants.StockInById,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result;            
        }
        public async Task<string> AddAsync(StockIn entity)
        {
           // entity.CreatedDate = DateTime.Now;
           // entity.ModifiedDate = DateTime.Now;

            try
            {                
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@LoadName", entity.LoadName);
                    parameters.Add("@VendorId", entity.VendorId);
                    parameters.Add("@Quantity", entity.Quantity);
                    parameters.Add("@isActive", true);
                    parameters.Add("@IsPaymentDone", false);
                    parameters.Add("@VendorName", entity.VendorName);
                    parameters.Add("@CreatedBy", "System");
                    parameters.Add("@ModifiedDate", DateTime.Now);
                    parameters.Add("@CreatedDate", DateTime.Now);
                    //parameters.Add("@CreatedDate", entity.CreatedDate); 
                    var result = connection.Execute(Constants.AddStockIn, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToString();                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(StockIn entity)
        {
                 connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", entity.StockInId);
                parameters.Add("@Quantity", entity.Quantity);
                parameters.Add("@VendorId", entity.VendorId);
                parameters.Add("@LoadName", entity.LoadName);
                parameters.Add("@IsPaymentDone", entity.IsPaymentDone);               
                var result = await connection.ExecuteAsync(Constants.UpdateStockIn, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
        }
        public async Task<string> DeleteAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@StockInId", id);               
                var result = await connection.ExecuteAsync(Constants.DeleteStockIn,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }
        public async Task<int> GetVendorLoadCount(int VendorId, string createdDate)
        {         
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", VendorId);
                parameters.Add("@createdDate", createdDate);
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetVendorLoadCount,parameters,commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;           
        }
        public async Task<IReadOnlyList<StockIn>> GetStockInDataAsperDates(string fromDate, string toDate, int VendorId)
        {         
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", VendorId);
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@toDate", toDate);
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerVendorId, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();           
        }
        public async Task<IReadOnlyList<StockIn>> GetStockInAsperDates(string fromDate, string toDate)
        {           
                connection.Open();
                var Parameters = new DynamicParameters();
                Parameters.Add("@fromDate",fromDate);
                Parameters.Add("@toDate", toDate);                
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsPerDates,Parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();           
        }
        public async Task<IReadOnlyList<StockIn>> GetStockInAsPerPaymentNotCompleted()
        {
                connection.Open();
                var result = await connection.QueryAsync<StockIn>(Constants.GetStockInWhereIn_PaymentNotCompleted,commandType:CommandType.StoredProcedure);
                connection.Open();
                return result.ToList();            
        }
        public async Task<IReadOnlyList<StockIn>> GetStockInAsperDate(string selectedDate)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@CreatedDate",selectedDate);    
            var result = await connection.QueryAsync<StockIn>(Constants.GetStockInAsperDate,parameters,commandType:CommandType.StoredProcedure);
            connection.Close();
            return result.ToList();            
        }

        public async Task<int> GetstockQuantity_ByStockInId(int stockInId)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@StockInId",stockInId);
            var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByStockInId,parameters,commandType:CommandType.StoredProcedure);
            connection.Close();
            return result;
            
        }
        public async Task<int> GetstockQuantity_ByDate(string selectedDate)
        {
            connection.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@CreatedDate",selectedDate);
            var result = await connection.ExecuteScalarAsync<int>(Constants.GetstockQuantity_ByDate,parameters,commandType:CommandType.StoredProcedure);
            connection.Close();
            return result;
            
        }

        public async Task<bool> GetDuplicateOrNot(int VendorId, string createdDate, string LoadName)
        {
            connection.Close();
            var parameters = new DynamicParameters();
            parameters.Add("@VendorId",VendorId);
            parameters.Add("@createdDate",createdDate);
            parameters.Add("@LoadName",LoadName);          
            var result = await connection.ExecuteScalarAsync<int>(Constants.CheckDuplicateLoadName,parameters,commandType:CommandType.StoredProcedure);
            if (result > 0)
            {
              return true;
            }
             return false;
        }
    }
        

    
}
