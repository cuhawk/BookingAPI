using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.DTOs
{
    public class GetByDocumentBookingDto
    {
        public string? Documentnumber { get; set; }
        public string? idservice { get; set; }
        public string? Idclient { get; set; }
        public DateTime? Idate { get; set; }
        public DateTime? Fdate { get; set; }
    }
}
