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

        public CommissionAgentPercentageRepository(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentPercentage>(Constants.AllCommissionPercentage, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }       
        }

        //public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllAsync()
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<CommissionAgentPercentage>(Constants.AllCommissionPercentage);
        //        return result.ToList();
        //    }
        //}

        public async Task<CommissionAgentPercentage> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentPercentage>(Constants.CommissionPercentageById, new { CommissionPercentageId = id }, commandType: CommandType.StoredProcedure);
                return result;
            }      
        }


        //public async Task<CommissionAgentPercentage> GetByIdAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentPercentage>(Constants.CommissionPercentageById, new { CommissionPercentageId = id });
        //        return result;
        //    }
        //}

        public async Task<string> AddAsync(CommissionAgentPercentage entity)
        {     
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
                {
                    connection.Open(); 
                    var result = await connection.ExecuteAsync(Constants.AddCommissionPercentage,new{CommissionPercentage = entity.CommissionPercentage,
                        IsActive = entity.IsActive},commandType: CommandType.StoredProcedure);               
                        return result.ToString();
                }         
        }

        //public async Task<string> AddAsync(CommissionAgentPercentage entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.AddCommissionPercentage, entity);
        //        return result.ToString();
        //    }
        //}

        public async Task<string> UpdateAsync(CommissionAgentPercentage entity)
        {
            var commissionPercentage = _mapper.Map<CommissionAgentPercentage>(entity);

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();

                var result = await connection.ExecuteAsync(Constants.UpdateCommissionPercentage,new { CommissionPercentageId = commissionPercentage.CommissionPercentageId,
                        CommissionPercentage = commissionPercentage.CommissionPercentage,IsActive = commissionPercentage.IsActive },
                    commandType: CommandType.StoredProcedure);

                return result.ToString(); 
            }
        }

        //public async Task<string> UpdateAsync(CommissionAgentPercentage entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.UpdateCommissionPercentage, entity);
        //        return result.ToString();
        //    }
        //}


        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(Constants.DeleteCommissionPercentage, new { CommissionPercentageId = id }, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }
        }


        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(Constants.DeleteCommissionPercentage, new { CommissionPercentageId = id });
        //        return result.ToString();
        //    }
        //}

       

        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllCommissionPercentage()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentPercentage>(Constants.GetAllCommissionPercentageData);
                return result.ToList();
            }
        }

        //public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllCommissionPercentage()
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();

        //        var result = await connection.QueryAsync<CommissionAgentPercentage>("GetAllCommissionPercentageData", commandType: CommandType.StoredProcedure);
        //        return result.ToList();
        //    }
        //}


        public async Task<int> GetCommissionPercentage_Active()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(Constants.GetCommissionPercentage_Active);
                return result;
            }
        }



    }
}
