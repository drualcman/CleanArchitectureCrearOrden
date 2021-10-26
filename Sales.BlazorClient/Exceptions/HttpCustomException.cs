using System;

namespace Sales.BlazorClient.Exceptions
{
    public class HttpCustomException : Exception
    {
        public ProblemsDetails Problems { get; set; }
        public HttpCustomException() { }
        public HttpCustomException(string message) : base(message){ }
        public HttpCustomException(string message, Exception innerException) : base(message, innerException){ }
        public HttpCustomException(ProblemsDetails details) : base(details.Title) => 
            Problems = details;
    }
}
