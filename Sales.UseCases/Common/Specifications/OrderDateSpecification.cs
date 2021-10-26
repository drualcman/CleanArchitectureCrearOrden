using Sales.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.Common.Specifications
{
    public class OrderDateSpecification : Entities.Specifications.Specification<OrderDto>
    {
        readonly DateTime OrderDate;
        public OrderDateSpecification(DateTime orderDate) => OrderDate = orderDate;
        public override Expression<Func<OrderDto, bool>> ConditionExpresion => 
            (o=> o.OrderDate.Date == OrderDate.Date);

        //public override Expression<Func<OrderDto, bool>> ConditionExpresion
        //{
        //    get
        //    {
        //        return (o => o.OrderDate.Date == OrderDate.Date);
        //    }
        //}
            
    }
}
