using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Events
{
    public class SpecialOrderCreatedEvent : INotification
    {
        public int OrderId { get; set; }
        public int ProductsCount { get; set; }
        public SpecialOrderCreatedEvent(int orderId, int productsCount) => 
            (OrderId, ProductsCount) = (orderId, productsCount);
    }
}
