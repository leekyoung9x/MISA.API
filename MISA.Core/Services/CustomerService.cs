using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public override Task<int> UpdateAsync(Customer entity)
        {
            if (string.IsNullOrEmpty(entity.CustomerCode))
            {
                throw new CustomerException("Mã nhân viên không thể để trống!");
            }
            return base.UpdateAsync(entity);
        }
    }
}