namespace STORESERVICES.API.GATEWAY.Installers
{
    public class OcelotInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerForOcelot(configuration);
        }
    }
}
