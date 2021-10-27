using Sales.DTOs.GetOrdersByDate;
using Sales.Presenters;
using Sales.UseCasesPorts.Common;
using Sales.UseCasesPorts.GetOrdersByDate;
using Sales.ViewModels;
using Sales.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Console.Controllers
{
    public class GetOrdersByDateController
    {
        readonly IGetOrdersByDateInputPort InputPort;
        readonly IGetOrdersOutputPort Output;

        public GetOrdersByDateController(IGetOrdersByDateInputPort inputPort, IGetOrdersOutputPort output) =>
            (InputPort, Output) = (inputPort, output);

        public async Task<OrdersConsoleView> GetOrderByDate(DateTime orderDate)
        {
            await InputPort.Handle(new GetOrdersByDateDto { Date = orderDate });
            OrdersConsoleView ordersConsoleView = new OrdersConsoleView(((IPresenter<OrdersViewModel>)Output).Content);
            return ordersConsoleView;
        }
    }
}
