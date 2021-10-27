using System;
using Sales.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;
using Sales.DTOs.CreateOrder;
using Sales.Presenters;
using Sales.ViewModels;
using Sales.Views;
using Sales.BaseControllers;

namespace Sales.Console.Controllers
{
    public class CreateOrderConsoleControllerV2
    {
        private readonly ICreateOrderController Controller;
        public CreateOrderConsoleControllerV2(ICreateOrderController controller) => Controller = controller;

        public async Task<CreateOrderConsoleView> CreateOrder(CreateOrderDto order)
        {
            CreateOrderViewModel model = await Controller.CreateOrder(order);
            return new CreateOrderConsoleView(model);
        }

    }
}
