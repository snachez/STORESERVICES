namespace STORESERVICES.API.BOOK.Config
{
    public class HttpsConfig : IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
        }
    }
}
