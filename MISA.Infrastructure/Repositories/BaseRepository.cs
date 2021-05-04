using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T>
    {
        protected readonly IConfiguration _configuration;
        //protected readonly IDbConnection dbConnection;

        protected readonly string connectionString;
        protected readonly string tableName;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            //dbConnection = new MySqlConnection(_configuration.GetConnectionString("CukCukConnection"));
            connectionString = _configuration.GetConnectionString("CukCukConnection");
            tableName = typeof(T).Name;
        }

        public async Task<int> AddAsync(T entity)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Insert{tableName}";
                var paramaters = MappingParams(entity);
                var result = await dbConnection.ExecuteAsync(sql,
                                                  paramaters,
                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Delete{tableName}";
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add($"{tableName}Id", id);
                var result = await dbConnection.ExecuteAsync(sql,
                                                  paramaters,
                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}s";
                var result = await dbConnection.QueryAsync<T>(sql,
                                                             commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<T> GetByIdAsync(string id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}ById";
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add($"{tableName}Id", id);
                var result = await dbConnection.QueryFirstOrDefaultAsync<T>(sql,
                                                  paramaters,
                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Update{tableName}";
                var paramaters = MappingParams(entity);
                var result = await dbConnection.ExecuteAsync(sql,
                                                  paramaters,
                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public DynamicParameters MappingParams(T entity)
        {
            DynamicParameters parameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();

            foreach (var item in properties)
            {
                var propertyName = item.Name;
                var propertyValue = item.GetValue(entity);
                var propertyType = item.PropertyType;

                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            return parameters;
        }

        public async Task<T> GetByCodeAsync(string code)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_Get{tableName}ByCode";
                DynamicParameters paramaters = new DynamicParameters();
                paramaters.Add($"{tableName}Code", code);
                var result = await dbConnection.QueryFirstOrDefaultAsync<T>(sql,
                                                  paramaters,
                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}