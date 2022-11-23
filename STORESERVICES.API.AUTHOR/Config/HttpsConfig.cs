namespace STORESERVICES.API.AUTHOR.Config
{
    public class HttpsConfig : IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
        }
    }
}
