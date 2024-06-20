using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Entities.Interfaces
{
    public interface IGenericOutputPort
    {
        Task Handle<T>(T data);
        Task Handle<T>(IEnumerable<T> data);
        Task Handle<T>(HttpStatusCode statusCode, T data);
    }
}
