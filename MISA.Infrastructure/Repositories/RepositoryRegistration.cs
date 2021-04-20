using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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