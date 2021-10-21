using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities.Exceptions;

namespace Sales.WebExceptionPresenters.Exceptions
{
    public class ExceptionService
    {
        readonly Dictionary<Type, Type> ExceptionHandlers = new Dictionary<Type, Type>();

        public ExceptionService()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                IEnumerable<Type> handlers = type.GetInterfaces()
                    .Where(i => i.IsGenericType && 
                                i.GetGenericTypeDefinition() == typeof(IExceptionHandle<>));
                foreach (Type item in handlers)
                {
                    var exceptionType = item.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(exceptionType, item);
                };
            }
        }

        public ValueTask<ProblemDetails> Handle(Exception exception)
        {
            ValueTask<ProblemDetails> result;

            if (ExceptionHandlers.TryGetValue(exception.GetType(), out Type handlerType))
            {
                var handler = Activator.CreateInstance(handlerType);
                result = (ValueTask<ProblemDetails>)handlerType.GetMethod("Handler")
                    .Invoke(handler, new object[] { exception });
            }
            else
            {
                result = new GeneralExceptionHandle()
                    .Handle(new GeneralException("Ha ocurrido un error al procesar la respuesta", "Consulte al administrador."));
            }

            return result;
        }
    }
}
