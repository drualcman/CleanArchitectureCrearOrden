using FluentValidation;
using FluentValidation.Results;
using Sales.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.UseCases.Common.Validators
{
    public static class Validator<Model>
    {
        public static void Validate(Model model, 
            IEnumerable<IValidator<Model>> validators, 
            IApplicationStatusLogger logger = null)
        {
            List<ValidationFailure> failures = validators.Select(v=> v.Validate(model))
                .SelectMany(r=>r.Errors).Where(f=>f != null).ToList();

            if (failures.Count > 0)
            {
                if (logger != null)
                {
                    StringBuilder sb = new StringBuilder("Error en la entrada de datos.");
                    foreach (ValidationFailure failure in failures)
                    {
                        sb.AppendLine($"{failure.PropertyName}: {failure.ErrorMessage}");
                    }
                    logger.Log(sb.ToString());
                }
                throw new ValidationException(failures);
            }
        }
    }
}
