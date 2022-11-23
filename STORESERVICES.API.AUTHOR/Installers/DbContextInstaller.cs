using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.AUTHOR.DAO.Data;

namespace STORESERVICES.API.AUTHOR.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Add Principal Database Services
            services.AddDbContext<ContextoAutor>(options =>
                   options.UseNpgsql(connectionString: configuration.GetConnectionString(name: "ConexionDatabase"),
                   npgsqlOptionsAction: sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(assemblyName: "STORESERVICES.API.AUTHOR");
                       sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(value: 30), errorCodesToAdd: null);
                   }));
        }
    }
}
