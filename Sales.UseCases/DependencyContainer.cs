using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.DTOs.CreateOrder;
using Sales.DTOs.GetOrdersByDate;
using Sales.Events;
using Sales.UseCases.CreateOrder;
using Sales.UseCases.GetOrderByDate;
using Sales.UseCasesPorts.CreateOrder;
using Sales.UseCasesPorts.GetOrdersByDate;
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
            services.AddScoped<IValidator<GetOrdersByDateDto>, GetOrderByDateDtoValidator>();
            services.AddTransient<IGetOrdersByDateInputPort, GetOrdersByDateInteractor>();
            services.AddEventsServices();
            return services;
        }
    }
}
