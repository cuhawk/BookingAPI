using Bookings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.Update
{
    public interface IUpdateBookingsInputport
    {
        Task Handle(BookingDto menu);
    }
}
