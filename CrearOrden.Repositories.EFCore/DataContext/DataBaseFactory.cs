using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearOrden.Repositories.EFCore.DataContext
{
    /// <summary>
    /// Esta clase se usa solo en tiempo de diseño para poder crear la base de datos dierectamente
    /// </summary>
    class DataBaseFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DataBaseContext> optionBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=CrearOrdenDb");
            return new DataBaseContext(optionBuilder.Options);
        }
    }
}
