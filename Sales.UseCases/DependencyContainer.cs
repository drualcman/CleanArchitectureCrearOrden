using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.DTOs.CreateOrder;
using Sales.Events;
using Sales.UseCases.CreateOrder;
using Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderDtoValidator>();
            services.AddTransient<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddEventsServices();
            return services;
        }
    }
}
