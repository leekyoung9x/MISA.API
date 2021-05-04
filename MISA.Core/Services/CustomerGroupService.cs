using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;

namespace MISA.Core.Services
{
    /// <summary>
    /// Class dịch vụ cho class CustomerGroup
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="customerGroupRepository">Interface repository của class CustomerGroup</param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
        }
    }
}