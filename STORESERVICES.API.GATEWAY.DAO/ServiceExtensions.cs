using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.GATEWAY.DAO.Dao;
using STORESERVICES.API.GATEWAY.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.DAO
{
    public static class ServiceExtensions
    {
        public static void AddDAOLayer(this IServiceCollection services, IConfiguration Configuration)
        {

            #region Dao
            //Timeline
            services.AddHttpClient("AutorService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Autor"]);
            });

            services.AddSingleton<IAutorRemoteDao, AutorRemoteDao>();
            #endregion
        }
    }
}
