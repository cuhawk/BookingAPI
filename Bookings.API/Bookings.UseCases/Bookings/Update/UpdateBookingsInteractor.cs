using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Bookings.Update
{
    public class UpdateBookingsInteractor : IUpdateBookingsInputport
    {
        private readonly IGenericOutputPort _output;
        private readonly IBookingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookingsInteractor(IGenericOutputPort output, IBookingRepository repository, IUnitOfWork unitOfWork)
        {
            _output = output;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(BookingDto booking)
        {
            var _booking = await _repository.GetById(booking.Idbooking);
            if (_booking == null)
            {
                await _output.Handle(HttpStatusCode.BadRequest, "No se puede actualizar el menú, no se encuentra.");
                return;
            }

            _booking.Documentnumber = (booking.Documentnumber == _booking.Documentnumber ? _booking.Documentnumber : booking.Documentnumber);
            _booking.Name = (booking.Name == _booking.Name ? _booking.Name : booking.Name);
            _booking.Amount = (booking.Amount == _booking.Amount ? _booking.Amount : booking.Amount);
            _booking.Bookingdate = (booking.Bookingdate == _booking.Bookingdate ? _booking.Bookingdate : booking.Bookingdate);

            _repository.Update(_booking).Wait();
            var result = await _unitOfWork.SaveChanges();
            if (result < 1)
            {
                await _output.Handle(HttpStatusCode.InternalServerError, "Se presentaron errores al actualizar el menú");
                return;
            }
            await _output.Handle(HttpStatusCode.OK, (BookingDto)_booking);
        }
    }
}
