using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DTOs.CreateOrder
{
    public class CreateOrderDtoValidator:AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(o => o.CustomerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(o => o.ShipAddress).NotEmpty().WithMessage("Debe proporcionar la direccion de envio.");
            RuleFor(o => o.ShipCity).NotEmpty().WithMessage("Debe proporcionar la ciudad de envio.")
                .MinimumLength(3).WithMessage("Debe especificar al menos 3 caracteres del nombre de la ciudad.");
            RuleFor(o => o.ShipCountry).NotEmpty().WithMessage("Debe proporcionar el pais de envio.")
                .MinimumLength(3).WithMessage("Debe especificar al menos 3 caracteres del nombre del pais.");
            RuleFor(o => o.OrderDetails).Cascade(CascadeMode.Stop)      //para parar la validacion despues del algun error
                .NotNull().WithMessage("Debe de especificar algun producto.")
                .NotEmpty().WithMessage("Debe de especificar algun producto.");
            RuleForEach(o => o.OrderDetails).SetValidator(new CreateOrderDetailDtoValidator());
        }
    }
}
