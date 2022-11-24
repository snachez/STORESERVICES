using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.BOOK.DAO.Data;

namespace STORESERVICES.API.BOOK.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Add Principal Database Services
            services.AddDbContext<ContextoLibreria>(options =>
                   options.UseSqlServer(connectionString: configuration.GetConnectionString(name: "ConexionDB"),
                   sqlServerOptionsAction: sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(assemblyName: "STORESERVICES.API.BOOK");
                       sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(value: 30), errorNumbersToAdd: null);
                   }));
        }
    }
}
