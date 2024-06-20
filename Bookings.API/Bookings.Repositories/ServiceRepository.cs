using Bookings.Entities.Interfaces;
using Bookings.Entities.Models;
using Bookings.RepositoryEF.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PostgresqlDB _context;

        public ServiceRepository(PostgresqlDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
