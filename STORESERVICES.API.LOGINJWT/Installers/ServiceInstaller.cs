using STORESERVICES.API.LOGINJWT.SERVICES;

namespace STORESERVICES.API.LOGINJWT.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSERVICESLayer();
        }
    }
}
