using CrearOrden.Entities.Exceptions;
using CrearOrden.Entities.Interfaces;
using CrearOrden.Entities.POCOEntities;
using CrearOrden.UseCases.Ports.CreateOrder;
using CrearOrden.UseCasesDTOs.CreateOrder;
using CreateOrden.UseCases.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.CreateOrder
{
    public class CreateOrderHandlerInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> Validators;

        public CreateOrderHandlerInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork,
            ICreateOrderOutputPort outputPort, IEnumerable<IValidator<CreateOrderParams>> validators) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork, OutputPort, Validators) = 
            (orderRepository, orderDetailRepository, unitOfWork, outputPort,validators);

        public async Task Handle(CreateOrderParams Order)
        {
            CreateOrderValidator validation = new CreateOrderValidator();
            validation.Validate(Order);

            await Validator<CreateOrderParams>.Validate(Order, Validators);

            Order order = new Order
            {
                CustomerId = Order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = Order.ShipAddress,
                ShipCity = Order.ShipCity,
                ShipCountry = Order.ShipCountry,
                ShipPostalCode = Order.ShipPostalCode,
                ShippingType = CrearOrden.Entities.Enums.ShippingType.Road,
                DiscountType = CrearOrden.Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(order);
            foreach (var item in Order.OrderDetails)
            {
                OrderDetailRepository.Create(new OrderDetail
                {
                    ProductId = item.ProductId,
                    Order = order,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice = item.UnitPrice
                });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();    
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden", ex.Message);
            }
            await OutputPort.Handle(order.Id);
        }

    }
}
