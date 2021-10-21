using Microsoft.AspNetCore.Mvc;
using System;
using Sales.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;
using Sales.DTOs.CreateOrder;
using Sales.Presenters;
using Sales.ViewModels;

namespace Sales.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class CreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutPort;

        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outPort) =>
            (InputPort, OutPort) = (inputPort, outPort);

        [HttpPost("create")]
        public async Task<int> CreateOrder(CreateOrderDto order)
        {
            await InputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)OutPort).Content.OrderId;
        }

    }
}
