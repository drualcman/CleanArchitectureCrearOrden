using CrearOrden.Entities.Exceptions;
using CrearOrden.Entities.Interfaces;
using CrearOrden.Entities.POCOEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.CreateOrder
{
    public class CreateOrderHandlerInteractor : IRequestHandler<CreateOrderRequestInputPort, int>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        public CreateOrderHandlerInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork) = (orderRepository, orderDetailRepository, unitOfWork);

        public async Task<int> Handle(CreateOrderRequestInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = CrearOrden.Entities.Enums.ShippingType.Road,
                DiscountType = CrearOrden.Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(order);
            foreach (var item in request.OrderDetails)
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
            return order.Id;
        }
    }
}
