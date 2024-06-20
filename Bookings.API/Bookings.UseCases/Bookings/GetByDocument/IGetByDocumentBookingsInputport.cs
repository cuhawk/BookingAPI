using Bookings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.GetByDocument
{
    public interface IGetByDocumentBookingsInputport
    {
        Task Handle(GetByDocumentBookingDto booking);
    }
}
