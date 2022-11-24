using STORESERVICES.API.BOOK.SERVICES;

namespace STORESERVICES.API.BOOK.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSERVICESLayer();
        }
    }
}
