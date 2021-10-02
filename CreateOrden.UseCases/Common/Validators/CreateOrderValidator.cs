using CrearOrden.UseCasesDTOs.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.Common.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderParams>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Debe proporcionar el id del cliente");
            RuleFor(c => c.ShipAddress).NotEmpty().WithMessage("Debe de proporcionar una direccion");
            RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3).WithMessage("Debe de proporcionar al menos 3 caracteres del nombre de la ciudad");
            RuleFor(c => c.ShipCountry).NotEmpty().MinimumLength(3).WithMessage("Debe de proporcionar al menos 3 caracteres del nombre del pais");
            RuleFor(d => d.OrderDetails).Must(d=> d != null && d.Any()).WithMessage("Deben especificarse productos.");
        }
    }
}
