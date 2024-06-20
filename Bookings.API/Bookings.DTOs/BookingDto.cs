using Bookings.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.DTOs
{
    public class BookingDto
    {
        public string? Idbooking { get; set; }
        public string? Idclient { get; set; }
        public string? Documentnumber { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
        public string Bookingdate { get; set; }
        public DateTime? Creationdate { get; set; }

        public static explicit operator BookingDto(Booking booking) => new()
        {
            Idbooking = booking.Idbooking,
            Idclient = booking.Idclient,
            Documentnumber = booking.Documentnumber,
            Name = booking.Name,
            Amount = booking.Amount,
            Bookingdate = booking.Bookingdate,
            Creationdate = booking.Creationdate
        };
    }
}
