using CrearOrden.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(
                    new ApiExceptionFilterAttribute(
                        new Dictionary<Type, IExceptionHandler>
                        {
                            { typeof(GeneralException), new GeneralExceptionHandler()},
                            { typeof(ValidationException), new ValidationExceptionHandler()},
                        }));
        }
    }
}
