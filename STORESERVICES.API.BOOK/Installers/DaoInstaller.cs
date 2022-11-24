using STORESERVICES.API.BOOK.DAO;

namespace STORESERVICES.API.BOOK.Installers
{
    public class DaoInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDAOLayer();
        }
    }
}
