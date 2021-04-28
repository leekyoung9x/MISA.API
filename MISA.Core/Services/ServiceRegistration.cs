using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Service;

namespace MISA.Core.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerService, CustomerService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ICustomerGroupService, CustomerGroupService>();
            service.AddTransient(typeof(IGenericService<>), typeof(BaseService<>));
        }
    }
}