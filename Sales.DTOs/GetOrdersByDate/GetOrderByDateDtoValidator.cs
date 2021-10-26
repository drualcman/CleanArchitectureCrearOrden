using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DTOs.GetOrdersByDate
{
    public class GetOrderByDateDtoValidator : AbstractValidator<GetOrdersByDateDto>
    {
        public GetOrderByDateDtoValidator()
        {
            RuleFor(d=> d.Date).GreaterThan(DateTime.MinValue).WithMessage("Debe proporcionar la fecha a consultar.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Debe proporcionar una fecha menor o igual a la fecha actual");
        }
    }
}
