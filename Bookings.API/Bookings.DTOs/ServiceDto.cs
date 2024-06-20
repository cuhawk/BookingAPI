using Bookings.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.DTOs
{
    public class ServiceDto
    {
        public string? Idservice { get; set; }
        public string? Servicename { get; set; }
        public DateTime? Fechacreacion { get; set; }

        public static explicit operator ServiceDto(Service service) => new()
        {
            Idservice = service.Idservice,
            Servicename = service.Servicename,
            Fechacreacion = service.Fechacreacion,
        };
    }
}
