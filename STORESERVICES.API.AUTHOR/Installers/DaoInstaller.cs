using STORESERVICES.API.AUTHOR.DAO;

namespace STORESERVICES.API.AUTHOR.Installers
{
    public class DaoInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDAOLayer();
        }
    }
}
