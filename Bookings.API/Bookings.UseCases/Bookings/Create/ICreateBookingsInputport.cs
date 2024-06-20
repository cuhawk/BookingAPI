using Bookings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.Create
{
    public interface ICreateBookingsInputport
    {
        Task Handle(CreateBookingDto booking);
    }
}
