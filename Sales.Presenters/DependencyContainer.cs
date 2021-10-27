using Microsoft.Extensions.DependencyInjection;
using Sales.UseCasesPorts.Common;
using Sales.UseCasesPorts.CreateOrder;
using System;

namespace Sales.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {            
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
            services.AddScoped<IGetOrdersOutputPort, OrdersPresenter>();
            return services;
        }
    }
}
