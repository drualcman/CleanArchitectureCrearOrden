using Sales.Entities.Interfaces;
using Sales.Entities.POCOs;
using Sales.Reppository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Reppository.EFCore.Repositories
{
    public class LogWritableRepository : ILogWritableRepository
    {
        readonly SalesContext Context;

        public LogWritableRepository(SalesContext context) => Context = context;

        public void Add(Log log)
        {
            Context.Add(log);
        }
    }
}
