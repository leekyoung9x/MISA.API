using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> CheckCustomerCodeExists(string code)
        {
            var sql = "Proc_CheckCustomerCodeExists";
            var result = await dbConnection.QueryFirstOrDefaultAsync<bool>(sql, new { m_CustomerCode = code }, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}