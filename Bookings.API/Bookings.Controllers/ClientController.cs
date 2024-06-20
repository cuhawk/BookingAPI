using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using Bookings.UseCases.Clients.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    [Route("Api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IGetAllClientsInputport _inputPort;
        private readonly IGenericOutputPort _outputPort;

        public ClientController(IGetAllClientsInputport inputPort, IGenericOutputPort outputPort)
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
