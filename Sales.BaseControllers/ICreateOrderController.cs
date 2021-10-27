using Sales.DTOs.CreateOrder;
using Sales.ViewModels;
using System;
using System.Threading.Tasks;

namespace Sales.BaseControllers
{
    public interface ICreateOrderController
    {
        Task<CreateOrderViewModel> CreateOrder(CreateOrderDto order);
    }
}
