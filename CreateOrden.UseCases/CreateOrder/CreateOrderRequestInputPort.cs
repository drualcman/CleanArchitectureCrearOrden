using CrearOrden.UseCasesDTOs.CreateOrder;
using CreateOrden.UseCases.Common.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.CreateOrder
{
    public class CreateOrderRequestInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateOrderRequestInputPort(CreateOrderParams requestData, IOutputPort<int> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
