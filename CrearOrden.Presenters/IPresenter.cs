using System;

namespace CrearOrden.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
