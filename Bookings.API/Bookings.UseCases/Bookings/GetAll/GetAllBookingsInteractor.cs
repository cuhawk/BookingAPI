using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.GetAll
{
    public class GetAllBookingsInteractor : IGetAllBookingsInputport
    {
        private readonly IBookingRepository _repository;
        private readonly IGenericOutputPort _output;

        public GetAllBookingsInteractor(IBookingRepository repository, IGenericOutputPort output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task Handle()
        {
            var bookings = await _repository.GetAllAsync();

            _output.Handle(bookings.Select(r => (BookingDto)r)).Wait();
        }
    }
}
