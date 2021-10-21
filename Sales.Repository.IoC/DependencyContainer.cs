using Sales.Reppository.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using Sales.UseCases.Common.Interfaces;
using Sales.Reppository.EFCore.Repositories;
using Sales.Entities.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Sales.Repository.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesContext>(option => 
            {
                option.UseSqlServer(
                    configuration.GetConnectionString("SalesDb"));
            });
            services.AddScoped<IOrderWritableRepository, OrderWritableRepository>();
            services.AddScoped<ILogWritableRepository, LogWritableRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
