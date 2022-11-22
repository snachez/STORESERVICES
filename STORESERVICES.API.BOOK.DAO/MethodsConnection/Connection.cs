using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.BOOK.DAO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.MethodsConnection
{
    public class Connection : IDisposable
    {
        private static SqlConnectionStringBuilder ConnectionString(IContextoLibreria contextoLibreria)
        {
            return new SqlConnectionStringBuilder(contextoLibreria.Database.GetConnectionString());
        }

        protected static IDbConnection LiveConnection(IContextoLibreria contextoLibreria)
        {
            var connection = OpenConnection(ConnectionString(contextoLibreria));
            connection.Open();
            return connection;
        }

        private static IDbConnection OpenConnection(SqlConnectionStringBuilder connectionString)
        {
            return new SqlConnection(connectionString.ConnectionString);
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
            SqlConnection.ClearAllPools();
        }

        public void Dispose()
        {
            ClearPool();
        }
    }
}
