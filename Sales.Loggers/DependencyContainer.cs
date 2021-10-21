using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sales.Entities.Interfaces;

namespace Sales.Loggers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            services.AddTransient<IApplicationStatusLogger, DebugStatusLogger>();
            return services;
        }
    }
}
