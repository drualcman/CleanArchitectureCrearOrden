using CrearOrden.Presenters;
using CrearOrden.UseCasesDTOs.CreateOrder;
using CreateOrden.UseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrearOrden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) =>
            Mediator = mediator;

        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderParams)
        {
            CreateOrderPresenter presenter = new CreateOrderPresenter();
            await Mediator.Send(new CreateOrderRequestInputPort(orderParams, presenter));
            return presenter.Content;
        }
    }
}
