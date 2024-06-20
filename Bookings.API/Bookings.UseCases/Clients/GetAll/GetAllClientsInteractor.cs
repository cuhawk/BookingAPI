using Bookings.DTOs;
using Bookings.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases.Clients.GetAll
{
    public class GetAllClientsInteractor : IGetAllClientsInputport
    {
        private readonly IClientsRepository _repository;
        private readonly IGenericOutputPort _output;

        public GetAllClientsInteractor(IClientsRepository repository, IGenericOutputPort output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task Handle()
        {
            var clients = await _repository.GetAllAsync();

            _output.Handle(clients.Select(r => (ClientDto)r)).Wait();
        }
    }
}
