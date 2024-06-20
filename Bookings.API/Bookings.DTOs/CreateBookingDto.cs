using Bookings.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.DTOs
{
    public class CreateBookingDto
    {
        public string Idclient { get; set; }
        public string Documentnumber { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Bookingdate { get; set; }

        public static explicit operator Booking(CreateBookingDto booking) => new()
        {
            Idbooking = Guid.NewGuid().ToString(),
            Idclient = booking.Idclient,
            Documentnumber = booking.Documentnumber,
            Name = booking.Name,
            Amount = booking.Amount,
            Bookingdate = booking.Bookingdate,
            Creationdate = DateTime.Now
        };
    }
}
