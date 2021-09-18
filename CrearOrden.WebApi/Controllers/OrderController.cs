using CreateOrden.UseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrearOrden.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) =>
            Mediator = mediator;

        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderRequestInputPort orderParams) =>
            await Mediator.Send(orderParams);

    }
}
