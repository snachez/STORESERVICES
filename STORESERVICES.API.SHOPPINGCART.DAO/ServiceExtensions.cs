using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.SHOPPINGCART.DAO.Dao;
using STORESERVICES.API.SHOPPINGCART.DAO.Data;
using STORESERVICES.API.SHOPPINGCART.DAO.Interfaces;
using STORESERVICES.API.SHOPPINGCART.DAO.MethodsConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO
{
    public static class ServiceExtensions
    {
        public static void AddDAOLayer(this IServiceCollection services)
        {

            #region Dao
            //Timeline
            services.AddTransient<ICarritoContexto, CarritoContexto>();
            services.AddTransient<IDatabaseHub, DatabaseHub>();
            services.AddTransient<ICartSessionDao, CartSessionDao>();
            services.AddTransient<ICartSessionDetailDao, CartSessionDetailDao>();
            #endregion
        }
    }
}
