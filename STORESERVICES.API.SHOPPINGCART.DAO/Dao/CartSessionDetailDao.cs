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
    public class CartSessionDetailDao : ICartSessionDetailDao
    {
        private readonly IDatabaseHub _databaseHub;
        private readonly ICarritoContexto _carritoContexto;

        public CartSessionDetailDao(IDatabaseHub databaseHub, ICarritoContexto carritoContexto)
        {
            _databaseHub = databaseHub ?? throw new ArgumentNullException(nameof(databaseHub));
            _carritoContexto = carritoContexto ?? throw new ArgumentNullException(nameof(carritoContexto));
        }

        public async Task<int> NewCartSessionDetail(DateTime CreationDate, string ProductList, int CartSessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "CartSessionId", value: CartSessionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add(name: "CreationDate", value: CreationDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "ProductList", value: ProductList, dbType: DbType.String, direction: ParameterDirection.Input);

            return await _databaseHub.QueryParameterAsync<int>(
                    storedProcedureName: "newcartsessiondetail", parameters: parameters, carritoContexto: _carritoContexto);
        }

        public async Task<List<string>> GetByIdCartSessionDetail(int CartSessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "CartSessionId", value: CartSessionId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return await _databaseHub.QueryAsync<string>(
                     storedProcedureName: "cartsessiondetailbyid", parameters: parameters, carritoContexto: _carritoContexto);
        }
    }
}
