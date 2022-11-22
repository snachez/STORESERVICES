using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.AUTHOR.DAO.Dao;
using STORESERVICES.API.AUTHOR.DAO.Data;
using STORESERVICES.API.AUTHOR.DAO.Interfaces;
using STORESERVICES.API.AUTHOR.DAO.MethodsConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO
{
    public static class ServiceExtensions
    {
        public static void AddDAOLayer(this IServiceCollection services)
        {

            #region Dao
            //Timeline
            services.AddTransient<IContextoAutor, ContextoAutor>();
            services.AddTransient<IDatabaseHub, DatabaseHub>();
            services.AddTransient<IAuthorBookDao, AuthorBookDao>();
            #endregion
        }
    }
}
