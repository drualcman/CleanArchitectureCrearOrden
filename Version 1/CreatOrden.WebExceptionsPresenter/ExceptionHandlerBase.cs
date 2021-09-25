using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.WebExceptionsPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types = new Dictionary<int, string>()
        {
            { StatusCodes.Status404NotFound, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"},
            { StatusCodes.Status400BadRequest, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"},
            { StatusCodes.Status500InternalServerError, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"}
        };

        public Task SetResult(ExceptionContext context, int? status, string title, string detail)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC7231Types.ContainsKey(status.Value) ? RFC7231Types[status.Value] : "",
                Detail = detail
            };
            context.Result = new ObjectResult(detail)
            {
                StatusCode = status
            };
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
