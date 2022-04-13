using App.Domain.Interfaces;
using App.Infra.Data;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace app.api.Infrastructure
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(IOptions<AppSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
