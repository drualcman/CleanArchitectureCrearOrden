using Sales.DTOs.CreateOrder;
using Sales.UseCasesPorts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort : IPort<CreateOrderDto>
    {
    }
}
