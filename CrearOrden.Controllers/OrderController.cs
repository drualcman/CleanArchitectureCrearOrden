using CrearOrden.Presenters;
using CrearOrden.UseCases.Ports.CreateOrder;
using CrearOrden.UseCasesDTOs.CreateOrder;
using CreateOrden.UseCases.CreateOrder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrearOrden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;
        public OrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderParams)
        {
            await InputPort.Handle(orderParams);
            //hacer uso del polimorfismo
            //como createorderpresenter implenta las 2 interfaces gracias a la injeccion de dependencias
            //podremos acceder a la otra interfaz que es la que va a mostrar los datos
            IPresenter<string> presenter = OutputPort as CreateOrderPresenter;
            return presenter.Content;
        }
    }
}
