using CrearOrden.Entities.Interfaces;
using CrearOrden.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DataBaseContext Context;
        public UnitOfWork(DataBaseContext context) => Context = context;

        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
    }
}
