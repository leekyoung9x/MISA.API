using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
        }

        public override Task<int> AddAsync(Customer entity)
        {
            CustomerException.CustomerCodeRequired(entity.CustomerCode);
            return base.AddAsync(entity);
        }

        public override Task<int> UpdateAsync(Customer entity)
        {
            CustomerException.CustomerCodeRequired(entity.CustomerCode);
            return base.UpdateAsync(entity);
        }
    }
}