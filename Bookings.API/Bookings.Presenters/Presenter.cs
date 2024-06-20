using Bookings.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Presenters
{
    public class Presenter : IPresenter<IActionResult>, IGenericOutputPort
    {
        public IActionResult Content { get; private set; }

        public Task Handle<T>(IEnumerable<T> data)
        {
            Content = new ObjectResult("No se encontraron datos")
            {
                StatusCode = (int)HttpStatusCode.NoContent
            };
            if (data?.Any() == true)
                Content = new OkObjectResult(new { success = true, result = data });

            return Task.CompletedTask;
        }

        public Task Handle<T>(HttpStatusCode statusCode, T data)
        {
            if (statusCode == HttpStatusCode.OK)
                Content = new OkObjectResult(new { success = true, result = data });
            if (statusCode == HttpStatusCode.Unauthorized)
                Content = new UnauthorizedObjectResult(new { success = false, result = data });
            if (statusCode == HttpStatusCode.BadRequest)
                Content = new BadRequestObjectResult(new { success = false, result = data });
            if (statusCode == HttpStatusCode.InternalServerError)
                Content = new ObjectResult(new { success = false, result = data })
                {
                    StatusCode = (int)statusCode
                };


            return Task.CompletedTask;
        }

        public Task Handle<T>(T data)
        {
            if (data != null)
                Content = new OkObjectResult(data);

            return Task.CompletedTask;
        }
    }
}
