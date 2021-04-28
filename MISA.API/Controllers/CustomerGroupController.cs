using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;

namespace MISA.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
        }
    }
}