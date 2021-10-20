using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DTOs.CreateOrder
{
    public class CreateOrderDetailDtoValidator : AbstractValidator<CreateOrderDetailDto>
    {
        public CreateOrderDetailDtoValidator()
        {
            RuleFor(od => od.ProductId).GreaterThan(0).WithMessage("Debe especificar el identificador del producto.");
            RuleFor(od=>od.Quantity).GreaterThan((short)0).WithMessage("Debe especificar la cantidad del producto.");
            RuleFor(od => od.UnitPrice).GreaterThan(0).WithMessage("Debe especificar el precio del producto.");
        }
    }
}
