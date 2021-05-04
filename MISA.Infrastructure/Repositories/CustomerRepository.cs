using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MySqlConnector;
using System.Data;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for class Customer
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Hàm kiểm tra mã khách hàng đã tồn tại trên db hay chưa
        /// </summary>
        /// <param name="code">Mã khách hàng</param>
        /// <returns>True nếu đã tồn tại, false nếu chưa tồn tại</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public async Task<bool> CheckCustomerCodeExists(string code)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var sql = "Proc_CheckCustomerCodeExists";
                var result = await dbConnection.QueryFirstOrDefaultAsync<bool>(sql, new { m_CustomerCode = code }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}