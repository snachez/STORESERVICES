using Dapper;
using STORESERVICES.API.BOOK.DAO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.MethodsConnection
{
    public class DatabaseHub : Connection, IDatabaseHub
    {

        /// <summary>
        /// Este método se utiliza para ejecutar los procedimientos almacenados sin parámetros.
        /// <summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado. Se espera que sea una cadena Verbatim, p. @"[Esquema].[Nombre del procedimiento almacenado]"</param>
        /// <returns>Retorna cuantas filas hay en la consulta.</returns>

        public async Task<List<T>> QueryAsync<T>(string storedProcedureName, IContextoLibreria contextoLibreria)
        {
            using (var connection = LiveConnection(contextoLibreria))
            {
                try
                {
                    List<T> result = new List<T>();

                    result = (await connection.QueryAsync<T>(
                        sql: storedProcedureName,
                        commandType: CommandType.Text,
                        commandTimeout: null
                        )).ToList();

                    return result;

                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para ejecutar los procedimientos almacenados sin parámetros.
        /// <summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado. Se espera que sea una cadena Verbatim, p. @"[Esquema].[Nombre del procedimiento almacenado]"</param>
        /// <param name="model">El objeto modelo que contiene todos los valores que pasa como parámetro del procedimiento almacenado.</param>
        /// <typeparam name="TModel">Este es el tipo de clase POCO que se devolverá. Para obtener más información, consulte https://msdn.microsoft.com/en-us/library/vstudio/dd456872(v=vs.100).aspx. </typeparam>
        /// <returns>Retorna cuantas filas han sido afectadas.</returns>
        public async Task<long> ExecuteAsync<TModel>(string storedProcedureName, TModel model, IContextoLibreria contextoLibreria)
        {

            using (var connection = LiveConnection(contextoLibreria))
            {
                try
                {
                    return await connection.ExecuteAsync(
                        sql: storedProcedureName,
                        param: model,
                        commandTimeout: null,
                        commandType: CommandType.StoredProcedure
                        );

                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para ejecutar los procedimientos almacenados con parámetro. Esta es la versión genérica del método.
        /// <summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado. Se espera que sea una cadena Verbatim, p. @"[Esquema].[Nombre del procedimiento almacenado]"</param>
        /// <param name="parameters">Parámetro necesario para ejecutar el procedimiento almacenado.</param>
        /// <returns>Retorna cuantas filas han sido afectadas.</returns>

        public async Task<T> QueryParameterAsync<T>(string storedProcedureName, DynamicParameters parameters, IContextoLibreria contextoLibreria)
        {
            using (var connection = LiveConnection(contextoLibreria))
            {
                try
                {

                    T result = (await connection.QueryAsync<T>(
                        sql: storedProcedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: null
                        )).SingleOrDefault();

                    return result;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }



        public async Task<long> ExecuteAsync(string storedProcedureName, DynamicParameters parameters, IContextoLibreria contextoLibreria)
        {
            using (var connection = LiveConnection(contextoLibreria))
            {
                try
                {

                    return await connection.ExecuteAsync(
                        sql: storedProcedureName,
                        param: parameters,
                        commandTimeout: null,
                        commandType: CommandType.StoredProcedure
                        );

                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }

    }
}
