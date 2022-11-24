using Microsoft.OpenApi.Models;

namespace STORESERVICES.API.GATEWAY.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "STORESERVICES.API.GATEWAY", Version = "v1" });
            });
        }
    }
}
