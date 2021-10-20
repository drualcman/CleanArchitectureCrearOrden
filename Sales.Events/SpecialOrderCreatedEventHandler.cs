using MediatR;
using Sales.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Events
{
    public class SpecialOrderCreatedEventHandler : INotificationHandler<SpecialOrderCreatedEvent>
    {
        readonly IMailSender Sender;
        public SpecialOrderCreatedEventHandler(IMailSender sender) =>
            Sender = sender;

        public Task Handle(SpecialOrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Sender.Send($"Orden {notification.OrderId} con {notification.ProductsCount} productos.");
        }
    }
}
