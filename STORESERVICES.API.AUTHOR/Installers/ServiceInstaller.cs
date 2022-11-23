using STORESERVICES.API.AUTHOR.SERVICES;

namespace STORESERVICES.API.AUTHOR.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSERVICESLayer();
        }
    }
}
