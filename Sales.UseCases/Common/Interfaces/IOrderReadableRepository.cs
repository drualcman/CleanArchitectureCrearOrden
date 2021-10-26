using Sales.DTOs.Common;
using Sales.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.Common.Interfaces
{
    public interface IOrderReadableRepository
    {
        IEnumerable<OrderDto> GetOrderWithDetailsBySpecification(Specification<OrderDto> specification);
    }
}
