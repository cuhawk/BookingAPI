using Bookings.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Entities.Interfaces
{
    public interface IBookingRepository
    {
        Task Create(Booking booking);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetByDocumentAsync(string documentnumber, string? idservice, string? idclient);
        Task<Booking?> GetById(string? id);
        Task Update(Booking booking);
    }
}
