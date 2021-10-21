using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Exceptions
{
    public class DataBaseUpdateException :  Exception
    {
        public IReadOnlyList<string> Entries { get; }
        public DataBaseUpdateException() { }
        public DataBaseUpdateException(string message) : base(message) { }
        public DataBaseUpdateException(string message, Exception inner) : base(message, inner) { }
        public DataBaseUpdateException(string message, IReadOnlyList<string> entries):
            base(message) => Entries = entries;
        
    }
}
