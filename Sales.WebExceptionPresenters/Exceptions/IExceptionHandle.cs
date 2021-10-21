using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sales.WebExceptionPresenters.Exceptions
{
    public interface IExceptionHandle<ExceptionType>
    {
        ValueTask<ProblemDetails> Handle (ExceptionType exceptionType);
    }
}
