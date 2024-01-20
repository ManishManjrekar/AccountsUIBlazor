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
    public class CommissionAgentPercentageRepository : ICommissionAgentPercentageRepository
    {

        private readonly IConfiguration configuration;
       
        public CommissionAgentPercentageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentPercentage>(CommissionPercentageQueries.AllCommissionPercentage);
                return result.ToList();
            }
        }

        public async Task<CommissionAgentPercentage> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<CommissionAgentPercentage>(CommissionPercentageQueries.CommissionPercentageById, new { CommissionPercentageId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(CommissionAgentPercentage entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionPercentageQueries.AddCommissionPercentage, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(CommissionAgentPercentage entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionPercentageQueries.UpdateCommissionPercentage, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CommissionPercentageQueries.DeleteCommissionPercentage, new { CommissionPercentageId = id });
                return result.ToString();
            }
        }

        public async Task<IReadOnlyList<CommissionAgentPercentage>> GetAllCommissionPercentage()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CommissionAgentPercentage>(CommissionPercentageQueries.GetAllCommissionPercentageData);
                return result.ToList();
            }
        }

        public async Task<int> GetCommissionPercentage_Active()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(CommissionPercentageQueries.GetCommissionPercentage_Active);
                return result;
            }
        }

    }
}
