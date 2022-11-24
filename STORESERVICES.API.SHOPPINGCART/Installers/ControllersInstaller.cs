namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public class ControllersInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
        }
    }
}
