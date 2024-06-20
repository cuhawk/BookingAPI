using System;
using System.Collections.Generic;

namespace Bookings.Entities.Models
{
    public partial class Client
    {
        public string Idclient { get; set; } = null!;
        public string Clientnit { get; set; } = null!;
        public string Clientname { get; set; } = null!;
        public string Idservice { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Disabled { get; set; }
        public DateTime Creationdate { get; set; }
    }
}
