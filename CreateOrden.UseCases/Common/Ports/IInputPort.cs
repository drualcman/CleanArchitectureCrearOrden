using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.Common.Ports
{
    public interface IInputPort<InteractorRequestType, InteractorResponseType>
        : IRequest          //implementa el mediador
    {
        public InteractorRequestType RequestData { get; }
        public IOutputPort<InteractorResponseType> OutputPort { get; }
    }
}
