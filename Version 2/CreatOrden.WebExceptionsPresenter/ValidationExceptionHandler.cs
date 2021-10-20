using CrearOrden.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            ValidationException exception = context.Exception as ValidationException;

            StringBuilder builder = new StringBuilder();
            foreach (var failure in exception.Errors)
            {
                builder.AppendFormat("Propiedad: {0}. Error {1}", failure.PropertyName, failure.ErrorMessage);
            }

            return SetResult(context, StatusCodes.Status400BadRequest, "Error en los datos de entrada.", builder.ToString());
        }
    }
}
