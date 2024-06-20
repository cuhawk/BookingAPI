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
    public class ClientRepository : IClientsRepository
    {
        private readonly PostgresqlDB _context;

        public ClientRepository(PostgresqlDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.Where(w => w.Disabled == false).ToListAsync();
        }
    }
}
