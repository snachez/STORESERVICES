using Microsoft.EntityFrameworkCore;
using Npgsql;
using STORESERVICES.API.AUTHOR.DAO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.MethodsConnection
{
    public class Connection : IDisposable
    {
        private static NpgsqlConnectionStringBuilder ConnectionString(IContextoAutor contextoAutor)
        {
            return new NpgsqlConnectionStringBuilder(contextoAutor.Database.GetConnectionString());
        }

        protected static IDbConnection LiveConnection(IContextoAutor contextoAutor)
        {
            var connection = OpenConnection(ConnectionString(contextoAutor));
            connection.Open();
            return connection;
        }

        private static IDbConnection OpenConnection(NpgsqlConnectionStringBuilder connectionString)
        {
            return new NpgsqlConnection(connectionString.ConnectionString);
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
            NpgsqlConnection.ClearAllPools();
        }

        public void Dispose()
        {
            ClearPool();
        }
    }
}
