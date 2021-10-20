using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Events
{
    public interface IEventsHub
    {
        public Task Raise<EventType>(EventType eventInstance)
            where EventType : INotification;
    }
}
