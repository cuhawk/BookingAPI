using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using Bookings.UseCases.Services.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    [Route("Api/[controller]")]
    public class ServiceController : ControllerBase
    {

        private readonly IGetAllServiceInputport _inputPort;
        private readonly IGenericOutputPort _outputPort;

        public ServiceController(IGetAllServiceInputport inputPort, IGenericOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponseDto<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponseDto<string>))]
        public async Task<IActionResult> GetAll()
        {
            await _inputPort.Handle();

            return ((IPresenter<IActionResult>)_outputPort).Content;
        }

    }
}
