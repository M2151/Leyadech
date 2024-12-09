using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using Leyadech.Data;
using Leyadech.Data.Repositories;
using Leyadech.Service;
using Microsoft.Extensions.DependencyInjection;
using static Leyadech.Data.DataContext;

namespace Leyadech.Api.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures dependency injection for application services and repositories.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the dependencies to.</param>
        public static void ServiceDependencyInjector(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IRepository<Mother>, MotherRepository>();
            services.AddScoped<IRepository<Volunteer>, VolunteerRepository>();
            services.AddScoped<IRepository<Volunteering>, VolunteeringRepository>();
            services.AddScoped<IRepository<Suggest>, SuggestRepository>();
            services.AddScoped<IRepository<Request>, RequestRepository>();

            // Register services
            services.AddScoped<IMotherService, MotherService>();
            services.AddScoped<IVolunteerService, VolunteerService>();
            services.AddScoped<IVolunteeringService, VolunteeringService>();
            services.AddScoped<ISuggestService, SuggestService>();
            services.AddScoped<IRequestService, RequestService>();

            services.AddDbContext<DataContext>();
        }
    }
}
