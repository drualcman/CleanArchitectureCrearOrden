using Sales.DTOs.CreateOrder;
using Sales.Entities.POCOs;
using Sales.Reppository.EFCore.DataContext;
using Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Reppository.EFCore.Repositories
{
    public class OrderWritableRepository : IOrderWritableRepository
    {
        readonly SalesContext Context;

        public OrderWritableRepository(SalesContext context) => Context = context;

        public SaleOrder Create(CreateOrderDto orderDto)
        {
            SaleOrder order = new SaleOrder 
            {
                CustomerId = orderDto.CustomerId,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipCountry = orderDto.ShipCountry,
                ShipPostalcode = orderDto.ShipPostacode
            };
            foreach (CreateOrderDetailDto product in orderDto.OrderDetails)
            {
                order.Add(product.ProductId, product.UnitPrice, product.Quantity);
            }
            Context.Add(order);
            return order;
        }
    }
}
