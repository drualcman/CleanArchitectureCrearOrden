using CreateOrden.UseCases.Common.Ports;
using System;

namespace CrearOrden.Presenters
{
    public interface IPresenter<ResponseType, FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
