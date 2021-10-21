using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.WebExceptionPresenters.Exceptions
{
    public class GeneralExceptionHandle : IExceptionHandle<GeneralException>
    {
        public ValueTask<ProblemDetails> Handle(GeneralException exception)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = exception.Message,
                Detail = exception.Detail
            };
            return ValueTask.FromResult(problemDetails);
        }
    }
}
