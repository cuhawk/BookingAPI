using System;
using System.Collections.Generic;

namespace Bookings.Entities.Models
{
    public partial class Service
    {
        public string Idservice { get; set; } = null!;
        public string Servicename { get; set; } = null!;
        public DateTime Fechacreacion { get; set; }
    }
}
