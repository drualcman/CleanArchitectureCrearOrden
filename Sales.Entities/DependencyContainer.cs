using Microsoft.Extensions.DependencyInjection;
using Sales.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEventsHub(this IServiceCollection services)
        {
            services.AddScoped<IEventsHub, EventsHub>();
            return services;
        }
    }
}
