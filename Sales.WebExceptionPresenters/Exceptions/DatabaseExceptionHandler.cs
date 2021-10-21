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
    public class DatabaseExceptionHandler : IExceptionHandle<DataBaseUpdateException>
    {
        public ValueTask<ProblemDetails> Handle(DataBaseUpdateException exception)
        {
            Dictionary<string, string> extensions = new Dictionary<string, string>()
            {
                { "Entities", string.Join(",", exception.Entries)}
            };
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5",
                Title = "Error de actualizacion",
                Detail = exception.Message
            };
            problemDetails.Extensions.Add("invalid-params", extensions);
            return ValueTask.FromResult(problemDetails);
        }
    }
}
