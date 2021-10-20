using CrearOrden.Entities.Interfaces;
using CrearOrden.Presenters;
using CrearOrden.Repositories.EFCore.DataContext;
using CrearOrden.Repositories.EFCore.Repositories;
using CrearOrden.UseCases.Ports.CreateOrder;
using CreateOrden.UseCases.Common.Validators;
using CreateOrden.UseCases.CreateOrder;
using FluentValidation;
//using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrearOrden.InversionOfControl
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DataBaseDb"));
            });
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddMediatR(typeof(CreateOrderHandlerInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<ICreateOrderInputPort, CreateOrderHandlerInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
            return services;
        }
    }
}
