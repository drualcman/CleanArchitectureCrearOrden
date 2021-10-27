using Sales.DTOs.Common;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Views
{
    public class OrdersConsoleView
    {
        readonly OrdersViewModel Model;
        public OrdersConsoleView(OrdersViewModel model) => Model = model;

        public void ExecuteResult()
        {
            foreach (OrderDto order in Model.Orders)
            {
                Console.WriteLine($"Order: {order.OrderId}");
                Console.WriteLine($"Cliente: {order.CustomerName}");
                Console.WriteLine($"Fecha: {order.OrderDate}");
                Console.WriteLine("Direcion de envio:");
                Console.WriteLine($"\t: {order.ShipAddress}");
                Console.WriteLine($"\t: {order.ShipCity}, {order.ShipPostalCode}");
                Console.WriteLine($"\t: {order.ShipCountry}");
                Console.WriteLine(new string('-', 60));                
                foreach (OrderDetailDto item in order.OrdersDetail)
                {
                    Console.WriteLine("{0,3} {1,-40} {2, 6:C2} {3, 4}",
                        item.ProdcutId, item.ProdutName, item.UnitPrice, item.Quantity);
                }
                Console.WriteLine(new string('-', 60));
                Console.WriteLine();
            }
        }
    }
}
