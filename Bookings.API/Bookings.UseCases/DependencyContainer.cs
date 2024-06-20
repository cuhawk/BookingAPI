using Bookings.UseCases.Bookings.Create;
using Bookings.UseCases.Bookings.GetAll;
using Bookings.UseCases.Bookings.GetByDocument;
using Bookings.UseCases.Bookings.Update;
using Bookings.UseCases.Clients.GetAll;
using Bookings.UseCases.Services.GetAll;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            
            services.AddTransient<IGetAllServiceInputport, GetAllServiceInteractor>();
            services.AddTransient<IGetAllClientsInputport, GetAllClientsInteractor>();
            services.AddTransient<IGetAllBookingsInputport, GetAllBookingsInteractor>();
            services.AddTransient<IGetByDocumentBookingsInputport, GetByDocumentBookingsInteractor>();
            services.AddTransient<ICreateBookingsInputport, CreateBookingsInteractor>();
            services.AddTransient<IUpdateBookingsInputport, UpdateBookingsInteractor>();


            return services;
        }
    }
}
