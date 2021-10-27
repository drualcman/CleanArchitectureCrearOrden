using Microsoft.AspNetCore.Mvc;
using Sales.BaseControllers;
using Sales.DTOs.CreateOrder;
using Sales.ViewModels;
using System;
using System.Threading.Tasks;

namespace Sales.WebApiControllers
{
    [Route("api/order")]
    [ApiController]
    public class CreateOrderContreller : ControllerBase
    {
        private readonly ICreateOrderController Controller;
        public CreateOrderContreller(ICreateOrderController controller) => Controller = controller;

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto order)
        {
            CreateOrderViewModel createOrderViewModel = await Controller.CreateOrder(order);
            return Ok(createOrderViewModel);
        }
    }
}
