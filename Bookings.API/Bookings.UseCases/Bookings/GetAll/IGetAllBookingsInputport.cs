using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.GetAll
{
    public interface IGetAllBookingsInputport
    {
        Task Handle();
    }
}
