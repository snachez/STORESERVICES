using Dapper;
using STORESERVICES.API.BOOK.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.MethodsConnection
{
    public interface IDatabaseHub
    {
        /// <summary>
        /// Este método se utiliza para ejecutar los procedimientos almacenados sin parámetros. Esta es la versión genérica del método.
        /// </summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado. Se espera que sea una cadena Verbatim, p. @"[Esquema].[Nombre del procedimiento almacenado]"</param>
        /// <returns>Retorna cuantas filas hay en la consulta.</returns>
        Task<List<T>> QueryAsync<T>(string storedProcedureName, IContextoLibreria contextoLibreria);

        /// <summary>
        /// Este método se utiliza para ejecutar los procedimientos almacenados con parámetro. Esta es la versión genérica del método.
        /// </summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado. Se espera que sea una cadena Verbatim, p. @"[Esquema].[Nombre del procedimiento almacenado]"</param>
        /// <param name="parameters">Parámetro necesario para ejecutar el procedimiento almacenado.</param>
        /// <returns>Retorna cuantas filas hay en la consulta.</returns>         
        Task<T> QueryParameterAsync<T>(string storedProcedureName, DynamicParameters parameters, IContextoLibreria contextoLibreria);

        /// <summary>
        /// Este método se usa para ejecutar los procedimientos almacenados con parámetro. Esta es la versión genérica del método.
        /// </summary>
        /// <param name="storedProcedureName">Este es el tipo de clase POCO que se devolverá. Para obtener más información, consulte https://msdn.microsoft.com/en-us/library/vstudio/dd456872(v=vs.100).aspx. </parámetro>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model">El objeto modelo que contiene todos los valores que pasa como parámetro del procedimiento almacenado.</param>
        /// <returns>Retorna cuantas filas han sido afectadas.</returns>
        Task<long> ExecuteAsync<TModel>(string storedProcedureName, TModel model, IContextoLibreria contextoLibreria);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<long> ExecuteAsync(string storedProcedureName, DynamicParameters parameters, IContextoLibreria contextoLibreria);
    }
}
