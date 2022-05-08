using App.Domain.Interfaces;
using App.Infra.Data;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace app.api.Infrastructure
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            var connection = Environment.GetEnvironmentVariable("SOCCER_APP_SQLSERVER");
            return new SqlConnection(connection);
        }

    }
}
