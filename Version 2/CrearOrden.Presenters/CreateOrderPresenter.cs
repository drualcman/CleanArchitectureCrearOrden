using CrearOrden.UseCases.Ports.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Presenters
{
    public class CreateOrderPresenter : IPresenter<string>, ICreateOrderOutputPort
    {
        public string Content { get; private set; }

        public Task Handle(int orderId)
        {
            Content = $"Order ID: {orderId}";
            return Task.CompletedTask;
        }
    }
}
