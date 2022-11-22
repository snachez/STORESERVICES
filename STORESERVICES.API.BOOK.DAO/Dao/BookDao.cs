using Dapper;
using STORESERVICES.API.BOOK.DAO.Data;
using STORESERVICES.API.BOOK.DAO.Interfaces;
using STORESERVICES.API.BOOK.DAO.MethodsConnection;
using STORESERVICES.API.BOOK.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.Dao
{
    public class BookDao : IBookDao
    {
        private readonly IDatabaseHub _databaseHub;
        private readonly IContextoLibreria _contextoLibreria;

        public BookDao(IDatabaseHub databaseHub, IContextoLibreria contextoLibreria)
        {
            _databaseHub = databaseHub ?? throw new ArgumentNullException(nameof(databaseHub));
            _contextoLibreria = contextoLibreria ?? throw new ArgumentNullException(nameof(contextoLibreria));
        }

        public async Task<long> NewBook(string Titulo, DateTime? FechaPublicacion, Guid? AutorLibro)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "@Titulo", value: Titulo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@FechaPublicacion", value: FechaPublicacion, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "@AutorLibro", value: AutorLibro, dbType: DbType.Guid, direction: ParameterDirection.Input);

            return await _databaseHub.ExecuteAsync(
                    storedProcedureName: "newbook", parameters: parameters, contextoLibreria: _contextoLibreria);
        }

        public async Task<List<LibreriaMaterial>> QueryBook()
        {
            return await _databaseHub.QueryAsync<LibreriaMaterial>(
                     storedProcedureName: "getallbook", contextoLibreria: _contextoLibreria);
        }

        public async Task<LibreriaMaterial> QueryByIdBook(Guid? id)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "@LibreriaMaterialId", value: id, dbType: DbType.Guid, direction: ParameterDirection.Input);

            return await _databaseHub.QueryParameterAsync<LibreriaMaterial>(
                    storedProcedureName: "getbyidbook", parameters: parameters, contextoLibreria: _contextoLibreria);
        }
    }
}
