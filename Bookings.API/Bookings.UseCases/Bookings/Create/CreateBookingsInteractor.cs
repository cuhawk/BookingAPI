using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.Create
{
    public class CreateBookingsInteractor : ICreateBookingsInputport
    {
        private readonly IGenericOutputPort _output;
        private readonly IBookingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingsInteractor(IGenericOutputPort output, IBookingRepository repository, IUnitOfWork unitOfWork)
        {
            _output = output;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateBookingDto booking)
        {
            var _menu = (Entities.Models.Booking)booking;
            await _repository.Create(_menu);
            var result = await _unitOfWork.SaveChanges();
            if (result < 1)
            {
                await _output.Handle(HttpStatusCode.InternalServerError, "Se presentaron errores al crear la reserva");
                return;
            }
            await _output.Handle(HttpStatusCode.OK, (BookingDto)_menu);
        }
    }
}
