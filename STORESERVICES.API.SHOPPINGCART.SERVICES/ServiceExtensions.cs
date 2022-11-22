using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.SHOPPINGCART.SERVICES.Interfaces;
using STORESERVICES.API.SHOPPINGCART.SERVICES.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES
{
    public static class ServiceExtensions
    {
        public static void AddSERVICESLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILibrosService, LibrosService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHttpClient("Libros", config =>
            {
                config.BaseAddress = new Uri(configuration["Services:Libros"]);
            });
        }
    }
}
