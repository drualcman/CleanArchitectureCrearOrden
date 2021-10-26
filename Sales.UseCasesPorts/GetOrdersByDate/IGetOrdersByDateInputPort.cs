using Sales.DTOs.GetOrdersByDate;
using Sales.UseCasesPorts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCasesPorts.GetOrdersByDate
{
    public interface IGetOrdersByDateInputPort : IPort<GetOrdersByDateDto>
    {
    }
}
