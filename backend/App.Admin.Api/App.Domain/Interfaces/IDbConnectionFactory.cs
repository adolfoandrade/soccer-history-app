using System.Data;

namespace App.Domain.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
