using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sales.WebExceptionPresenters.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.WebExceptionPresenters.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly ExceptionService Service;

        public ApiExceptionFilterAttribute(ExceptionService service) => Service = service;

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            ProblemDetails problemDetails = await Service.Handle(context.Exception);
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
            context.ExceptionHandled = true;
            await base.OnExceptionAsync(context);
        }
    }
}
