using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Class đăng ký DI cho Repository
    /// </summary>
    public static class RepositoryRegistration
    {
        /// <summary>
        /// Hàm đăng ký
        /// </summary>
        /// <param name="service"></param>
        public static void AddRepositoryInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<ICustomerGroupRepository, CustomerGroupRepository>();
            service.AddTransient(typeof(IGenericRepository<>), typeof(BaseRepository<>));
        }
    }
}