using STORESERVICES.API.LOGINJWT.DAO;

namespace STORESERVICES.API.LOGINJWT.Installers
{
    public class DaoInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDAOLayer();
        }
    }
}
