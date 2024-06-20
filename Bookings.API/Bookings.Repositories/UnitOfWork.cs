using Bookings.Entities.Interfaces;
using Bookings.RepositoryEF.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PostgresqlDB _context;

        public UnitOfWork(PostgresqlDB context) => _context = context;

        public Task<int> SaveChanges()
        {
            //Bloque Try para excepciones
            return _context.SaveChangesAsync();
        }
    }
}
