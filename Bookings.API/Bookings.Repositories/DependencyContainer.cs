using Bookings.Entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bookings.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IClientsRepository, ClientRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
    }
}
