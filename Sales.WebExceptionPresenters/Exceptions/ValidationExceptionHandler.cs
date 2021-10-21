using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.WebExceptionPresenters.Exceptions
{
    public class ValidationExceptionHandler : IExceptionHandle<ValidationException>
    {
        public ValueTask<ProblemDetails> Handle(ValidationException exception)
        {
            Dictionary<string, string> extensions = new Dictionary<string, string>();
            foreach (ValidationFailure failure in exception.Errors)
            {
                if (extensions.ContainsKey(failure.PropertyName))
                {
                    extensions[failure.PropertyName] += " " + failure.ErrorMessage;
                }
                else
                {
                    extensions.Add(failure.PropertyName, failure.ErrorMessage);
                }
            }
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5",
                Title = "Error en los datos de entrada.",
                Detail = "Se encontro uno o mas errores en la validacion de los datos."
            };
            problemDetails.Extensions.Add("invalid-params", extensions);
            return ValueTask.FromResult(problemDetails);
        }
    }
}
