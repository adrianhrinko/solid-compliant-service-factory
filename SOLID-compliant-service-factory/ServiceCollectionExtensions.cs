using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SOLID_compliant_service_factory.Services;

namespace SOLID_compliant_service_factory
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all required services to the service collection.
        /// </summary>
        /// <param name="services">the service collection</param>
        /// <param name="configuration">the host configuration</param>
        public static IServiceCollection AddFunctionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();

            return services;
        }
    }
}
