using Microsoft.Extensions.DependencyInjection;
using STORESERVICES.API.LOGINJWT.DAO.Dao;
using STORESERVICES.API.LOGINJWT.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.DAO
{
    public static class ServiceExtensions
    {
        public static void AddDAOLayer(this IServiceCollection services)
        {

            #region Dao
            services.AddTransient<IGenerateJwtDao, GenerateJwtDao>();
            services.AddTransient<IAuthenticateUserDao, AuthenticateUserDao>();
            #endregion
        }
    }
}
