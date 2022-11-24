using STORESERVICES.API.GATEWAY.DAO;

namespace STORESERVICES.API.GATEWAY.Installers
{
    public class DaoInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDAOLayer(configuration);
        }
    }
}
