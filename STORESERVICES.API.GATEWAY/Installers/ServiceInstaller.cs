using STORESERVICES.API.GATEWAY.SERVICES;

namespace STORESERVICES.API.GATEWAY.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSERVICESLayer();
        }
    }
}
