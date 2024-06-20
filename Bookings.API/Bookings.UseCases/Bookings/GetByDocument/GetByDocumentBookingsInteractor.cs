using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.GetByDocument
{
    public class GetByDocumentBookingsInteractor : IGetByDocumentBookingsInputport
    {
        private readonly IGenericOutputPort _output;
        private readonly IBookingRepository _repository;

        public GetByDocumentBookingsInteractor(IGenericOutputPort output, IBookingRepository repository)
        {
            _output = output;
            _repository = repository;
        }

        public async Task Handle(GetByDocumentBookingDto booking)
        {
            var bookings = await _repository.GetByDocumentAsync(booking.Documentnumber, booking.idservice, booking.Idclient);

            var bookings2 = bookings.Where(w => Convert.ToDateTime(w.Bookingdate) >= (booking.Idate != null ? booking.Idate : Convert.ToDateTime(w.Bookingdate))
                            && Convert.ToDateTime(w.Bookingdate) <= (booking.Fdate != null ? booking.Fdate : Convert.ToDateTime(w.Bookingdate))).ToList();

            _output.Handle(bookings2.Select(r => (BookingDto)r)).Wait();
        }
    }
}
