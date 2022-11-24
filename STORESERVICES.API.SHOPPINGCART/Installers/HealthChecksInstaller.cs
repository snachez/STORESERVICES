using STORESERVICES.API.SHOPPINGCART.DAO.Data;

namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<CarritoContexto>();
        }
    }
}
