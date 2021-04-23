using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;

namespace MISA.Core.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerService, CustomerService>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}