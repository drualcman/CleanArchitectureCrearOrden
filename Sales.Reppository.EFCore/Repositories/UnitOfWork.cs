using Microsoft.EntityFrameworkCore;
using Sales.Entities.Exceptions;
using Sales.Entities.Interfaces;
using Sales.Reppository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Reppository.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        readonly SalesContext Context;
        readonly IApplicationStatusLogger Logger;

        public UnitOfWork(SalesContext context, IApplicationStatusLogger logger) => 
            (Context, Logger) = (context, logger);

        public async Task<int> SaveChanges()
        {
            int result;
            try
            {
                result = await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Logger.Log(ex.InnerException?.Message ?? ex.Message);
                throw new DataBaseUpdateException(ex.InnerException?.Message ?? ex.Message,
                    ex.Entries.Select(e => e.GetType().Name).ToList());
            }
            catch  (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new GeneralException(ex.Message);
            }
            return result;
        }
    }
}
