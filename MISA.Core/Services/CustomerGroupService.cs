using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
        }
    }
}