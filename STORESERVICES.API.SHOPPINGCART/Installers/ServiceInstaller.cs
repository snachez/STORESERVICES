using STORESERVICES.API.SHOPPINGCART.SERVICES;

namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSERVICESLayer(configuration);
        }
    }
}
