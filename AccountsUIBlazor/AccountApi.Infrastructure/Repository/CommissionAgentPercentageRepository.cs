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
using AutoMapper;

namespace AccountApi.Infrastructure.Repository
{
    public class CommissionAgentPercentageRepository : ICommissionAgentPercentageRepository
    {

        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;
        private readonly SqlConnection connection;

        public CommissionAgentPercentageRepository(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            _mapper = mapper;
            this.connection = new SqlConnection(configuration.GetConnectionString("DBConnection"));
        }

        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllAsync()
        {
                connection.Open();          
                var result = await connection.QueryAsync<CommissionAgentPercentage>(Constants.AllCommissionPercentage, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToList();
                   
        }
        public async Task<CommissionAgentPercentage> GetByIdAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionAgentExpensesId", id, DbType.Int64);
                var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentPercentage>(Constants.CommissionPercentageById,parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
                  
        }
        public async Task<string> AddAsync(CommissionAgentPercentage entity)
        {     
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionPercentage", entity.CommissionPercentage, DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                var result = await connection.ExecuteAsync(Constants.AddCommissionPercentage,parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
                        
        }
        public async Task<string> UpdateAsync(CommissionAgentPercentage entity)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionPercentageId ",entity.CommissionPercentageId,DbType.Int64);
                parameters.Add(" @CommissionPercentage ",entity.CommissionPercentage,DbType.String);
                parameters.Add("@IsActive", entity.IsActive, DbType.Boolean);
                var result = await connection.ExecuteAsync(Constants.UpdateCommissionPercentage,parameters,commandType: CommandType.StoredProcedure);
                connection.Open();
                return result.ToString(); 
            
        }
        public async Task<string> DeleteAsync(long id)
        {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@CommissionAgentExpensesId", id, DbType.Int64);
                var result = await connection.ExecuteAsync(Constants.DeleteCommissionPercentage,parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.ToString();
            
        }
        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllCommissionPercentage()
        {         
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentPercentage>(Constants.GetAllCommissionPercentageData);
                connection.Close();
                return result.ToList();
            
        }

        public async Task<int> GetCommissionPercentage_Active()
        {
         
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionPercentage_Active);
                connection.Close();
                return result;
            
        }



    }
}
