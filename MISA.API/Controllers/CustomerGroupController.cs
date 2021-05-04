using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;

namespace MISA.API.Controllers
{
    /// <summary>
    /// API Controller for class CustomerGroup
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="customerGroupService"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
        }
    }
}