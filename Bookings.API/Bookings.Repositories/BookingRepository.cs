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
    public class BookingRepository : IBookingRepository
    {
        private readonly PostgresqlDB _context;

        public BookingRepository(PostgresqlDB context)
        {
            _context = context;
        }

        public async Task Create(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByDocumentAsync(string? documentnumber, string? idservice, string? idclient)
        {
            return await _context.Bookings
                                .Join( _context.Clients,
                                        booking => booking.Idclient,
                                        clients => clients.Idclient,
                                        (booking, clients) => new { booking, clients })
                .Where(w => w.booking.Documentnumber == (!string.IsNullOrWhiteSpace(documentnumber) ? documentnumber : w.booking.Documentnumber)
                            && w.clients.Idservice == (idservice != null ? idservice : w.clients.Idservice)
                            && w.clients.Idclient == (idclient != null ? idclient : w.clients.Idclient)
                            )
                .Select(s => new Booking { 
                    Idbooking = s.booking.Idbooking,
                    Idclient = s.booking.Idclient,
                    Documentnumber = s.booking.Documentnumber,
                    Name = s.booking.Name,
                    Amount = s.booking.Amount,
                    Bookingdate = s.booking.Bookingdate,
                    Creationdate = s.booking.Creationdate,
                }).ToListAsync();
        }

        public async Task<Booking?> GetById(string? id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(x => x.Idbooking == id);
        }

        public Task Update(Booking booking)
        {
            _context.Bookings.Update(booking);

            return Task.CompletedTask;
        }
    }
}
