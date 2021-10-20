using CrearOrden.Entities.Interfaces;
using CrearOrden.Entities.POCOEntities;
using CrearOrden.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly DataBaseContext Context;
        public OrderDetailRepository(DataBaseContext context) => Context = context;

        public void Create(OrderDetail orderDetail) => Context.Add(orderDetail);
    }
}
