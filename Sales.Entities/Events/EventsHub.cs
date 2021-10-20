using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Events
{
    public class EventsHub : IEventsHub
    {
        IMediator Mediator;
        public EventsHub(IMediator mediator) => Mediator = mediator;

        public async Task Raise<EventType>(EventType eventInstance) where EventType : INotification
        {
            await Mediator.Publish(eventInstance);
        }
    }
}
