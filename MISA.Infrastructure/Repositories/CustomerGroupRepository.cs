using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for class CustomerGroup
    /// </summary>
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="configuration">Search gg để biết thêm chi tiết - key : IConfiguration .net core</param>
        public CustomerGroupRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}