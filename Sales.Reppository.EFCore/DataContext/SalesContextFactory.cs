using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Reppository.EFCore.DataContext
{
    public class SalesContextFactory : IDesignTimeDbContextFactory<SalesContext>
    {
        /// <summary>
        /// ejecutar 
        /// add-migration InitialCreation -p Sales.Reppository.EFCore -c SalesContext -s Sales.Reppository.EFCore
        /// update-database -p Sales.Reppository.EFCore -s Sales.Reppository.EFCore
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SalesContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SalesContext> optionsBuilder = new DbContextOptionsBuilder<SalesContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=SalesDb");
            return new SalesContext(optionsBuilder.Options);
        }
    }
}
