namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
