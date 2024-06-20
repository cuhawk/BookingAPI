using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Services.GetAll
{
    public class GetAllServiceInteractor : IGetAllServiceInputport
    {
        private readonly IServiceRepository _repository;
        private readonly IGenericOutputPort _output;

        public GetAllServiceInteractor(IServiceRepository repository, IGenericOutputPort output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task Handle()
        {
            var services = await _repository.GetAllAsync();

            _output.Handle(services.Select(r => (ServiceDto)r)).Wait();
        }
    }
}
