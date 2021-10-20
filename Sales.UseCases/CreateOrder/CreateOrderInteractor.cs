using FluentValidation;
using Sales.DTOs.CreateOrder;
using Sales.Entities.Events;
using Sales.Entities.Interfaces;
using Sales.Entities.POCOs;
using Sales.Events;
using Sales.UseCases.Common.Interfaces;
using Sales.UseCases.Common.Validators;
using Sales.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderWritableRepository OrderRepository;
        readonly ILogWritableRepository LogRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateOrderDto>> Validators;
        readonly IEventsHub EventsHub;
        readonly IApplicationStatusLogger Logger;

        public CreateOrderInteractor(
            IOrderWritableRepository orderRepository,
            ILogWritableRepository logRepository,
            IUnitOfWork unitOfWork,
            ICreateOrderOutputPort outputPort,
            IEnumerable<IValidator<CreateOrderDto>> validators,
            IEventsHub eventsHub,
            IApplicationStatusLogger logger)
        {
            OrderRepository = orderRepository;
            LogRepository = logRepository;
            UnitOfWork = unitOfWork;
            OutputPort = outputPort;
            Validators = validators;
            EventsHub = eventsHub;
            Logger = logger;
        }


        public async ValueTask Handle(CreateOrderDto orderDto)
        {
            Validator<CreateOrderDto>.Validate(orderDto, Validators, Logger);

            SaleOrder order = OrderRepository.Create(orderDto);
            LogRepository.Add(new Log("Creacion de ordern."));
            await UnitOfWork.SaveChanges();

            if (orderDto.OrderDetails.Count > 3)
            {
                await EventsHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }
            await OutputPort.Handle(order.Id);
        }
    }
}
