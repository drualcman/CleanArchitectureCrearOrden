using Sales.DTOs.CreateOrder;
using Sales.Presenters;
using Sales.UseCasesPorts.CreateOrder;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BaseControllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutPort;

        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outPort) =>
            (InputPort, OutPort) = (inputPort, outPort);

        
        public async Task<CreateOrderViewModel> CreateOrder(CreateOrderDto order)
        {
            await InputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)OutPort).Content;
        }
    }
}
