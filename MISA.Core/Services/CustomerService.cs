using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.Core.Services
{
    /// <summary>
    /// Class thể hiện các dịch vụ cho class Customer
    /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="customerRepository">Interface repository cho class Customer</param>
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public override async Task<int> AddAsync(Customer entity)
        //{
        //    var codeIsExist = await _customerRepository.CheckCustomerCodeExists(entity.CustomerCode);
        //    if (codeIsExist)
        //    {
        //        throw new CustomerException("Mã nhân viên đã tồn tại");
        //    }
        //    CustomerException.CustomerCodeRequired(entity.CustomerCode);
        //    return await base.AddAsync(entity);
        //}

        //public override Task<int> UpdateAsync(Customer entity)
        //{
        //    CustomerException.CustomerCodeRequired(entity.CustomerCode);
        //    return base.UpdateAsync(entity);
        //}
    }
}