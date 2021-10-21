using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sales.Entities.Interfaces;

namespace Sales.Mail
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMailServer(this IServiceCollection services)
        {
            services.AddTransient<IMailSender, MailSender>();
            return services;
        }
    }
}
