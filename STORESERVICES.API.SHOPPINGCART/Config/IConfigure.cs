namespace STORESERVICES.API.SHOPPINGCART.Config
{
    public interface IConfigure
    {
        void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
