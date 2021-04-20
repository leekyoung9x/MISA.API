using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;

namespace MISA.Infrastructure.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}