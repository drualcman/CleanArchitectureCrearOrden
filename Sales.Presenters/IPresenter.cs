using System;

namespace Sales.Presenters
{
    public interface IPresenter<FormatType>
    {
        public FormatType Content { get; }
    }
}
