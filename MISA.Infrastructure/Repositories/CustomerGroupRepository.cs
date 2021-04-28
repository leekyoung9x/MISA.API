using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}