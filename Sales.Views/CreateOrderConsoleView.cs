using System;
using Sales.ViewModels;

namespace Sales.Views
{
    public class CreateOrderConsoleView
    {
        readonly CreateOrderViewModel Model;

        public CreateOrderConsoleView(CreateOrderViewModel model) => Model = model;

        public void ExecuteResult()
        {
            Console.WriteLine($"Se ha creado la order {Model.OrderId}");
        }

    }
}
