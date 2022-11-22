using Dapper;
using STORESERVICES.API.AUTHOR.DAO.Data;
using STORESERVICES.API.AUTHOR.DAO.Interfaces;
using STORESERVICES.API.AUTHOR.DAO.MethodsConnection;
using STORESERVICES.API.AUTHOR.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.Dao
{
    public class AuthorBookDao : IAuthorBookDao
    {
        private readonly IDatabaseHub _databaseHub;
        private readonly IContextoAutor _contextoAutor;

        public AuthorBookDao(IDatabaseHub databaseHub, IContextoAutor contextoAutor)
        {
            _databaseHub = databaseHub ?? throw new ArgumentNullException(nameof(databaseHub));
            _contextoAutor = contextoAutor ?? throw new ArgumentNullException(nameof(contextoAutor));
        }

        public Task<long> NewAuthorBook(string Nombre, string Apellido, DateTime? FechaNacimiento, string AutorLibroGuid)
        {
            var parameters = new DynamicParameters();
            parameters.Add(name: "nombre", value: Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "apellido", value: Apellido, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "fechanacimiento", value: FechaNacimiento, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "autorlibroguid", value: AutorLibroGuid, dbType: DbType.String, direction: ParameterDirection.Input);

            return _databaseHub.ExecuteAsync(
                    storedProcedureName: "newauthorbook", parameters: parameters, contextoAutor: _contextoAutor);
        }

        public List<AutorLibro> QueryAuthorBook()
        {
            return _databaseHub.QueryAsync<AutorLibro>(
                     storedProcedureName: "SELECT * FROM public.getauthorbook()", contextoAutor: _contextoAutor).Result;
        }

        public AutorLibro QueryByIdAuthorBook(string id)
        {

            var N = _databaseHub.QueryParameterAsync<AutorLibro>(
                    storedProcedureName: $"SELECT * FROM public.getbyidauthorbook('{id}')", contextoAutor: _contextoAutor).Result;

            return N;
        }
    }
}
