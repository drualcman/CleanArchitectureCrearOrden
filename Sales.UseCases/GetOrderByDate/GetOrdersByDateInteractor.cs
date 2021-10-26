using FluentValidation;
using Sales.DTOs.Common;
using Sales.DTOs.GetOrdersByDate;
using Sales.Entities.Interfaces;
using Sales.Entities.POCOs;
using Sales.UseCases.Common.Interfaces;
using Sales.UseCases.Common.Specifications;
using Sales.UseCases.Common.Validators;
using Sales.UseCasesPorts.Common;
using Sales.UseCasesPorts.GetOrdersByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.GetOrderByDate
{
    public class GetOrdersByDateInteractor : IGetOrdersByDateInputPort
    {
        readonly ILogWritableRepository LogRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IOrderReadableRepository Repository;
        readonly IGetOrdersOutputPort Output;
        readonly IEnumerable<IValidator<GetOrdersByDateDto>> Validators;
        readonly IApplicationStatusLogger Logger;

        public GetOrdersByDateInteractor(
            ILogWritableRepository logRepository,
            IUnitOfWork unitOfWork,
            IOrderReadableRepository repository,
            IGetOrdersOutputPort output,
            IEnumerable<IValidator<GetOrdersByDateDto>> validators,
            IApplicationStatusLogger logger) =>
            (LogRepository, UnitOfWork, Repository, Output, Validators, Logger) =
            (logRepository, unitOfWork, repository, output, validators, logger);

        public async ValueTask Handle(GetOrdersByDateDto order)
        {
            Validator<GetOrdersByDateDto>.Validate(order, Validators, Logger);
            IEnumerable<OrderDto> orders = Repository.GetOrderWithDetailsBySpecification(new OrderDateSpecification(order.Date));
            LogRepository.Add(new Log($"Consulta ordenes a fecha {order.Date}"));
            await UnitOfWork.SaveChanges();
            await Output.Handle(orders);
        }
    }
}
