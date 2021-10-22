using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sales.ConsoleUI
{
    public static class ServiceContainer
    {
        static IServiceProvider ServiceProvider;

        public static void ConfigureServices(Action<IServiceCollection> configureServices)
        {
            IServiceCollection services = new ServiceCollection();
            configureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() => ServiceProvider.GetService<T>();

        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
