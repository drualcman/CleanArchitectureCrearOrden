using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Entities.Exceptions
{
    public class GeneralException : Exception
    {
        public string Detail { get; set; }
        public GeneralException() { }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, Exception inner) : base(message, inner) { }
        public GeneralException(string title, string detail) : base(title) => Detail = detail;
    }
}
