using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Service;

namespace MISA.Core.Services
{
    /// <summary>
    /// Class đăng kí DI cho các Service
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public static class ServiceRegistration
    {
        /// <summary>
        /// Hàm đăng ký
        /// </summary>
        /// <param name="service"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public static void AddServiceInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerService, CustomerService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ICustomerGroupService, CustomerGroupService>();
            service.AddTransient(typeof(IGenericService<>), typeof(BaseService<>));
        }
    }
}