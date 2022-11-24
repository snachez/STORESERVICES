namespace STORESERVICES.API.LOGINJWT.Config
{
    public interface IConfigure
    {
        void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
