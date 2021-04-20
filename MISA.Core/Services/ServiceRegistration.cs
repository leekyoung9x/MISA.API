using Microsoft.Extensions.DependencyInjection;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public static class ServiceRegistration
    {
        public static void AddServiceInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ICustomerService, CustomerService>();
        }
    }
}