using System;
using System.Collections.Generic;

namespace Bookings.Entities.Models
{
    public partial class Booking
    {
        public string Idbooking { get; set; } = null!;
        public string Idclient { get; set; } = null!;
        public string Documentnumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Amount { get; set; }
        public string Bookingdate { get; set; } = null!;
        public DateTime Creationdate { get; set; }
    }
}
