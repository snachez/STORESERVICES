using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.GATEWAY.SERVICES.Services;
using Ocelot.DependencyInjection;

namespace STORESERVICES.API.GATEWAY.SERVICES
{
    public static class ServiceExtensions
    {
        public static void AddSERVICESLayer(this IServiceCollection services)
        {
            services.AddOcelot().AddDelegatingHandler<LibroHandler>();
        }
    }
}
