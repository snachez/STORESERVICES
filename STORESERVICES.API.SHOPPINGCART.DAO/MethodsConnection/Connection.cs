using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using STORESERVICES.API.SHOPPINGCART.DAO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.MethodsConnection
{
    public class Connection : IDisposable
    {
        private static MySqlConnectionStringBuilder ConnectionString(ICarritoContexto carritoContexto)
        {
            return new MySqlConnectionStringBuilder(carritoContexto.Database.GetConnectionString());
        }

        protected static IDbConnection LiveConnection(ICarritoContexto carritoContexto)
        {
            var connection = OpenConnection(ConnectionString(carritoContexto));
            connection.Open();
            return connection;
        }

        private static IDbConnection OpenConnection(MySqlConnectionStringBuilder connectionString)
        {
            return new MySqlConnection(connectionString.ConnectionString);
        }

        protected static bool CloseConnection(IDbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
                // connection.Dispose();
            }
            return true;
        }

        private static void ClearPool()
        {
            MySqlConnection.ClearAllPools();
        }

        public void Dispose()
        {
            ClearPool();
        }
    }
}
