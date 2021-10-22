using System;
using Sales.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;
using Sales.DTOs.CreateOrder;
using Sales.Presenters;
using Sales.ViewModels;
using Sales.Views;

namespace Sales.Console.Controllers
{
    public class CreateOrderConsoleController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutPort;

        public CreateOrderConsoleController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outPort) =>
            (InputPort, OutPort) = (inputPort, outPort);

        public async Task<CreateOrderConsoleView> CreateOrder(CreateOrderDto order)
        {
            await InputPort.Handle(order);
            CreateOrderViewModel model = ((IPresenter<CreateOrderViewModel>)OutPort).Content;
            return new CreateOrderConsoleView(model);
        }

    }
}
