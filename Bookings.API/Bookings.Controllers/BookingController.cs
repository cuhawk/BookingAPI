using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using Bookings.UseCases.Bookings.Create;
using Bookings.UseCases.Bookings.GetAll;
using Bookings.UseCases.Bookings.GetByDocument;
using Bookings.UseCases.Bookings.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    [Route("Api/[controller]")]
    public class BookingController
    {
        private readonly ICreateBookingsInputport _inputPort;
        private readonly IGetAllBookingsInputport _GetAll_inputPort;
        private readonly IGetByDocumentBookingsInputport _GetByDocument_inputPort;
        private readonly IUpdateBookingsInputport _Update_inputPort;
        private readonly IGenericOutputPort _outputPort;

        public BookingController(ICreateBookingsInputport inputPort,
            IGetAllBookingsInputport GetAll_inputPort,
            IGetByDocumentBookingsInputport GetByDocument_inputPort,
            IUpdateBookingsInputport Update_inputPort, 
            IGenericOutputPort outputPort)
        {
            _inputPort = inputPort;
            _GetAll_inputPort = GetAll_inputPort;
            _GetByDocument_inputPort = GetByDocument_inputPort;
            _Update_inputPort = Update_inputPort;
            _outputPort = outputPort;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponseDto<string>))]
        public async Task<IActionResult> Create([FromBody] CreateBookingDto booking)
        {
            await _inputPort.Handle(booking);

            return ((IPresenter<IActionResult>)_outputPort).Content;
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponseDto<string>))]
        public async Task<IActionResult> GetAll()
        {
            await _GetAll_inputPort.Handle();

            return ((IPresenter<IActionResult>)_outputPort).Content;
        }

        [HttpPost("getbydocument")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponseDto<string>))]
        public async Task<IActionResult> GetByDocument([FromBody] GetByDocumentBookingDto booking)
        {
            await _GetByDocument_inputPort.Handle(booking);

            return ((IPresenter<IActionResult>)_outputPort).Content;
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<dynamic>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponseDto<string>))]
        public async Task<IActionResult> Update([FromBody] BookingDto booking)
        {
            await _Update_inputPort.Handle(booking);

            return ((IPresenter<IActionResult>)_outputPort).Content;
        }

    }
}
