namespace STORESERVICES.API.LOGINJWT.Config
{
    public class HttpsConfig : IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
        }
    }
}
