using Sales.Console.Controllers;
using Sales.DTOs.CreateOrder;
using Sales.Loggers;
using Sales.Mail;
using Sales.Presenters;
using Sales.Repository.IoC;
using Sales.UseCases;
using Sales.UseCasesPorts.CreateOrder;
using Sales.Views;
using System;
using System.Collections.Generic;

namespace Sales.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceContainer.ConfigureServices(services => {
                services.AddEventsHub()
                .AddLoggers()
                .AddMailServer()
                .AddRepositories(ServiceContainer.Configuration)
                .AddUseCases()
                .AddPresenters();
            });

            System.Console.WriteLine("Hello World!");
            CreateOrder();
        }

        static void CreateOrder()
        {
            CreateOrderConsoleController controller = new CreateOrderConsoleController(
                ServiceContainer.GetService<ICreateOrderInputPort>(),
                ServiceContainer.GetService<ICreateOrderOutputPort>());
            try
            {
                CreateOrderDto order = new CreateOrderDto
                {
                    CustomerId = "ALFKI",
                    ShipAddress = "5 sur 907",
                    ShipCity = "Puebla",
                    ShipCountry = "Mexico",
                    ShipPostacode = "72500",
                    OrderDetails = new List<CreateOrderDetailDto> {
                        new CreateOrderDetailDto {
                            ProductId = 1,
                            Quantity = 1,
                            UnitPrice = 20
                        }
                    }
                };
                CreateOrderConsoleView view = controller.CreateOrder(order).Result;
                view.ExecuteResult();
                
            }
            catch (Exception ex)
            {
                new ErrorConsoleView(ex).ExecuteResult();
            }
        }
    }
}
