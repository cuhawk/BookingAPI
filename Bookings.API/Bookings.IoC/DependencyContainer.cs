using Bookings.Presenters;
using Bookings.Repositories;
using Bookings.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Bookings.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddUseCases();
            services.AddPresenters();
            return services;
        }
    }
}