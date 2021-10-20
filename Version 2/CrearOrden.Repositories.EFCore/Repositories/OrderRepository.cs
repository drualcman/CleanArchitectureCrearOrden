using CrearOrden.Entities.Interfaces;
using CrearOrden.Entities.POCOEntities;
using CrearOrden.Entities.Specifications;
using CrearOrden.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly DataBaseContext Context;
        public OrderRepository(DataBaseContext context) => Context = context;

        public void Create(Order order) => Context.Add(order);

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            Func<Order, bool> expresionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(expresionDelegate);
        }
    }
}
