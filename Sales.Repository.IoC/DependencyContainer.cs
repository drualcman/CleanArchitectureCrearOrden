using Sales.Reppository.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using Sales.UseCases.Common.Interfaces;
using Sales.Reppository.EFCore.Repositories;
using Sales.Entities.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Sales.Repository.ADONET;

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

            services.AddScoped<IDbConnection>(provides => new SqlConnection(configuration.GetConnectionString("SalesDb")));
            services.AddScoped<IOrderReadableRepository, OrderReadableRepository>();

            return services;
        }
    }
}
