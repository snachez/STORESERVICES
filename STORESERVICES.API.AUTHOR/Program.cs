using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using STORESERVICES.API.AUTHOR.Config;
using STORESERVICES.API.AUTHOR.DAO;
using STORESERVICES.API.AUTHOR.DAO.Data;
using STORESERVICES.API.AUTHOR.Installers;
using STORESERVICES.API.AUTHOR.SERVICES;

namespace STORESERVICES.API.AUTHOR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            Configure(app);

        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.InstallServicesInAssembly(builder.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(WebApplication app)
        {
            app.InstallConfigurationsInAssembly(app.Environment);

            app.UseAuthorization();


            app.MapControllers();

            try
            {
                Log.Information("Application Starting Up.");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start correctly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}