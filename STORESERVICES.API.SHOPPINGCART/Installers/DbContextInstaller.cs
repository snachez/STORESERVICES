using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.SHOPPINGCART.DAO.Data;

namespace STORESERVICES.API.SHOPPINGCART.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Add Principal Database Services
            services.AddDbContext<CarritoContexto>(options =>
                   options.UseMySQL(connectionString: configuration.GetConnectionString(name: "ConexionDatabase"),
                   MySQLOptionsAction: sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(assemblyName: "STORESERVICES.API.SHOPPINGCART");
                   }));
        }
    }
}
