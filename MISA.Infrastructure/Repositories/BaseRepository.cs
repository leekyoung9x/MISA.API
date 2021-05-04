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
    /// <summary>
    /// Repository với những hàm dùng chung
    /// </summary>
    /// <typeparam name="T"></typeparam>
    ///
    public class BaseRepository<T> : IGenericRepository<T>
    {
        /// <summary>
        /// Biến lấy chuỗi connectionString
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        protected readonly IConfiguration _configuration;

        //protected readonly IDbConnection dbConnection;
        /// <summary>
        /// Chuỗi kết nối đến csdl
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        protected readonly string connectionString;

        /// <summary>
        /// Tên bảng
        /// </summary>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        protected readonly string tableName;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration">Search gg để biết thêm chi tiết - key : IConfiguration .net core</param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            //dbConnection = new MySqlConnection(_configuration.GetConnectionString("CukCukConnection"));
            connectionString = _configuration.GetConnectionString("CukCukConnection");
            tableName = typeof(T).Name;
        }

        /// <summary>
        /// Hàm thêm một thực thể vào db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn thêm</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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

        /// <summary>
        /// Hàm xóa một thực thể trên db
        /// </summary>
        /// <param name="id">Mã định danh thực thể muốn xóa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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

        /// <summary>
        /// Hàm lấy ra danh sách thực thể
        /// </summary>
        /// <returns>Trả về danh sách thực thể</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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

        /// <summary>
        /// Hàm lấy ra thực thể với id truyền vào
        /// </summary>
        /// <param name="id">Mã định danh thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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

        /// <summary>
        /// Hàm sửa một thực thể trên db
        /// </summary>
        /// <param name="entity">Thông tin thực thể muốn sửa</param>
        /// <returns>Trả về 1 nều thêm thành công, 0 nếu thất bại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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

        /// <summary>
        /// Hàm tạo tham số động từ class entity
        /// </summary>
        /// <param name="entity">Thông tin thực thể</param>
        /// <returns>Tham số động</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public DynamicParameters MappingParams(T entity)
        {
            DynamicParameters parameters = new DynamicParameters();

            // Lấy ra toàn bộ thuộc tính của thực thể
            var properties = typeof(T).GetProperties();

            foreach (var item in properties)
            {
                // Lấy ra thông tin của thuộc tính
                var propertyName = item.Name;
                var propertyValue = item.GetValue(entity);
                var propertyType = item.PropertyType;

                // Kiểm tra kiểu Guid
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

        /// <summary>
        /// Hàm lấy ra thực thể với mã truyền vào
        /// </summary>
        /// <param name="code">Mã thực thể</param>
        /// <returns>Trả về thông tin thực thể - entity - T</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
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