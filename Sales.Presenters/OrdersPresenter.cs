using Sales.DTOs.Common;
using Sales.UseCasesPorts.Common;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Presenters
{
    public class OrdersPresenter : IGetOrdersOutputPort, IPresenter<OrdersViewModel>
    {
        public OrdersViewModel Content { get; private set; }

        public ValueTask Handle(IEnumerable<OrderDto> orders)
        {
            Content = new OrdersViewModel(orders);
            return ValueTask.CompletedTask;
        }
    }
}
