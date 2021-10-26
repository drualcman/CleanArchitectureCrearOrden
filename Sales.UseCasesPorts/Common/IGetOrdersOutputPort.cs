using Sales.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCasesPorts.Common
{
    public interface IGetOrdersOutputPort : IPort<IEnumerable<OrderDto>>
    {
    }
}
