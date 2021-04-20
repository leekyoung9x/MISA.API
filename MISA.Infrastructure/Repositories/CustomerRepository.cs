using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}