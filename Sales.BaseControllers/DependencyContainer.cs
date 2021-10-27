using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sales.BaseControllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllers(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController, CreateOrderController>();
            return services;
        }
    }
}
