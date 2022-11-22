using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.BOOK.DAO.Dao;
using STORESERVICES.API.BOOK.DAO.Data;
using STORESERVICES.API.BOOK.DAO.Interfaces;
using STORESERVICES.API.BOOK.DAO.MethodsConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO
{
    public static class ServiceExtensions
    {
        public static void AddDAOLayer(this IServiceCollection services)
        {

            #region Dao
            //Timeline
            services.AddTransient<IContextoLibreria, ContextoLibreria>();
            services.AddTransient<IDatabaseHub, DatabaseHub>();
            services.AddTransient<IBookDao, BookDao>();
            #endregion
        }
    }
}
