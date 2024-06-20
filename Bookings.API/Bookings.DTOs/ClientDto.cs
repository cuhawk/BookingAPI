using Bookings.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.DTOs
{
    public class ClientDto
    {
        public string? Idclient { get; set; }
        public string? Clientnit { get; set; }
        public string? Clientname { get; set; }
        public string? Idservice { get; set; }
        public string? Description { get; set; }
        public bool? Disabled { get; set; }
        public DateTime? Creationdate { get; set; }

        public static explicit operator ClientDto(Client service) => new()
        {
            Idclient = service.Idclient,
            Clientnit = service.Clientnit,
            Clientname = service.Clientname,
            Idservice = service.Idservice,
            Description = service.Description,
            Creationdate = service.Creationdate,
        };
    }
}
