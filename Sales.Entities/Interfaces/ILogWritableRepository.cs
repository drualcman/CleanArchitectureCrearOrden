using Sales.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Interfaces
{
    public interface ILogWritableRepository
    {
        void Add(Log log);
    }
}
