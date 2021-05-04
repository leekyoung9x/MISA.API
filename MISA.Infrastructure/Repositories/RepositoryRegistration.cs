using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repositories
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<ICustomerGroupRepository, CustomerGroupRepository>();
            service.AddTransient(typeof(IGenericRepository<>), typeof(BaseRepository<>));
        }
    }
}