using STORESERVICES.API.SHOPPINGCART.DAO;

namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public class DaoInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDAOLayer();
        }
    }
}
