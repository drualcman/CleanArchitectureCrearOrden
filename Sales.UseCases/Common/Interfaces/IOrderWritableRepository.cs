using Sales.DTOs.CreateOrder;
using Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.Common.Interfaces
{
    public interface IOrderWritableRepository
    {
        SaleOrder Create(CreateOrderDto orderDto);
    }
}
