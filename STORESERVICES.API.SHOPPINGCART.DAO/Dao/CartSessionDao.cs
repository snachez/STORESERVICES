using Dapper;
using STORESERVICES.API.SHOPPINGCART.DAO.Data;
using STORESERVICES.API.SHOPPINGCART.DAO.Interfaces;
using STORESERVICES.API.SHOPPINGCART.DAO.MethodsConnection;
using STORESERVICES.API.SHOPPINGCART.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.Dao
{
    public class CartSessionDao : ICartSessionDao
    {
        private readonly IDatabaseHub _databaseHub;
        private readonly ICarritoContexto _carritoContexto;

        public CartSessionDao(IDatabaseHub databaseHub, ICarritoContexto carritoContexto)
        {
            _databaseHub = databaseHub ?? throw new ArgumentNullException(nameof(databaseHub));
            _carritoContexto = carritoContexto ?? throw new ArgumentNullException(nameof(carritoContexto));
        }

        public async Task<int> NewCartSession(DateTime DateCreationSession)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "datecreationsession", value: DateCreationSession, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            return await _databaseHub.QueryParameterAsync<int>(
                    storedProcedureName: "newcartsession", parameters: parameters, carritoContexto: _carritoContexto);
        }

        public async Task<CarritoSesion> GetByIdCartSession(int CartSessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "CartSessionId", value: CartSessionId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return await _databaseHub.QueryParameterAsync<CarritoSesion>(
                     storedProcedureName: "cartsessionbyid", parameters: parameters, carritoContexto: _carritoContexto);
        }
    }
}
