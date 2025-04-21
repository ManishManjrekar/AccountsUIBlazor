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
    public class SalesRepository : ISalesRepository
    {

        private readonly IConfiguration configuration;
        private readonly SqlConnection connection;
       
        public SalesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<Sales>> GetAllAsync()
        { 
                connection.Open();
                var result = await connection.QueryAsync<Sales>(Constants.AllSales);
                connection.Close();
                return result.ToList();
        }
        
        public async Task<Sales> GetByIdAsync(long id)
        {       
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@SalesId", id, DbType.Int64);               
                var result = await connection.QuerySingleOrDefaultAsync<Sales>(Constants.SalesById,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result;           
        }
        public async Task<string> AddAsync(Sales entity)
        {
            //entity.Type = "";
            entity.CreatedBy = "System";
            entity.LoggedInUser = "System";
            //entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = true;
            try
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@CustomerId", entity.CustomerId, DbType.Int32);
                parameters.Add("@Quantity", entity.Quantity, DbType.Int32);
                parameters.Add("@Price", entity.Price, DbType.Decimal);
                parameters.Add("@TotalAmount", entity.TotalAmount, DbType.Decimal);
                parameters.Add("@Type", entity.Type, DbType.String);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);
                var result = await connection.ExecuteAsync(Constants.AddSales, parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateAsync(Sales entity)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@SalesId", entity.SalesId, DbType.Int32);
                parameters.Add("@VendorId", entity.VendorId, DbType.Int32);
                parameters.Add("@StockInId", entity.StockInId, DbType.Int32);
                parameters.Add("@CustomerId", entity.CustomerId, DbType.Int32);
                parameters.Add("@Quantity", entity.Quantity, DbType.Int32);
                parameters.Add("@Price", entity.Price, DbType.Decimal);
                parameters.Add("@TotalAmount", entity.TotalAmount, DbType.Decimal);
                parameters.Add("@Type", entity.Type, DbType.String);
                parameters.Add("@CreatedDate", entity.CreatedDate, DbType.DateTime);
                parameters.Add("@ModifiedDate", entity.ModifiedDate, DbType.DateTime);
                parameters.Add("@CreatedBy", entity.CreatedBy, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                parameters.Add("@LoggedInUser", entity.LoggedInUser, DbType.String);               
                var result = await connection.ExecuteAsync(Constants.UpdateSales,parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();           
        }
        public async Task<string> DeleteAsync(long id)
        {      
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@SalesId",id, DbType.Int32);         
                var result = await connection.ExecuteAsync(Constants.DeleteSales,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();            
        }
        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerStockInId(int stockInId)
        {
            try
            { 
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@StockInId", stockInId, DbType.Int32);               
                    var result = await connection.QueryAsync<SalesDetails>(Constants.GetSalesDataAsPerStockInId, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToList();              
            }
            catch (Exception)
            {
                throw;
            }       
        }     
        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsPerCustomerId(int customerId)
        {
           try
           {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@StockInId", customerId, DbType.Int32);            
                    var result = await connection.QueryAsync<SalesDetails>(Constants.GetSalesDataAsPerCustomerId, parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result.ToList();               
            }
            catch (Exception)
            { 
                throw;
            }
        }     
        public async Task<IReadOnlyList<SalesDetails>> GetSalesDataAsperDate(string selectedDate)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CreatedDate", selectedDate, DbType.Date);            
                var result = await connection.QueryAsync<SalesDetails>(Constants.GetSalesDataAsPerDate,parameters,commandType:CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();     
        }
        public async Task<int> GetSales_Sum_Per_StockInId(int stockInId)
        {
            try
            {             
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@StockInId", stockInId, DbType.Int32);                  
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetSales_Sum_Per_StockInId,parameters,commandType:CommandType.StoredProcedure);
                    connection.Close();
                    return result;           
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> GetSales_Sum_Per_Date(string selectedDate)
        {
            try
            {               
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@CreatedDate", selectedDate, DbType.Date);           
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetSales_Sum_Per_Date,parameters,commandType:CommandType.StoredProcedure);
                    connection.Close();
                    return result;             
            }
            catch (Exception)
            {
                throw;
            }
        }     
        public async Task<int> GetSales_Sum_Between_Dates(string fromDate, string toDate)
        {
            try
            {              
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@FromDate", fromDate, DbType.Date);
                    parameters.Add("@ToDate", toDate, DbType.Date);                   
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetSales_Sum_Between_Dates,parameters,commandType:CommandType.StoredProcedure);
                    connection.Close();
                    return result;               
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> GetCommission_for_Sales_AsPer_PercentageValue(int PercentageCommission, int StockInId)
        {
            try
            {              
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@PercentageCommission",PercentageCommission, DbType.Decimal);
                    parameters.Add("@StockInId",StockInId, DbType.Int32);
                    var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommission_for_Sales_PercentageValue,parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
