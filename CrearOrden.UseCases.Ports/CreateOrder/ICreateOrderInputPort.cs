using CrearOrden.UseCasesDTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.UseCases.Ports.CreateOrder
{
    public interface ICreateOrderInputPort
    {
        Task Handle(CreateOrderParams order);
    }
}
