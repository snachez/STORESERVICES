using STORESERVICES.API.AUTHOR.DAO.Data;

namespace STORESERVICES.API.AUTHOR.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<ContextoAutor>();
        }
    }
}
