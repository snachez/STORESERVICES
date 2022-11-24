using STORESERVICES.API.BOOK.DAO.Data;

namespace STORESERVICES.API.BOOK.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<ContextoLibreria>();
        }
    }
}
