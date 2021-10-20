using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOrden.UseCases.Common.Validators
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model, 
            IEnumerable<IValidator<Model>> validators, bool causesException = true)
        {
            List<ValidationFailure> failures = validators
                .Select(validator => validator.Validate(model))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();
            if (failures.Any() && causesException)
            {
                throw new ValidationException(failures);
            }
            return Task.FromResult(failures);
        }
    }
}
