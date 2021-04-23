using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<int> AddAsync(Customer entity)
        {
            var codeIsExist = await _customerRepository.CheckCustomerCodeExists(entity.CustomerCode);
            if (codeIsExist)
            {
                throw new CustomerException("Mã nhân viên đã tồn tại");
            }
            CustomerException.CustomerCodeRequired(entity.CustomerCode);
            return await base.AddAsync(entity);
        }

        public override Task<int> UpdateAsync(Customer entity)
        {
            CustomerException.CustomerCodeRequired(entity.CustomerCode);
            return base.UpdateAsync(entity);
        }
    }
}