using CrearOrden.Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            GeneralException exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError, exception.Message, exception.Detail);
        }
    }
}
